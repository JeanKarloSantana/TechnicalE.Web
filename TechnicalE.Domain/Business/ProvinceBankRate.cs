using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Entities.DTO;
using TechnicalE.Entities.Enums;

namespace TechnicalE.Domain.Business
{
    public class ProvinceBankRate : IProvinceBankRate 
    {
        public ProvinceBankRate() 
        {
            
        }

        public RatesDTO GetCurrencyRate(int idCurrency, RatesDTO rates) =>
            idCurrency switch
            {
                (int)CurrencyCodeEnum.USD => UsdRates(rates),
                (int)CurrencyCodeEnum.BRL => BrlRates(rates),
                _ => InvalidRate(rates)
            };

        public RatesDTO UsdRates(RatesDTO rates) => rates;
        public RatesDTO BrlRates(RatesDTO rates) 
        {
            rates.Buy /= 4;
            rates.Sell /= 4;
            rates.Validation = true;
            return rates;
        }
        public RatesDTO InvalidRate(RatesDTO rates)
        {
            rates.Validation = false;
            return rates;
        }

    }
}
