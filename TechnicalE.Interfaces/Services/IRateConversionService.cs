using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalE.Interfaces.Services
{
    public interface IRateConversionService
    {
       decimal BuyCurrency(decimal sellRate, decimal amount) => amount / sellRate;
       decimal SellCurrency(decimal buyRate, decimal amount) => amount * buyRate;
    }
}
