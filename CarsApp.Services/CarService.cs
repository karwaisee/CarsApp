using System.Collections.Generic;
using CarsApp.Models;

namespace CarsApp.Services
{
    public class CarService : ICarService
    {
        public IEnumerable<CarOwner> GetAllCarOwners()
        {
            //
            // Q2: Produces a replica service that returns the same results as the API provided
            //
            // Hardcoded resultset to replicate exact same result as the API provided in http://codingtest.kloud.com.au/api/cars/
            List<CarOwner> mockCarOwners = new List<CarOwner>();

            CarOwner bradley = new CarOwner
            {
                Name = "Bradley",
                Cars = new List<Car>
                {
                    new Car {Brand = "MG", Colour = "Blue"}
                }
            };
            mockCarOwners.Add(bradley);

            CarOwner demetrios = new CarOwner
            {
                Name = "Demetrios",
                Cars = new List<Car>
                {
                    new Car {Brand = "Toyota", Colour = "Green"},
                    new Car {Brand = "Holden", Colour = "Blue"}
                }
            };
            mockCarOwners.Add(demetrios);

            CarOwner brooke = new CarOwner
            {
                Name = "Brooke",
                Cars = new List<Car>
                {
                    new Car {Brand = "Holden", Colour = ""}
                }
            };
            mockCarOwners.Add(brooke);

            CarOwner kristin = new CarOwner
            {
                Name = "Kristin",
                Cars = new List<Car>
                {
                    new Car {Brand = "Toyota", Colour = "Blue"},
                    new Car {Brand = "Mercedes", Colour = "Green"},
                    new Car {Brand = "Mercedes", Colour = "Yellow"}
                }
            };
            mockCarOwners.Add(kristin);

            CarOwner andre = new CarOwner
            {
                Name = "Andre",
                Cars = new List<Car>
                {
                    new Car {Brand = "BMW", Colour = "Green"},
                    new Car {Brand = "Holden", Colour = "Black"}
                }
            };
            mockCarOwners.Add(andre);

            CarOwner nuller = new CarOwner
            {
                Cars = new List<Car>
                {
                    new Car {Brand = "Mercedes", Colour = "Blue"}
                }
            };
            mockCarOwners.Add(nuller);

            CarOwner empty = new CarOwner
            {
                Name = "",
                Cars = new List<Car>
                {
                    new Car {Brand = "Mercedes", Colour = "Red"},
                    new Car {Brand = "Mercedes", Colour = "Blue"}
                }
            };
            mockCarOwners.Add(empty);

            CarOwner matilda = new CarOwner
            {
                Name = "Matilda",
                Cars = new List<Car>
                {
                    new Car {Brand = "Holden"},
                    new Car {Brand = "BMW", Colour = "Black"}
                }
            };
            mockCarOwners.Add(matilda);

            CarOwner iva = new CarOwner
            {
                Name = "Iva",
                Cars = new List<Car>
                {
                    new Car {Brand = "Toyota", Colour = "Purple"}
                }
            };
            mockCarOwners.Add(iva);

            CarOwner nuller2 = new CarOwner
            {
                Cars = new List<Car>
                {
                    new Car {Brand = "Toyota", Colour = "Blue"},
                    new Car {Brand = "Mercedes", Colour = "Blue"}
                }
            };
            mockCarOwners.Add(nuller2);

            return mockCarOwners;
        }
    }
}
