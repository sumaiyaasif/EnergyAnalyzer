using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace EnergyAnalyzerApp.Weather
{
    public class MeteoStatWeatherService : IWeatherService
    {
        private readonly IConfiguration Configuration;

        public MeteoStatWeatherService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<WeatherModel> HistoricalWeather(string startDate, string endDate, double latitude, double longitude)
        {
            var serviceResponse = ServiceCall(startDate, endDate, latitude, longitude);
            string result = serviceResponse.Result.Content.ReadAsStringAsync().Result;
            MeteoStatWeatherResponse meteoStatWeatherResponse = JsonConvert.DeserializeObject<MeteoStatWeatherResponse>(result);
            List<WeatherModel> historicalWeather = new List<WeatherModel>();
            foreach (var element in meteoStatWeatherResponse.Data)
            {
                var dailyWeather = new WeatherModel();
                dailyWeather.date = DateTime.Parse(element.Date);
                dailyWeather.averageTemp = element.Tavg;
                dailyWeather.minimumTemp = element.Tmin;
                dailyWeather.maximumTemp = element.Tmax;
                historicalWeather.Add(dailyWeather);

            }
            return historicalWeather;
        }

        public Task<HttpResponseMessage> ServiceCall(string startDate, string endDate, double latitude, double longitude)
        {
            // dates are yyyy-mm-dd
            HttpClient client = new HttpClient();
            var urlBuilder = "https://api.meteostat.net/v2/point/daily?lat=" + latitude + "&lon=" + longitude + "&alt=336&start=" + startDate + "&end=" + endDate;
            client.DefaultRequestHeaders.Add("x-api-key", Configuration["MeteoWeatherKey"]);
            return client.GetAsync(urlBuilder);
        }


    }
}
