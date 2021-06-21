using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TechnicalE.Domain.Business;
using TechnicalE.Entities.DTO;
using TechnicalE.Entities.Enums;
using TechnicalE.Interfaces;

namespace TechnicalE.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        public ResponseDTO<RatesDTO> GetProvinceBankApiRate(string url) 
        {
            var response = new ResponseDTO<RatesDTO>();

            IRestResponse apiResponse = GetProvinceBankApiResponse(url);

            if (!apiResponse.IsSuccessful) 
            {
                var errors = new MessagesService();

                return errors.UnableRetrieveRateDataFromApi(response, apiResponse.StatusCode.ToString());
            }

            response.Data = new RatesDTO();

            response.Data = FormatProvinceBankResponse(JsonConvert.DeserializeObject<List<string>>(apiResponse.Content), response.Data);

            return response;                  
        }
        
        private IRestResponse GetProvinceBankApiResponse(string url)
        {
            var client = new RestClient(url);
            
            var request = new RestRequest(Method.GET);
            
            IRestResponse requestResponse = client.Execute(request);

            return requestResponse;
        }

        public RatesDTO FormatProvinceBankResponse(List<string> valuesList, RatesDTO rates)
        {
            valuesList[2] = valuesList[2].Substring(15);

            return FormatExtractedList(valuesList, rates);
        }

        private RatesDTO FormatExtractedList(List<string> valuesList, RatesDTO rates)
        {            
            rates.Buy = Convert.ToDecimal(valuesList[0]);
            rates.Sell = Convert.ToDecimal(valuesList[1]);            
            rates.Updated = Convert.ToDateTime(valuesList[2], CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);

            return rates;
        }
        
        public ResponseDTO<RatesDTO> GetApiRateForUpdate(string url)
        {
            var response = new ResponseDTO<RatesDTO>();

            IRestResponse apiResponse = GetProvinceBankApiResponse(url);

            if (!apiResponse.IsSuccessful)
            {
                var errors = new MessagesService();

                return errors.UnableRetrieveRateDataFromApi(response, apiResponse.StatusCode.ToString());
            }

            response.Data = new RatesDTO();

            response.Data = FormatProvinceBankResponse(JsonConvert.DeserializeObject<List<string>>(apiResponse.Content), response.Data);            

            return response;
        }
    }
}
