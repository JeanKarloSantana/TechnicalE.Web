using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.DAL.SQL;
using TechnicalE.Entities;
using TechnicalE.Entities.DTO;
using TechnicalE.Entities.Enums;
using TechnicalE.Interfaces;
using TechnicalE.Persistance.Generic;

namespace TechnicalE.Persistance
{
    public class ExchangeRateRepository : BaseRepository<ExchangeRate>, IExchangeRateRepository
    {
        public TechnicalEvDbContext _context { get { return context; } }

        public ExchangeRateRepository(TechnicalEvDbContext dbContext) : base(dbContext)
        {
        }

        public ExchangeRate CreateExchangeRate(RatesDTO rateData, int idToCurrency)
        {
            var newRateData = new ExchangeRate();
            newRateData.IdFromCurrency = (int)CurrencyCodeEnum.ARS;
            newRateData.IdToCurrency = idToCurrency;
            newRateData.Buy = rateData.Buy;
            newRateData.Sell = rateData.Sell;
            newRateData.Update = rateData.Updated;

            return newRateData;
        }

        public int GetExchangeRateId(int idFromCurrency, int idToCurrency) => _context.ExchangeRate
            .Where(e => e.IdFromCurrency == idFromCurrency
                && e.IdToCurrency == idToCurrency)
            .Select(e => e.Id)
            .FirstOrDefault();

        public ExchangeRate GetExchangeRateByCurrencies(int idFromCurrency, int idToCurrency) => _context.ExchangeRate
            .Where(e => e.IdFromCurrency == idFromCurrency
                && e.IdToCurrency == idToCurrency)            
            .FirstOrDefault();

        public void AddOrUpdateRate(ExchangeRate newRateData)
        {
            ExchangeRate exchangeRateToUpdate = Get(GetExchangeRateId(newRateData.IdFromCurrency, newRateData.IdToCurrency));

            if (exchangeRateToUpdate == null)
            {
                AddExchangeRate(newRateData);
                return;
            }

            UpdateRate(newRateData, exchangeRateToUpdate);
        }

        public void AddExchangeRate(ExchangeRate newRateData)
        {
            var newExchangeRate = new ExchangeRate();

            newExchangeRate.IdFromCurrency = newRateData.IdFromCurrency;
            newExchangeRate.IdToCurrency = newRateData.IdToCurrency;
            newExchangeRate.Buy = newRateData.Buy;
            newExchangeRate.Sell = newRateData.Sell;
            newExchangeRate.Update = Convert.ToDateTime(newRateData.Update);

            Add(newExchangeRate);
        }

        public void UpdateRate(ExchangeRate newRateData, ExchangeRate rateToUpdate)
        {
            rateToUpdate.Buy = newRateData.Buy;
            rateToUpdate.Sell = newRateData.Sell;
            rateToUpdate.Update = Convert.ToDateTime(newRateData.Update);
        } 
    }
}
