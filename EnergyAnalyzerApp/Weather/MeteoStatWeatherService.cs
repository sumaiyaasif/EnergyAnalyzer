using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EnergyAnalyzerApp.Weather
{
    public class MeteoStatWeatherService : IWeatherService
    {
     
        public Task<HttpResponseMessage> ServiceCall(string startDate, string endDate, double latitude, double longitude)
        {
            // dates are yyyy-mm-dd
            HttpClient client = new HttpClient();
            var urlBuilder = "https://api.meteostat.net/v2/point/daily?lat=" + latitude + "&lon=" + longitude + "&alt=336&start=" + startDate + "&end=" + endDate;
            
            return client.GetAsync(urlBuilder);
        }
    }
}
