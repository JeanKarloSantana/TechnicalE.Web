using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Entities;
using TechnicalE.Entities.DTO;
using TechnicalE.Interfaces.Services;

namespace TechnicalE.Services
{
    public class MessagesService : IMessagesService
    {
        public MessagesService()
        {            
        }

        public ResponseDTO<RatesDTO> UnableRetrieveRateDataFromApi(ResponseDTO<RatesDTO> response, string requestStatus)
        {
            response.Errors.Add("Unable to fulfill the request. " + requestStatus);
            response.Succeeded = false;
            response.StatusCode = 500;
            return response;
        }

        public ResponseDTO<RatesDTO> InvalidCurrencyIsoCode(ResponseDTO<RatesDTO> response, string code) 
        {            
            response.Errors.Add(code.ToUpper() + " Is not a valid currency, Please provide a different currency");
            response.Succeeded = false;
            response.StatusCode = 400;
            return response;
        }        

        public ResponseDTO<RatesDTO> UpdateCurrenciesRates(ResponseDTO<RatesDTO> response) 
        { 
            response.Message = "All currencies rates has been updated";
            response.StatusCode = 200;
            return response;
        }

        public ResponseDTO<PurchaseTransaction> PurchaseTransaction(ResponseDTO<PurchaseTransaction> response, string currencyName)
        {
            response.StatusCode = 201;
            response.Message = $"The transaction was completed successfully for a purchase of { response.Data.PurchasedAmount } { currencyName } at rate { response.Data.SellRateLog }";
            return response;
        }

        public ResponseDTO<PurchaseTransaction> PurchaseLimitReached(ResponseDTO<PurchaseTransaction> response)
        {
            response.StatusCode = 500;
            response.Errors.Add($"Cannot proceed with the transaction because will surpass this user monthly limit");
            response.Succeeded = false;
            return response;
        }

        public ResponseDTO<PurchaseTransaction> CurrencyNotAvailable(ResponseDTO<PurchaseTransaction> response, string code)
        {
            response.Errors.Add(code.ToUpper() + " Is not available for exchange, Please provide a different currency");
            response.Succeeded = false;
            response.StatusCode = 400;
            return response;
        }
    }
}
