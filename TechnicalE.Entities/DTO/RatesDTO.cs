using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalE.Entities.DTO
{
    public class RatesDTO
    {
        public decimal Buy { get; set; }
        public decimal Sell { get; set; }
        public decimal Rate { get; set; }
        public DateTime Updated { get; set; }
    }
}
