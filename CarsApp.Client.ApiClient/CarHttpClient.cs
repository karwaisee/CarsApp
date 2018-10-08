using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CarsApp.Client.ApiClient
{
    public class CarHttpClient : HttpClient
    {
        public CarHttpClient()
        {
            // Mock testing of local instance
            //BaseAddress = new Uri("http://localhost:15558");

            BaseAddress = new Uri("http://codingtest.kloud.com.au");
            DefaultRequestHeaders.Clear();
            DefaultRequestHeaders.Add("Accept", "application/json");
        }
    }
}
