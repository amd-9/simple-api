using GeoHelper;
using MaxMind.GeoIP2;
using SimpleApi.Contracts;
using SimpleApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApi.Services
{
    public class GeoHelperLocationService : ILocationProvider
    {
        public async Task<LocationData> GetCurrentLocationByIP(string ipAdress)
        {
            var client = new GeoHelper.GeoHelper();

            var response = Task.FromResult<GeoInfo>(await client.GetGeoInfo(ipAdress)).Result;

            return new LocationData() {
                Latitude = response.Latitude.Value,
                Longitude= response.Longitude.Value
                
            };
        }
    }
}
