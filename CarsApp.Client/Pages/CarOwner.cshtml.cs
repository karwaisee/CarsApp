using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarsApp.Models;
using CarsApp.Client.ApiClient;

namespace CarsApp.Client.Pages.CarOwner
{
    public class CarOwnerModel : PageModel
    {
        public IEnumerable<BrandOwner> BrandOwner { get; set; }
        private ICarServiceClient _carServiceClient;

        public CarOwnerModel(ICarServiceClient carServiceClient)
        {
            _carServiceClient = carServiceClient;
        }

        public async Task OnGetAsync()
        {
            IEnumerable<Models.CarOwner> carOwners = new List<Models.CarOwner>();

            try
            {
                carOwners = await _carServiceClient.GetCarOwners();
            }
            catch
            {
                // PROD: Logging here

                HttpContext.Response.Redirect("/Error");
            }

            // Remove car owner without name
            carOwners = _carServiceClient.FilterCarOwnerWithoutName(carOwners);

            // Transform car owners resultset into list of cars
            IEnumerable<CarInfo> cars = _carServiceClient.ConvertToCarsList(carOwners);
            
            // Transform cars list to group by Brand, Dedupe owner name within group
            // ASSUME: colour empty is valid
            BrandOwner = _carServiceClient.ConvertToBrandOwnerDedupe(cars);
        }
    }
}