using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Entities.DTO;

namespace TechnicalE.Interfaces.Services
{
    public interface IErrorMessageService
    {
        ResponseDTO<RatesDTO> UnableRetrieveRateDataFromApi(ResponseDTO<RatesDTO> response, string requestStatus);
        ResponseDTO<RatesDTO> InvalidCurrencyIsoCode(ResponseDTO<RatesDTO> response, string code);
    }
}
