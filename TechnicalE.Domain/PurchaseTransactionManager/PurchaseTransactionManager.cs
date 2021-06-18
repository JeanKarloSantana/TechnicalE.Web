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
        private readonly IErrorMessageService _errorMessage;
        private readonly IExchangeRateService _exchangeService;
        private readonly IRateConversionService _rateConversion;

        public PurchaseTransactionManager(IUnitOfWork unitOfWork, 
            IErrorMessageService errorMessage, 
            IExchangeRateService exchangeService,
            IRateConversionService rateConversion) 
        {
            _unitOfWork = unitOfWork;
            _errorMessage = errorMessage;
            _exchangeService = exchangeService;
            _rateConversion = rateConversion;
        }

        public async Task<ResponseDTO<PurchaseTransaction>> CurrencyPurchaseHandler(PurchaseDTO purchase) 
        {
            var transaction = new PurchaseTransaction();

            ExchangeRate rates = _unitOfWork.ExchangeRates.GetExchangeRateByCurrencies((int)CurrencyCodeEnum.ARS, await _unitOfWork.Currencies.GetCurrencyIdByCode(purchase.Code));

            transaction = _unitOfWork.PurchaseTransactions.FillTransactionRatesByExchangeRate(transaction, rates);

            transaction.PurchasedAmount = _rateConversion.BuyCurrency(rates.Sell, purchase.Amount);

            transaction.Amount = purchase.Amount;

            transaction.IdPerson = purchase.IdUser;            
            
            decimal totalAmount = transaction.PurchasedAmount + await _unitOfWork.PurchaseTransactions.GetCurrentMonthPurchasedAmount(purchase.IdUser, rates.Id);
                        
            var purchaseLimit = new CurrencyPurchaseLimit();

            var response = new ResponseDTO<PurchaseTransaction>();

            response.Data = transaction;

            if (!CheckPurchaseLimit(totalAmount, rates.IdToCurrency, purchaseLimit)) return _errorMessage.PurchaseLimitReached(response);
            
            _unitOfWork.PurchaseTransactions.AddTransaction(transaction);
            
            _unitOfWork.Complete();
            
            return _errorMessage.PurchaseTransaction(response, await _unitOfWork.Currencies.GetCurrencyNameByCode(purchase.Code));
        }

        public bool CheckPurchaseLimit(decimal totalAmount, int idCurrency, CurrencyPurchaseLimit purchaseLimit) =>
            idCurrency switch
            {
                (int)CurrencyCodeEnum.USD => purchaseLimit.IsUsdLimit(totalAmount),
                (int)CurrencyCodeEnum.BRL => purchaseLimit.IsBrlLimit(totalAmount),
                _ => false
            };
    }
}
