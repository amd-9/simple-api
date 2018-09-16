using DarkSky.Services;
using SimpleApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApi.Services
{
    public class DarkSkyWeatherService : IWeatherProvider
    {
        public string GetWeatherForLocation(double latitude, double longitude)
        {
            var service = new DarkSkyService("97fb52ad1c8fb2f59ff1f5da02d0337c");
            var forecast = Task.Run(() => service.GetForecast(latitude, longitude)).Result;

            return $"Current weather is {forecast.Response.Currently.Temperature}";
        }
    }
}
