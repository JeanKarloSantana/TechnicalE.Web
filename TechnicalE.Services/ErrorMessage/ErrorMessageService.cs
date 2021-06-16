using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Entities.DTO;
using TechnicalE.Interfaces.Services;

namespace TechnicalE.Services
{
    public class ErrorMessageService : IErrorMessageService
    {
        public ErrorMessageService()
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
    }
}
