using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Entities.DTO;

namespace TechnicalE.Domain.Business
{
    public class UsdProvinceBankRate : RatesDTO
    {
        public UsdProvinceBankRate(RatesDTO rates)
        {
            Buy = rates.Buy;
            Sell = rates.Sell;
            Rate = 1 / rates.Sell;
            Updated = rates.Updated;
        }
    }
}
