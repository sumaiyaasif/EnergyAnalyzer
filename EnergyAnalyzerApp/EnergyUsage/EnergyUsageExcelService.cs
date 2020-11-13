using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace EnergyAnalyzerApp.EnergyUsage
{
    public class EnergyUsageExcelService : IEnergyUsageService
    {

        private readonly IConfiguration Configuration;

        public EnergyUsageExcelService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //public int[] getDailyUsage(DateTime startDate, DateTime endDate) {
          //  throw new NotImplementedException();
        //}

        public Task<HttpResponseMessage> getDailyUsage(DateTime startDate, DateTime endDate)
        {
            throw new NotFiniteNumberException();
        }

    }
}
