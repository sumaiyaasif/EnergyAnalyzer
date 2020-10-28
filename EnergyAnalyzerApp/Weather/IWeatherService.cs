using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EnergyAnalyzerApp.Weather
{
    public interface IWeatherService
    { 
        public Task<HttpResponseMessage> ServiceCall(string startDate, string endDate, double latitude, double longitude);
    }
}
