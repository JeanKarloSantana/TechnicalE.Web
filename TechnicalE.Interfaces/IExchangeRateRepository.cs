using System;
using System.Collections.Generic;
using System.Text;
using TechnicalE.Entities;
using TechnicalE.Entities.DTO;
using TechnicalE.Interfaces.Generic;

namespace TechnicalE.Interfaces
{
    public interface IExchangeRateRepository : IBaseRepository<ExchangeRate>
    {
        ExchangeRate CreateExchangeRate(RatesDTO rateData, int idToCurrency);
        void AddOrUpdateRate(ExchangeRate rateData);
        ExchangeRate GetExchangeRateByCurrencies(int idFromCurrency, int idToCurrency);
    }
}
