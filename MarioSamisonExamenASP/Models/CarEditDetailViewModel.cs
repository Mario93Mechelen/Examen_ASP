using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarioSamisonExamenASP.Models
{
    public class CarEditDetailViewModel
    {
        [Required]
        public string LicensePlate { get; set; }
        public string Color { get; set; }
        public DateTime DateBought { get; set; }
        public int Id { get; set; }
        public string CarType { get; set; }
        public int? CarTypeId { get; set; }
        public string CarOwner { get; set; }
        public int? CarOwnerId { get; set; }
        public List<SelectListItem> CarOwners { get; set; }
        public List<SelectListItem> CarTypes { get; set; }
    }
}
