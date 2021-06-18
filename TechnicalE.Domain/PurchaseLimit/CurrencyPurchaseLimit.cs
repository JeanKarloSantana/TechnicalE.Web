using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalE.Domain.PurchaseLimit
{
    public class CurrencyPurchaseLimit
    {
        public decimal _USD { get; set; }
        public decimal _BRL { get; set; }

        public CurrencyPurchaseLimit()
        {
            _USD = 200;
            _BRL = 300;
        }

        public bool IsUsdLimit(decimal amount) => (amount <= _USD);
        public bool IsBrlLimit(decimal amount) => (amount <= _BRL);
    }
}
