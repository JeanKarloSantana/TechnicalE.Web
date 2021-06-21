using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Entities;
using TechnicalE.Entities.DTO;

namespace TechnicalE.Interfaces.Services
{
    public interface IMessagesService
    {
        ResponseDTO<RatesDTO> UnableRetrieveRateDataFromApi(ResponseDTO<RatesDTO> response, string requestStatus);
        ResponseDTO<RatesDTO> InvalidCurrencyIsoCode(ResponseDTO<RatesDTO> response, string code);
        ResponseDTO<RatesDTO> UpdateCurrenciesRates(ResponseDTO<RatesDTO> response);
        ResponseDTO<PurchaseTransaction> PurchaseTransaction(ResponseDTO<PurchaseTransaction> response, string currencyName);
        ResponseDTO<PurchaseTransaction> PurchaseLimitReached(ResponseDTO<PurchaseTransaction> response);
        ResponseDTO<PurchaseTransaction> CurrencyNotAvailable(ResponseDTO<PurchaseTransaction> response, string code);
    }
}
