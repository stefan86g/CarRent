using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOLCarRent.ViewModels
{
    public class CarViewModel
    {
        public string Id { get; set; }
        public string Photo { get; set; }
        public string Model { get; set; }
        public string PricePerDay { get; set; }
        public string CostOfDayOverdue { get; set; }
        public string Availability { get; set; }
        public string Year { get; set; }
        public string GearBox { get; set; }
        public string Mileage { get; set; }
        public string CarNumber { get; set; }
        public string Branch { get; set; }

    }
}
