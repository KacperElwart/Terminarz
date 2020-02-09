using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Terminarz.Models
{
    public class Contact
    {
        public int ID { get; set; }
        [Required]
        [StringLength(20,ErrorMessage = "Za dluga nazwa kontaktu, nie znam nikogo kto ma tak dluga ksywe")]
        public string Name { get; set; }
        [Required]
        [Range(100000000,999999999)]
        public int Phone { get; set; }
    }
}
