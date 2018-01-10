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
    public class CarService : iCarService
    {

        private readonly EntityContext _entityContext;

        public CarService(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        private IIncludableQueryable<Car, CarOwner> GetFullGraph()
        {
            return _entityContext.Cars.Include(x => x.CarType).Include(x => x.CarOwner);
        }

        public List<Car> GetAllCars()
        {
            return GetFullGraph().OrderBy(x => x.LicensePlate).ToList();
        }

        public Car GetCarById(int id)
        {
            return GetFullGraph()
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Cartype> GetAllCarTypes()
        {
            return _entityContext.CarTypes.OrderBy(x => x.Model).OrderBy(x => x.Brand).ToList();
        }

        public Cartype GetCarTypeById(int id)
        {
            return _entityContext.CarTypes.Find(id);
        }

        public List<CarOwner> GetAllCarOwners()
        {
            return _entityContext.CarOwners.OrderBy(x => x.FullName).ToList();
        }

        public CarOwner GetCarOwnerById(int id)
        {
            return _entityContext.CarOwners.Find(id);
        }

        public void Persist(Car car)
        {
            if (car.Id == 0)
                _entityContext.Cars.Add(car);
            else
                _entityContext.Cars.Update(car);
            _entityContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var toDelete = GetCarById(id);
            if (toDelete != null)
            {
                _entityContext.Cars.Remove(toDelete);
                _entityContext.SaveChanges();
            }
        }
    }
}
