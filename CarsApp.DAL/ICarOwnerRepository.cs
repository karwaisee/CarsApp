using System.Collections.Generic;
using CarsApp.Models;

namespace CarsApp.DAL
{
    public interface ICarOwnerRepository
    {
        IEnumerable<CarOwner> GetCarOwners();
    }
}
