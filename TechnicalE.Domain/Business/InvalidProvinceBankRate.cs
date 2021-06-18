using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalE.Entities.DTO;

namespace TechnicalE.Domain.Business
{
    public class InvalidProvinceBankRate : RatesDTO
    {
        public InvalidProvinceBankRate(RatesDTO rates)
        {
            Buy = rates.Buy;
            Sell = rates.Sell;            
            Updated = rates.Updated;
            Validation = false;
        }
    }    
}
