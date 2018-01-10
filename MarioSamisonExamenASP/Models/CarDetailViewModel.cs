using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarioSamisonExamenASP.Models
{
    public class CarDetailViewModel
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public DateTime DateBought { get; set; }
        public string LicensePlate { get; set; }
        public string CarOwner { get; set; }
        public string CarTypeBrand { get; set; }
        public string CarTypeModel { get; set; }
    }
}
