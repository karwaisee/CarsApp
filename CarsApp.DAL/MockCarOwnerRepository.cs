using System.Collections.Generic;
using CarsApp.Models;

namespace CarsApp.DAL
{
    public class MockCarOwnerRepository : ICarOwnerRepository
    {
        public IEnumerable<CarOwner> GetCarOwners()
        {
            //
            // Q2: Produces a replica service that returns the same results as the API provided
            //
            // Hardcoded resultset to replicate exact same result as the API provided in http://codingtest.kloud.com.au/api/cars/
            List<CarOwner> mockCarOwners = new List<CarOwner>();
            mockCarOwners.Add(MockBradley());
            mockCarOwners.Add(MockDemetrios());
            mockCarOwners.Add(MockBrooke());
            mockCarOwners.Add(MockKristin());
            mockCarOwners.Add(MockAndre());
            mockCarOwners.Add(MockNuller1());
            mockCarOwners.Add(MockEmpty());
            mockCarOwners.Add(MockMatilda());
            mockCarOwners.Add(MockIva());
            mockCarOwners.Add(MockNuller2());

            return mockCarOwners;
        }

        private CarOwner MockBradley()
        {
            return new CarOwner
            {
                Name = "Bradley",
                Cars = new List<Car>
                {
                    new Car {Brand = "MG", Colour = "Blue"}
                }
            };
        }

        private CarOwner MockDemetrios()
        {
            return new CarOwner
            {
                Name = "Demetrios",
                Cars = new List<Car>
                {
                    new Car {Brand = "Toyota", Colour = "Green"},
                    new Car {Brand = "Holden", Colour = "Blue"}
                }
            };
        }

        private CarOwner MockBrooke()
        {
            return new CarOwner
            {
                Name = "Brooke",
                Cars = new List<Car>
                {
                    new Car {Brand = "Holden", Colour = ""}
                }
            };
        }

        private CarOwner MockKristin()
        {
            return new CarOwner
            {
                Name = "Kristin",
                Cars = new List<Car>
                {
                    new Car {Brand = "Toyota", Colour = "Blue"},
                    new Car {Brand = "Mercedes", Colour = "Green"},
                    new Car {Brand = "Mercedes", Colour = "Yellow"}
                }
            };
        }

        private CarOwner MockAndre()
        {
            return new CarOwner
            {
                Name = "Andre",
                Cars = new List<Car>
                {
                    new Car {Brand = "BMW", Colour = "Green"},
                    new Car {Brand = "Holden", Colour = "Black"}
                }
            };
        }

        private CarOwner MockNuller1()
        {
            return new CarOwner
            {
                Cars = new List<Car>
                {
                    new Car {Brand = "Mercedes", Colour = "Blue"}
                }
            };
        }

        private CarOwner MockEmpty()
        {
            return new CarOwner
            {
                Name = "",
                Cars = new List<Car>
                {
                    new Car {Brand = "Mercedes", Colour = "Red"},
                    new Car {Brand = "Mercedes", Colour = "Blue"}
                }
            };
        }

        private CarOwner MockMatilda()
        {
            return new CarOwner
            {
                Name = "Matilda",
                Cars = new List<Car>
                {
                    new Car {Brand = "Holden"},
                    new Car {Brand = "BMW", Colour = "Black"}
                }
            };
        }

        private CarOwner MockIva()
        {
            return new CarOwner
            {
                Name = "Iva",
                Cars = new List<Car>
                {
                    new Car {Brand = "Toyota", Colour = "Purple"}
                }
            };
        }

        private CarOwner MockNuller2()
        {
            return new CarOwner
            {
                Cars = new List<Car>
                {
                    new Car {Brand = "Toyota", Colour = "Blue"},
                    new Car {Brand = "Mercedes", Colour = "Blue"}
                }
            };
        }
    }
}
