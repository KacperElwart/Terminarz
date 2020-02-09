using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Terminarz.Models
{
    public enum Priority { Low,Medium,High };
    public class Happening
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Required]
        [Display(Name ="Priorytet")]
        public Priority? Priority { get; set; }
        
        [Required]
        [Display(Name = "Czas rozpoczecia")]
        public DateTime StartTime { get; set; }
        [Display(Name = "Czas zakonczenia")]
        public DateTime EndTime { get; set; }
       
        public string Description { get; set; }
        [Display(Name = "Address")]
        public int AddressID { get; set; }
        public Address Address { get; set; }
    }
}
