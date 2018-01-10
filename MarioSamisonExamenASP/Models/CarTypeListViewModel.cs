using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarioSamisonExamenASP.Models
{
    public class CarTypeListViewModel
    {
        public List<CarTypeDetailViewModel> CarTypes { get; set; }
        public DateTime GeneratedAt => DateTime.Now;
    }
}
