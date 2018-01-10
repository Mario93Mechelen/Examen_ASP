using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarioSamisonExamenASP.Models
{
    public class CarListViewModel
    {
        public List<CarDetailViewModel> Cars { get; set; }
        public DateTime GeneratedAt => DateTime.Now;
    }
}
