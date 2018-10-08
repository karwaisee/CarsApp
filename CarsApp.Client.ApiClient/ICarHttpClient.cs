using System.Collections.Generic;
using System.Threading.Tasks;
using CarsApp.Models;

namespace CarsApp.Client.ApiClient
{
    public interface ICarHttpClient
    {
        Task<IEnumerable<CarOwner>> GetCarOwners();
    }
}
