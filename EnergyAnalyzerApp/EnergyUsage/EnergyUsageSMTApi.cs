using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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
            HttpClient client = new HttpClient();
            var json = "{\"trans_id\":\"22\",\"requestorID\":\"TESTRESACCOUNT6\",\"requesterType\":\"RES\",\"startDate\":\"10/07/2020\",\"endDate\":\"11/05/2020\",\"reportFormat\":\"JSON\",\"version\":\"L\",\"readingType\":\"c\",\"esiid\":[\"10443720005821899\"],\"SMTTermsandConditions\":\"Y\"}";
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var authString = Convert.ToBase64String(Encoding.UTF8.GetBytes(Configuration["SMTApiKey"]));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authString);
            return client.PostAsync("https://uatservices.smartmetertexas.net/dailyreads/", stringContent);
        }
    }
}
