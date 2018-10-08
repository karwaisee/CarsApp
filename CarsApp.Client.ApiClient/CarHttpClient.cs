using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CarsApp.Models;

namespace CarsApp.Client.ApiClient
{
    public class CarHttpClient : ICarHttpClient
    {
        private readonly HttpClient _httpClient;

        public CarHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;

            // Mock testing of local instance
            //_httpClient.BaseAddress = new Uri("http://localhost:15558");

            _httpClient.BaseAddress = new Uri("http://codingtest.kloud.com.au");
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<IEnumerable<CarOwner>> GetCarOwners()
        {
            string uri = "api/cars";
            string response = await _httpClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObject<IEnumerable<CarOwner>>(response);
        }
    }
}
