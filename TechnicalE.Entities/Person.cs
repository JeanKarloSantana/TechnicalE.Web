using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TechnicalE.Entities
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public User User { get; set; }        
        public ICollection<PurchaseTransaction> PurchaseTransaction { get; set; }        
    }
}
