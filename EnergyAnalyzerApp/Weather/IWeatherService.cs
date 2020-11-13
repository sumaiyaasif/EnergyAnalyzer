using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EnergyAnalyzerApp.Weather
{
    public interface IWeatherService
    {
        public List<WeatherModel> HistoricalWeather(string startDate, string endDate, double latitude, double longitude);
        public Task<HttpResponseMessage> ServiceCall(string startDate, string endDate, double latitude, double longitude);
    }
}
