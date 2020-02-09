using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Terminarz.Models
{
    public class Address
    {
        public int ID { get; set; }
        [StringLength(30, ErrorMessage = "Nazwa ulicy za dluga")]
        [Display(Name = "Ulica")]
        public string Street { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Nazwa miasta za dluga")]
        [Display(Name = "Miasto")]
        public string City { get; set; }
        [Required]
        [RegularExpression(@"[0-9]{2}\-[0-9]{3}", ErrorMessage ="Kod pocztowy musi byc XX-XXX gdzie X to liczba naturalna")]
        [Display(Name = "Kod pocztowy")]
        public string PostCode { get; set; }
        [Display(Name = "Numer domu/mieszkania")]
        [StringLength(8, ErrorMessage = "Nieprawidlowy numer")]
        public string Number { get; set; }
        public IEnumerable<Happening> Happenings { get; set; }

        public string DisplayAddress => this.City + " " + this.Street + " " + this.Number;
        public override string ToString()
        {
            return City + " " + Street + " " + Number;
        }
    }
}
