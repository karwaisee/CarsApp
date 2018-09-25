using System.Collections.Generic;
using System.Linq;
using CarsApp.Models;

namespace CarsApp.Util
{
    public class CarUtil
    {
        /// <summary>
        /// Filter off car owner without name
        /// </summary>
        /// <param name="carOwners">Enumerable of car owners</param>
        /// <returns>IEnumerable of car owners with name</returns>
        public static IEnumerable<CarOwner> FilterCarOwnerWithoutName(IEnumerable<CarOwner> carOwners)
        {
            if (carOwners == null)
                return null;

            IEnumerable<Models.CarOwner> carOwnersWithNames = carOwners.Where(owner => owner.Name != null && owner.Name.Length > 0).ToList();
            
            return carOwnersWithNames;
        }

        /// <summary>
        /// Convert list of car owners (with list of cars) into list of cars (with its owner property)
        /// </summary>
        /// <param name="carOwners">Enumerable of car owners</param>
        /// <returns>IEnumerable of cars</returns>
        public static IEnumerable<CarInfo> ConvertToCarsList(IEnumerable<CarOwner> carOwners)
        {
            if (carOwners == null)
                return null;

            // Convert list of list into flat list, maintaining the correct property
            IEnumerable<CarInfo> cars = carOwners
                .SelectMany(o => o.Cars, (owner, car) => new CarInfo { Brand = car.Brand, Colour = car.Colour, Owner = owner.Name });
                
            return cars;
        }

        /// <summary>
        /// Convert list of cars into list of car brands (with its own property)
        /// </summary>
        /// <param name="cars">Enumerable of cars</param>
        /// <returns>Enumerable of car brands and its car owner</returns>
        public static IEnumerable<BrandOwner> ConvertToBrandOwnerDedupe(IEnumerable<CarInfo> cars)
        {
            if (cars == null)
                return null;

            IEnumerable<string> brands = cars
                .Select(x => x.Brand)
                .Distinct()
                .OrderBy(x => x).ToList();
            List<BrandOwner> brandOwners = new List<BrandOwner>();

            foreach(string brd in brands)
            {
                IEnumerable<string> owners = cars
                    .Where(x => x.Brand == brd)
                    .OrderBy(x => x.Colour)
                    .Select(x => x.Owner)
                    .Distinct().ToList();
                brandOwners.Add(new BrandOwner { Brand = brd, Owners = owners });
            }

            return brandOwners;
        }
    }
}
