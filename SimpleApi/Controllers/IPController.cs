using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApi.Contracts;

namespace SimpleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IPController : ControllerBase
    {
        private ILocationProvider _locationProvider;
        private IWeatherProvider _weatherProvider;

        public IPController(ILocationProvider locationProvider, IWeatherProvider weatherProvider)
        {
            _locationProvider = locationProvider;
            _weatherProvider = weatherProvider;
        }

        // GET api/values/5
        [HttpGet("weather")]
        public ActionResult<string> Weather()
        {
            IPHostEntry heserver = Dns.GetHostEntry(Dns.GetHostName());
            var ip = heserver.AddressList[1].ToString();
            
            var location = Task.Run(() => _locationProvider.GetCurrentLocationByIP(ip)).Result;
            var weatherStatus = _weatherProvider.GetWeatherForLocation(location.Latitude, location.Longitude);

            return $"Hello, your IP is {ip}, your location is {location.Latitude}. {weatherStatus}";
        }

    }
}