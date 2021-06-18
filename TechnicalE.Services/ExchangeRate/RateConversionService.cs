using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Interfaces.Services;

namespace TechnicalE.Services.ExchangeRate
{
    public class RateConversionService : IRateConversionService
    {
        public decimal BuyCurrency(decimal sellRate, decimal amount) => amount / sellRate;
        public decimal SellCurrency(decimal buyRate, decimal amount) => amount * buyRate;
    }
}
