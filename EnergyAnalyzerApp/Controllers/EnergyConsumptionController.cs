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
    public class EnergyConsumptionController : ControllerBase
    {
        
        private readonly ILogger<EnergyConsumptionController> _logger;
        private IEnergyUsageService _energyUsageService;

        public EnergyConsumptionController(ILogger<EnergyConsumptionController> logger, IEnergyUsageService energyUsageService)
        {
            _logger = logger;
            _energyUsageService = energyUsageService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<string> Get(DateTime start, DateTime end)
        {
            return await _energyUsageService.getDailyUsage(start, end).Result.Content.ReadAsStringAsync();
        }
    }
}
