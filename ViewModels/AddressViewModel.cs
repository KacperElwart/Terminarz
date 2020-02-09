using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Terminarz.ViewModels
{
    public class AddressViewModel
    {
        public int ID { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Street { get; set; }

        public string Number { get; set; }

    }
}
