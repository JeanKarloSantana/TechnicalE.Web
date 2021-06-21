using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Entities.DTO;

namespace TechnicalE.Domain.Business
{
    public interface IProvinceBankRate
    {
        RatesDTO UsdRates(RatesDTO rates);
        RatesDTO BrlRates(RatesDTO rates);
        RatesDTO InvalidRate(RatesDTO rates);
        RatesDTO GetCurrencyRate(int idCurrency, RatesDTO rates);
    }
}
