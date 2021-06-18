﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Entities;
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
        private readonly IErrorMessageService _errorMessage;
        private readonly IExchangeRateService _exchangeRate;
        private readonly IFormatNumbers _formatNumbers;

        public ExchangeRateManager(
            IUnitOfWork unitOfWork,
            IErrorMessageService errorMessage,
            IExchangeRateService exchangeRate,
            IFormatNumbers formatNumbers)
        {
            _unitOfWork = unitOfWork;
            _errorMessage = errorMessage;
            _exchangeRate = exchangeRate;
            _formatNumbers = formatNumbers;
        }

        public async Task<ResponseDTO<RatesDTO>> ExchangeRateHandler(string code)
        {
            var response = new ResponseDTO<RatesDTO>();

            int idCurrency = await _unitOfWork.Currencies.GetCurrencyIdByIsoCode(code);

            response = GetExchangeRates(code, idCurrency, response);

            if (!response.Succeeded) return response;

            response.Data = FormatProvinceBankRates(response.Data);

            return response;
        }

        private ResponseDTO<RatesDTO> GetExchangeRates(string code, int idCurrency, ResponseDTO<RatesDTO> response)
        {
            switch (idCurrency)
            {
                case (int)CurrencyCodeEnum.USD:
                case (int)CurrencyCodeEnum.BRL:
                    return _exchangeRate.GetProvinceBankApiRate(idCurrency);

                default:
                    return _errorMessage.InvalidCurrencyIsoCode(response, code);
            }
        }

        private RatesDTO FormatProvinceBankRates(RatesDTO responseData)
        {            
            responseData.Buy = _formatNumbers.FormatDecimalTwoDigits(responseData.Buy);
            responseData.Sell = _formatNumbers.FormatDecimalTwoDigits(responseData.Sell);

            return responseData;
        }

        public async Task<ResponseDTO<RatesDTO>> UpdateRates()
        {
            IEnumerable<Currency> currencies = await _unitOfWork.Currencies.GetAllAsync();
            
            ResponseDTO<RatesDTO> response = _exchangeRate.GetApiRateForUpdate();

            foreach (Currency currency in currencies)
            {
                response.Data = _exchangeRate.GetCurrencyRate(currency.Id, response.Data);

                if (response.Data.Validation)
                {
                    ExchangeRate newExchangeRate = _unitOfWork.ExchangeRates.CreateExchangeRate(response.Data, currency.Id);
                    _unitOfWork.ExchangeRates.AddOrUpdateRate(newExchangeRate);
                }

                if (!response.Succeeded)
                    return response;                    
            }
            
            return _errorMessage.UpdateCurrenciesRates(response);
        }
    }
}