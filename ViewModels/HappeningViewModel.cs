using System;
using Terminarz.Models;

namespace Terminarz.ViewModels
{
    public class HappeningViewModel
    {
        public int ID { get; set; }
        public Priority? Priority { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public AddressViewModel Address { get; set; }
    }
}
