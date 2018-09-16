using SimpleApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApi.Contracts
{
    public interface ILocationProvider
    {
        Task<LocationData> GetCurrentLocationByIP(string address);
    }
}
