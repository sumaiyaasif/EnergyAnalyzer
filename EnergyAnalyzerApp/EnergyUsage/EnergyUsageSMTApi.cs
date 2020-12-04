using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
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
            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.SslProtocols = SslProtocols.Tls12;
            var cert = new X509Certificate2("C:/Users/Sumaiya/Desktop/localhost2.pfx", "", X509KeyStorageFlags.Exportable);
            byte[] certBytes = cert.Export(X509ContentType.Pfx);
            var certFile = new X509Certificate2(certBytes);
            Console.WriteLine("has private key: " + certFile.PrivateKey);
            handler.ClientCertificates.Add(certFile);

            var client = new HttpClient(handler);
            var json = "{\"trans_id\":\"22\",\"requestorID\":\"TESTRESACCOUNT6\",\"requesterType\":\"RES\",\"startDate\":\"10/07/2020\",\"endDate\":\"11/05/2020\",\"reportFormat\":\"JSON\",\"version\":\"L\",\"readingType\":\"c\",\"esiid\":[\"10443720005821899\"],\"SMTTermsandConditions\":\"Y\"}";
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var authString = Convert.ToBase64String(Encoding.UTF8.GetBytes(Configuration["SMTApiKey"]));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authString);

            return client.PostAsync("https://uatservices.smartmetertexas.net/dailyreads/", stringContent);
        }
       
    }
}
