using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarioSamisonExamenASP.Entities
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string Color { get; set; }
        public DateTime DateBought { get; set; }
        public string LicensePlate { get; set; }
        public virtual CarOwner CarOwner { get; set; }
        public virtual Cartype CarType { get; set; }
    }
}
