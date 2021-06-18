using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Entities.DTO;

namespace TechnicalE.Domain.ExchangeRatesManager
{
    public interface IExchangeRateManager
    {
        Task<ResponseDTO<RatesDTO>> ExchangeRateHandler(string code);
        Task<ResponseDTO<RatesDTO>> UpdateRates();
    }
}
