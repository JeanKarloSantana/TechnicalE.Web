using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalE.Entities.DTO
{
    public class PurchaseDTO
    {
        public int IdUser { get; set; }
        public string Code { get; set; }
        public decimal Amount { get; set; }
    }
}
