using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Domain.PurchaseLimit;
using TechnicalE.Entities;
using TechnicalE.Entities.DTO;
using TechnicalE.Entities.Enums;
using TechnicalE.Interfaces;
using TechnicalE.Interfaces.Generic;
using TechnicalE.Interfaces.Services;

namespace TechnicalE.Domain.PurchaseTransactionManager
{
    public class PurchaseTransactionManager : IPurchaseTransactionManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessagesService _MessageService;        
        private readonly IRateConversionService _rateConversion;
        private readonly IFormatNumbers _formatNumbers;

        public PurchaseTransactionManager(IUnitOfWork unitOfWork, 
            IMessagesService errorMessage, 
            IExchangeRateService exchangeService,
            IRateConversionService rateConversion,
            IFormatNumbers formatNumbers) 
        {
            _unitOfWork = unitOfWork;
            _MessageService = errorMessage;            
            _rateConversion = rateConversion;
            _formatNumbers = formatNumbers;
        }

        public async Task<ResponseDTO<PurchaseTransaction>> CurrencyPurchaseHandler(PurchaseDTO purchase) 
        {
            var response = new ResponseDTO<PurchaseTransaction>();

            ExchangeRate rates = _unitOfWork.ExchangeRates.GetExchangeRateByCurrencies((int)CurrencyCodeEnum.ARS, await _unitOfWork.Currencies.GetCurrencyIdByCode(purchase.Code));

            if (rates == null) return _MessageService.CurrencyNotAvailable(response, purchase.Code);

            PurchaseTransaction transaction = FillTransactionData(rates, purchase);
            
            decimal totalAmount = transaction.PurchasedAmount + await _unitOfWork.PurchaseTransactions.GetCurrentMonthPurchasedAmount(purchase.IdUser, rates.Id);
            
            var purchaseLimit = new CurrencyPurchaseLimit();
                       
            response.Data = transaction;

            response.Data.PurchasedAmount = _formatNumbers.FormatDecimalTwoDigits(transaction.PurchasedAmount);
                        
            if (!ValidatePurchaseLimit(totalAmount, rates.IdToCurrency, purchaseLimit)) return _MessageService.PurchaseLimitReached(response);
                                          
            _unitOfWork.PurchaseTransactions.AddTransaction(transaction);
                        
            return _MessageService.PurchaseTransaction(response, await _unitOfWork.Currencies.GetCurrencyNameByCode(purchase.Code));
        }
        
        private bool ValidatePurchaseLimit(decimal totalAmount, int idCurrency, CurrencyPurchaseLimit purchaseLimit) =>
            idCurrency switch
            {
                (int)CurrencyCodeEnum.USD => purchaseLimit.IsUsdLimit(totalAmount),
                (int)CurrencyCodeEnum.BRL => purchaseLimit.IsBrlLimit(totalAmount),
                _ => false
            };

        private PurchaseTransaction FillTransactionData(ExchangeRate rates, PurchaseDTO purchase)
        {
            var transaction = new PurchaseTransaction();

            transaction = _unitOfWork.PurchaseTransactions.FillTransactionRatesByExchangeRate(transaction, rates);

            transaction.PurchasedAmount = _rateConversion.BuyCurrency(rates.Sell, purchase.Amount);

            transaction.Amount = purchase.Amount;

            transaction.IdPerson = purchase.IdUser;

            return transaction;
        }
    }
}
