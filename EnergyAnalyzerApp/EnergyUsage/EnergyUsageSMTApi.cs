using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace EnergyAnalyzerApp.EnergyUsage
{
    public class EnergyUsageSMTApi: IEnergyUsageService
    {
        private readonly IConfiguration Configuration;
        public EnergyUsageSMTApi(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Task<HttpResponseMessage> getDailyUsage(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();

        }
       
    }
}
