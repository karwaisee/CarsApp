using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsApp.Services
{
    public interface ICarService
    {
        Task<IEnumerable<Models.CarOwner>> GetCarOwners();
    }
}
