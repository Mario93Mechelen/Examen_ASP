using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MarioSamisonExamenASP.Models;
using MarioSamisonExamenASP.Services;
using MarioSamisonExamenASP.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MarioSamisonExamenASP.Controllers
{
    public class CarController : Controller
    {

        private readonly iCarService _carService;

        public CarController(iCarService carService)
        {
            _carService = carService;
        }

        [HttpGet("/cars")]
        public IActionResult Index()
        {

            var model = new CarListViewModel { Cars = new List<CarDetailViewModel>() };
            var allCars = _carService.GetAllCars();
            model.Cars.AddRange(allCars.Select(ConvertCarToCarDetailViewModel).ToList());
            return View(model);
        }

        protected CarDetailViewModel ConvertCarToCarDetailViewModel(Car car)
        {
            return new CarDetailViewModel()
            {
                Id = car.Id,
                Color = car.Color,
                DateBought = car.DateBought,
                LicensePlate = car.LicensePlate,
                CarOwner = car.CarOwner?.FullName,
                CarTypeBrand = car.CarType?.Brand,
                CarTypeModel = car.CarType?.Model
            };
        }

        [HttpGet("/cars/{id}")]
        public IActionResult Detail([FromRoute] int id)
        {
            if (id == 0)
            {
                var newCar = new Car();
                newCar.LicensePlate = "000000";
                newCar.Color = "No Paintjob!";
                var newCar2 = ConvertCarToEditDetailViewModel(newCar);
                newCar2.CarTypes = _carService.GetAllCarTypes().Select(x => new SelectListItem
                {
                    Text = string.Join(" ", x.Brand, x.Model),
                    Value = x.Id.ToString(),
                }
            ).ToList();
                newCar2.CarOwners = _carService.GetAllCarOwners().Select(x => new SelectListItem
                {
                    Text = x.FullName,
                    Value = x.Id.ToString(),
                }
                ).ToList();
                return View(newCar2);
            }

            var car = _carService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }

            var modifiedcar = ConvertCarToEditDetailViewModel(car);
            modifiedcar.CarTypes = _carService.GetAllCarTypes().Select(x => new SelectListItem
            {
                Text = string.Join(" ", x.Brand, x.Model),
                Value = x.Id.ToString(),
            }
            ).ToList();
            modifiedcar.CarOwners = _carService.GetAllCarOwners().Select(x => new SelectListItem
            {
                Text = x.FullName,
                Value = x.Id.ToString(),
            }
            ).ToList();
            return View(modifiedcar);
        }

        public CarEditDetailViewModel ConvertCarToEditDetailViewModel(Car car)
        {
            var modifiedcar = new CarEditDetailViewModel
            {
                LicensePlate = car.LicensePlate,
                Color = car.Color,
                DateBought = car.DateBought,
                Id = car.Id
            };
            return modifiedcar;
        }

        [HttpPost("/cars")]
        public IActionResult Persist([FromForm] CarEditDetailViewModel modifiedcar)
        {
            if (ModelState.IsValid)
            {
                var car = modifiedcar.Id == 0 ? new Car() : _carService.GetCarById(modifiedcar.Id);
                car.LicensePlate = modifiedcar.LicensePlate;
                car.Color = modifiedcar.Color;
                car.DateBought = modifiedcar.DateBought;
                car.CarType = modifiedcar.CarTypeId.HasValue ? _carService.GetCarTypeById(modifiedcar.CarTypeId.Value) : null;
                car.CarOwner = modifiedcar.CarOwnerId.HasValue ? _carService.GetCarOwnerById(modifiedcar.CarOwnerId.Value) : null;
                _carService.Persist(car);

                return Redirect("/cars");
            }
            return View("Detail", modifiedcar);
        }

        [HttpPost("/cars/delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _carService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("/cartypes")]
        public IActionResult CarTypes()
        {

            var model = new CarTypeListViewModel { CarTypes = new List<CarTypeDetailViewModel>() };
            var allCarTypes = _carService.GetAllCarTypes();
            model.CarTypes.AddRange(allCarTypes.Select(ConvertCarTypeToCarTypeDetailViewModel).ToList());
            return View(model);
        }

        protected CarTypeDetailViewModel ConvertCarTypeToCarTypeDetailViewModel(Cartype carType)
        {
            return new CarTypeDetailViewModel()
            {
                Brand = carType.Brand,
                Model = carType.Model
            };
        }

        [HttpGet("/carowners")]
        public IActionResult CarOwners()
        {

            var model = new CarOwnerListViewModel { CarOwners = new List<CarOwnerDetailViewModel>() };
            var allCarOwners = _carService.GetAllCarOwners();
            model.CarOwners.AddRange(allCarOwners.Select(ConvertCarOwnerToCarOwnerDetailViewModel).ToList());
            return View(model);
        }

        protected CarOwnerDetailViewModel ConvertCarOwnerToCarOwnerDetailViewModel(CarOwner carOwner)
        {
            return new CarOwnerDetailViewModel()
            {
                FullName = carOwner.FullName
            };
        }
    }
}
