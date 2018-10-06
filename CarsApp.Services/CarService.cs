using System.Collections.Generic;
using CarsApp.Models;
using CarsApp.DAL;

namespace CarsApp.Services
{
    public class CarService : ICarService
    {
        private readonly ICarOwnerRepository _carOwnerRepository;

        public CarService(ICarOwnerRepository carOwnerRepository)
        {
            _carOwnerRepository = carOwnerRepository;
        }

        public IEnumerable<CarOwner> GetCarOwners()
        {
            return _carOwnerRepository.GetCarOwners();
        }
    }
}
