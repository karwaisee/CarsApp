using System.Collections.Generic;
using CarsApp.Models;

namespace CarsApp.Services
{
    public interface ICarService
    {
        IEnumerable<CarOwner> GetAllCarOwners();
    }
}
