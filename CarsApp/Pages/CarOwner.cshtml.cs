using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarsApp.Models;
using CarsApp.Services;
using CarsApp.Util;
using System;

namespace CarsApp.Pages.CarOwner
{
    public class CarOwnerModel : PageModel
    {
        public IEnumerable<CarInfo> Car { get; set; }
        public IEnumerable<BrandOwner> BrandOwner { get; set; }
        private ICarService _carService;

        public CarOwnerModel()
        {
            // Kloud coding test api
            _carService = new CarService("http://codingtest.kloud.com.au/api/cars/");

            // Mock api hosted locally
            _carService = new CarService("http://localhost:15558/api/cars");
        }

        public async Task OnGetAsync()
        {
            IEnumerable<Models.CarOwner> carOwners = new List<Models.CarOwner>();

            try
            {
                carOwners = await _carService.GetCarOwners();
            }
            catch
            {
                // PROD: Logging here

                HttpContext.Response.Redirect("/Error");
            }

            // Remove car owner without name
            carOwners = CarUtil.FilterCarOwnerWithoutName(carOwners);

            // Transform car owners resultset into list of cars
            IEnumerable<Models.CarInfo> cars = CarUtil.ConvertToCarsList(carOwners);
            
            // Transform cars list to group by Brand, Dedupe owner name within group
            // ASSUME: colour empty is valid
            BrandOwner = CarUtil.ConvertToBrandOwnerDedupe(cars);
        }
    }
}