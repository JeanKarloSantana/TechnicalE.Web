using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Entities.DTO;

namespace TechnicalE.Domain.Business
{
    public class BrlProvinceBankRate : RatesDTO
    {
        public BrlProvinceBankRate(RatesDTO rates)
        {
            Buy = rates.Buy / 4;
            Sell = rates.Sell / 4;            
            Updated = rates.Updated;
            Validation = true;
        }
    }
}
