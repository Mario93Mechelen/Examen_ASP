using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarioSamisonExamenASP.Models
{
    public class CarOwnerListViewModel
    {
        public List<CarOwnerDetailViewModel> CarOwners { get; set; }
        public DateTime GeneratedAt => DateTime.Now;
    }
}
