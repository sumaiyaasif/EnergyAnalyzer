using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EnergyAnalyzerApp.EnergyUsage;
using EnergyAnalyzerApp.Weather;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnergyAnalyzerApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoricalWeatherController : ControllerBase
    {

        private readonly ILogger<HistoricalWeatherController> _logger;
        private IWeatherService _weatherService;

        public HistoricalWeatherController(ILogger<HistoricalWeatherController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public List<WeatherModel> Get(DateTime startDate, DateTime endDate)
        {
            return _weatherService.HistoricalWeather(startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"), 33.749, -84.388);
            //return await _weatherService.HistoricalWeather(startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"), 33.749, -84.388).Result.Content.ReadAsStringAsync();
        }
    }
}
