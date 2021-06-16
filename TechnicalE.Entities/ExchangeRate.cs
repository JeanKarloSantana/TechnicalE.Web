using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalE.Entities
{
    public class ExchangeRate
    {
        public int Id { get; set; }
        public int IdFromCurrency { get; set; }
        public int IdToCurrency { get; set; }
        public decimal Buy { get; set; }
        public decimal Sell { get; set; }
        public decimal Rate { get; set; }
        public DateTime Update { get; set; }
        public Currency CurrencyFrom { get; set; }
        public Currency CurrencyTo { get; set; }
        public ICollection<PurchaseTransaction> PurchaseTransaction { get; set; }
    }
}
