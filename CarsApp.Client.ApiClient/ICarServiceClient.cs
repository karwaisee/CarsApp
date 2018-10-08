using System.Collections.Generic;
using System.Threading.Tasks;
using CarsApp.Models;

namespace CarsApp.Client.ApiClient
{
    public interface ICarServiceClient
    {
        Task<IEnumerable<CarOwner>> GetCarOwners();
        IEnumerable<CarOwner> FilterCarOwnerWithoutName(IEnumerable<CarOwner> carOwners);
        IEnumerable<CarInfo> ConvertToCarsList(IEnumerable<CarOwner> carOwners);
        IEnumerable<BrandOwner> ConvertToBrandOwnerDedupe(IEnumerable<CarInfo> cars);
    }
}
