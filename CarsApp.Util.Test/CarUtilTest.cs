using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using CarsApp.Models;
using CarsApp.Util;

namespace CarsApp.Util.Test
{
    [TestClass]
    public class CarUtilTest
    {
        [TestMethod]
        public void TestFilterCarOwnerWithoutName_NullOrEmpty()
        {
            List<CarOwner> emptyCarOwner = new List<CarOwner>();

            var result = CarUtil.FilterCarOwnerWithoutName(null);
            Assert.IsNull(result);

            result = CarUtil.FilterCarOwnerWithoutName(emptyCarOwner);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void TestFilterCarOwnerWithoutName_Actual()
        {
            List<CarOwner> carOwners = SampleCarOwners_TwoValidTwoInvalid();

            var result = CarUtil.FilterCarOwnerWithoutName(carOwners);
            Assert.AreEqual(2, result.Count());
            Assert.AreNotEqual(result.Count(), carOwners.Count);
        }

        [TestMethod]
        public void ConvertToCarsList_NullOrEmpty()
        {
            List<CarOwner> emptyCarOwner = new List<CarOwner>();

            var result = CarUtil.ConvertToCarsList(null);
            Assert.IsNull(result);

            result = CarUtil.ConvertToCarsList(emptyCarOwner);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void ConvertToCarsList_Actual()
        {
            // Prepare
            List<CarOwner> carOwners = SampleCarOwners_OneValid();
            CarOwner owner = carOwners.First();
            var oriCar = owner.Cars.First();
            string expectedName = owner.Name;
            string brand = oriCar.Brand;
            string colour = oriCar.Colour;

            // Process
            var result = CarUtil.ConvertToCarsList(carOwners);
            
            // Assert cars owner property is set and other properties remain unchanged
            foreach (var car in result)
            {
                // Assigned owner name
                Assert.AreEqual(expectedName, car.Owner);

                // No changes to brand and colour
                Assert.AreEqual(brand, car.Brand);
                Assert.AreEqual(colour, car.Colour);
            }
        }

        [TestMethod]
        public void ConvertToBrandOwnerDedupe_NullOrEmpty()
        {
            List<CarOwner> emptyCarOwner = new List<CarOwner>();

            var result = CarUtil.ConvertToCarsList(null);
            Assert.IsNull(result);

            result = CarUtil.ConvertToCarsList(emptyCarOwner);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void ConvertToBrandOwnerDedupe_Actual()
        {
            // Prepare
            List<CarInfo> cars = SampleCarsWithOwner();

            // Process
            var result = CarUtil.ConvertToBrandOwnerDedupe(cars);

            // Assert sorting
            var resultList = result.ToList();
            Assert.AreEqual("BMW", resultList[0].Brand);
            Assert.AreEqual("Jaguar", resultList[1].Brand);
            Assert.AreEqual("Merc", resultList[2].Brand);

            // Assert grouping count
            Assert.AreEqual(2, resultList[0].Owners.Count()); // BMW = 2 (dedupe Supergirl
            Assert.AreEqual(1, resultList[1].Owners.Count()); // BMW = 2 (dedupe Supergirl
            Assert.AreEqual(2, resultList[2].Owners.Count()); // BMW = 2 (dedupe Supergirl
        }

        #region Test Data

        private List<Car> SampleLuxuryCarsNoOwner()
        {
            List<Car> cars = new List<Car>
            {
                new Car { Brand = "Merc", Colour = "White" },
                new Car { Brand = "BMW", Colour = "Red" },
                new Car { Brand = "Jaguar", Colour = "Black" }
            };

            return cars;
        }

        private List<Car> SampleFamilyCarsNoOwner()
        {
            List<Car> cars = new List<Car>
            {
                new Car { Brand = "Toyota", Colour = "Blue" },
                new Car { Brand = "Honda", Colour = "" }
            };

            return cars;
        }

        private List<CarInfo> SampleCarsWithOwner()
        {
            List<CarInfo> cars = new List<CarInfo>
            {
                new CarInfo { Brand = "Merc", Colour = "White", Owner = "Crazy dude" },
                new CarInfo { Brand = "BMW", Colour = "Red" },
                new CarInfo { Brand = "Jaguar", Colour = "Black", Owner = "Samurai" },
                new CarInfo { Brand = "BMW", Colour = "Blue", Owner = "Supergirl" },
                new CarInfo { Brand = "BMW", Colour = "Orange", Owner = "Supergirl" },
                new CarInfo { Brand = "Merc", Colour = "Black", Owner = "Samurai" }
            };

            return cars;
        }

        private List<Car> OneFamilyCar()
        {
            List<Car> cars = new List<Car>
            {
                new Car { Brand = "Toyota", Colour = "Blue" }
            };

            return cars;
        }

        private List<CarOwner> SampleCarOwners_OneValid()
        {
            List<CarOwner> carOwners = new List<CarOwner>
            {
                new CarOwner { Name = "John", Cars = OneFamilyCar() }
            };

            return carOwners;
        }

        private List<CarOwner> SampleCarOwners_TwoValidTwoInvalid()
        {
            List<CarOwner> carOwners = new List<CarOwner>
            {
                new CarOwner { Name = "John", Cars = SampleFamilyCarsNoOwner() },
                new CarOwner { Name = "", Cars = SampleFamilyCarsNoOwner() },
                new CarOwner { Name = "Paul", Cars = SampleLuxuryCarsNoOwner() },
                new CarOwner { Cars = SampleLuxuryCarsNoOwner() }
            };

            return carOwners;
        }

        #endregion
    }
}
