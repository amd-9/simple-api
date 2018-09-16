using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApi.Contracts
{
    public interface IWeatherProvider
    {
        string GetWeatherForLocation(double latitute, double longitude);
    }
}
