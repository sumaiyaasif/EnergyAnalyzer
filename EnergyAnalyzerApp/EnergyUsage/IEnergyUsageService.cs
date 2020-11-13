using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EnergyAnalyzerApp.EnergyUsage
{
    public interface IEnergyUsageService
    {
        public Task<HttpResponseMessage> getDailyUsage(DateTime startDate, DateTime endDate);
    }
}