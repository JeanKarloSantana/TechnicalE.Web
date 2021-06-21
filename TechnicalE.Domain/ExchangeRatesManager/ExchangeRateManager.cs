using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Domain.Business;
using TechnicalE.Entities;
using TechnicalE.Entities.ApiUrl;
using TechnicalE.Entities.DTO;
using TechnicalE.Entities.Enums;
using TechnicalE.Interfaces;
using TechnicalE.Interfaces.Generic;
using TechnicalE.Interfaces.Services;

namespace TechnicalE.Domain.ExchangeRatesManager
{
    public class ExchangeRateManager : IExchangeRateManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessagesService _errorMessage;
        private readonly IExchangeRateService _exchangeRate;
        private readonly IFormatNumbers _formatNumbers;
        private readonly IProvinceBankRate _provinceBankRate;
        private readonly ApiUrl _apiUrl;

        public ExchangeRateManager(
            IUnitOfWork unitOfWork,
            IMessagesService errorMessage,
            IExchangeRateService exchangeRate,
            IFormatNumbers formatNumbers,
            IProvinceBankRate provinceBankRate)
        {
            _unitOfWork = unitOfWork;
            _errorMessage = errorMessage;
            _exchangeRate = exchangeRate;
            _formatNumbers = formatNumbers;
            _provinceBankRate = provinceBankRate;
            _apiUrl = new ApiUrl();
        }

        //This method retrieve the rates from the API, format the data and return it.
        public async Task<ResponseDTO<RatesDTO>> ExchangeRateHandler(string code)
        {
            var response = new ResponseDTO<RatesDTO>();

            int idCurrency = await _unitOfWork.Currencies.GetCurrencyIdByIsoCode(code);

            response = GetExchangeRates(code, idCurrency, response);

            if (!response.Succeeded) return response;            

            response.Data = _provinceBankRate.GetCurrencyRate(idCurrency, response.Data);

            response.Data = FormatProvinceBankRates(response.Data);

            return response;            
        }

        //This method return the data from an API
        private ResponseDTO<RatesDTO> GetExchangeRates(string code, int idCurrency, ResponseDTO<RatesDTO> response)
        {
            switch (idCurrency)
            {
                case (int)CurrencyCodeEnum.USD:
                case (int)CurrencyCodeEnum.BRL:
                    return _exchangeRate.GetProvinceBankApiRate(_apiUrl._provinceBankUrl);

                default:
                    return _errorMessage.InvalidCurrencyIsoCode(response, code);
            }
        }

        //This method take a decimal number and return it with only two numbers after the dot
        private RatesDTO FormatProvinceBankRates(RatesDTO responseData)
        {            
            responseData.Buy = _formatNumbers.FormatDecimalTwoDigits(responseData.Buy);
            responseData.Sell = _formatNumbers.FormatDecimalTwoDigits(responseData.Sell);

            return responseData;
        }

        public async Task<ResponseDTO<RatesDTO>> UpdateRates()
        {
            IEnumerable<Currency> currencies = await _unitOfWork.Currencies.GetAllAsync();
            
            ResponseDTO<RatesDTO> response = _exchangeRate.GetApiRateForUpdate(_apiUrl._provinceBankUrl);

            foreach (Currency currency in currencies)
            {
                response.Data = ValidateAddOrUpdateCurrency(currency.Id, response.Data);               

                if (!response.Succeeded)
                    return response;                   
            }
            
            return _errorMessage.UpdateCurrenciesRates(response);
        }

        //This method take a currency, if it is a valid one, will update or add the rate in the DB
        public RatesDTO ValidateAddOrUpdateCurrency(int idCurrency, RatesDTO rates) 
        {
            rates = _provinceBankRate.GetCurrencyRate(idCurrency, rates);
            
            if (rates.Validation)
            {
                ExchangeRate newExchangeRate = _unitOfWork.ExchangeRates.CreateExchangeRate(rates, idCurrency);
                _unitOfWork.ExchangeRates.AddOrUpdateRate(newExchangeRate);
            }

            return rates;
        }
    }
}
