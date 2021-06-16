using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TechnicalE.Domain.Business;
using TechnicalE.Entities.DTO;
using TechnicalE.Entities.Enums;
using TechnicalE.Interfaces;

namespace TechnicalE.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly string _urlProvinceBank;
        private readonly string _urlThirdParty;

        public ExchangeRateService() 
        {
            _urlProvinceBank = "http://www.bancoprovincia.com.ar/Principal/Dolar";
            _urlThirdParty = "To retrieve from a third party Api";
        }

        public ResponseDTO<RatesDTO> GetProvinceBankApiRate(int idCurrency) 
        {
            var response = new ResponseDTO<RatesDTO>();

            IRestResponse apiResponse = GetProvinceBankApiResponse();

            if (!apiResponse.IsSuccessful) 
            {
                var errors = new ErrorMessageService();

                return errors.UnableRetrieveRateDataFromApi(response, apiResponse.StatusCode.ToString());
            }

            response.Data = new RatesDTO();

            response.Data = FormatProvinceBankResponse(apiResponse.Content, response.Data);

            response.Data = GetCurrencyRate(idCurrency, response.Data);

            return response;            
        }
        
        private IRestResponse GetProvinceBankApiResponse()
        {
            var client = new RestClient(_urlProvinceBank);
            
            var request = new RestRequest(Method.GET);
            
            IRestResponse requestResponse = client.Execute(request);

            return requestResponse;
        }

        private RatesDTO FormatProvinceBankResponse(string responseValue, RatesDTO rates)
        {
            responseValue += ",";
            var valuesList = new List<string>();
            string valueToFormat = string.Empty;

            foreach (Char charValue in responseValue)
            {
                if (Char.IsDigit(charValue) || charValue == '.' || charValue == '/' || charValue == ':')
                    valueToFormat += charValue;

                if (charValue == ',' || charValue == '/')
                {
                    valuesList.Add(valueToFormat);
                    valueToFormat = string.Empty;
                }
            }
            return FormatExtractedList(valuesList, rates);
        }

        private RatesDTO FormatExtractedList(List<string> valuesList, RatesDTO rates)
        {            
            rates.Buy = Convert.ToDecimal(valuesList[0]);
            rates.Sell = Convert.ToDecimal(valuesList[1]);
            valuesList[4] = valuesList[4].Insert(4, " ");
            string formatDate = valuesList[3] + valuesList[2] + valuesList[4];
            rates.Updated = Convert.ToDateTime(formatDate);

            return rates;
        }

        private RatesDTO GetCurrencyRate(int idCurrency, RatesDTO rates) =>
            idCurrency switch
            {
                (int)CurrencyCodeEnum.USD => new UsdProvinceBankRate(rates),
                (int)CurrencyCodeEnum.BRL => new BrlProvinceBankRate(rates),
                _ => rates = null
            };
    }
}
