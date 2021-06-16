using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TechnicalE.Entities
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        public string ISOCode { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Currency> Currency { get; set; }
    }
}
