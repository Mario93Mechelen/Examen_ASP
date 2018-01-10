using System.Linq;
using System.Threading.Tasks;
using MarioSamisonExamenASP.Entities;
using MarioSamisonExamenASP.Data;
using MarioSamisonExamenASP.Services;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MarioSamisonExamenASP.Services
{
    public interface iCarService
    {
        List<Car> GetAllCars();
        Car GetCarById(int id);
        void Persist(Car car);
        void Delete(int id);
        List<Cartype> GetAllCarTypes();
        Cartype GetCarTypeById(int id);
        List<CarOwner> GetAllCarOwners();
        CarOwner GetCarOwnerById(int id);
    }
}
