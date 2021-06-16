using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TechnicalE.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        public int IdCountry { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<ExchangeRate> ExchangeRatesFrom { get; set; }
        public ICollection<ExchangeRate> ExchangeRatesTo { get; set; }
        public Country Country { get; set; }
    }
}
