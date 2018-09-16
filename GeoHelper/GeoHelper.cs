using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GeoHelper
{
    public class GeoHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<GeoHelper> _logger;
        private readonly HttpClient _httpClient;

        public GeoHelper()
        {
            //_httpContextAccessor = httpContextAccessor;
            //_logger = logger;
            _httpClient = new HttpClient()
            {
                Timeout = TimeSpan.FromSeconds(5)
            };
        }

        public async Task<GeoInfo> GetGeoInfo(string ip)
        {
            //var ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress;
            var key = "8a8c1cec23d2627b7c93a50c657be2f7";

            try
            {
                var response = await _httpClient.GetAsync($"http://api.ipstack.com/{ip}?access_key={key}&output=json&legacy=1");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<GeoInfo>(json);
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Failed to retrieve geo info for ip '{0}'", ip);
            }

            return null;
        }
    }
}
