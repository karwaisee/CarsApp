using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CarsApp.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CarsApp.Services
{
    public class CarService : ICarService
    {
        private readonly HttpClient _httpClient;

        public CarService(string url)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(url);
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<IEnumerable<CarOwner>> GetCarOwners()
        {
            var response = await _httpClient.GetStringAsync("");
            return JsonConvert.DeserializeObject<IEnumerable<CarOwner>>(response);
        }
    }
}
