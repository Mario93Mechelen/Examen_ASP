using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarioSamisonExamenASP.Entities;

namespace MarioSamisonExamenASP.Data
{
    public class DatabaseInitializer
    {

        public static void InitializeDatabase(EntityContext entityContext)
        {
            if (entityContext.Database.EnsureCreated()) { 

            //create data
            var cartypes = new List<Cartype>
            {
                new Cartype() {Brand = "opel", Model = "astra"},
                new Cartype() {Brand = "opel", Model = "lepo"},
                new Cartype() {Brand = "mercedes", Model = "sterretje"},
                new Cartype() {Brand = "mercedes", Model = "metwielen"},
                new Cartype() {Brand = "feraari", Model = "Gallardo"},
                new Cartype() {Brand = "porsj", Model = "auto"}
            };
                
            var owners = new List<CarOwner>
            {
                new CarOwner() {FirstName = "Mario", LastName = "Samison"},
                new CarOwner() {FirstName = "Roel", LastName = "Ennogiets"},
                new CarOwner() {FirstName = "Louis", LastName = "Tobback"},
                new CarOwner() {FirstName = "Joseph", LastName = "Akpala"},
            };


                var cars = new List<Car>();

                cars.Add(new Car { Color = "Grey", DateBought = Convert.ToDateTime("2010-10-12"), LicensePlate = "1-KBM-588", CarOwner = owners[0], CarType = cartypes[0] });
                cars.Add(new Car { Color = "Red", DateBought = Convert.ToDateTime("2005-04-28"), LicensePlate = "1-HCP-481", CarOwner = owners[1], CarType = cartypes[2] });
                cars.Add(new Car { Color = "Black", DateBought = Convert.ToDateTime("1991-12-27"), LicensePlate = "1-GDT-548", CarOwner = owners[1], CarType = cartypes[5] });
                cars.Add(new Car { Color = "Red", DateBought = Convert.ToDateTime("2017-04-08"), LicensePlate = "1-HSY-688", CarOwner = owners[3], CarType = cartypes[3] });
                cars.Add(new Car { Color = "Yellow", DateBought = Convert.ToDateTime("2006-02-11"), LicensePlate = "1-TSY-471", CarOwner = owners[2], CarType = cartypes[0] });
                cars.Add(new Car { Color = "Green", DateBought = Convert.ToDateTime("2000-10-15"), LicensePlate = "1-GTS-456", CarOwner = owners[3], CarType = cartypes[1] });
                cars.Add(new Car { Color = "White", DateBought = Convert.ToDateTime("2007-05-29"), LicensePlate = "1-ABC-123", CarOwner = owners[2], CarType = cartypes[4] });
                cars.Add(new Car { Color = "White", DateBought = Convert.ToDateTime("2015-07-17"), LicensePlate = "1-KIP-069", CarOwner = owners[1], CarType = cartypes[0] });
                cars.Add(new Car { Color = "Blue", DateBought = Convert.ToDateTime("2016-11-02"), LicensePlate = "1-HOH-541", CarOwner = owners[0], CarType = cartypes[1] });
                cars.Add(new Car { Color = "Black", DateBought = Convert.ToDateTime("2010-06-24"), LicensePlate = "1-PIS-561", CarOwner = owners[3], CarType = cartypes[5] });


            //add newly created test data to database and save
            entityContext.CarTypes.AddRange(cartypes);
            entityContext.Cars.AddRange(cars);
            entityContext.CarOwners.AddRange(owners);
            entityContext.SaveChanges();

            
        }
            else
            {
                //do nothing
            }
        }
    }
}
