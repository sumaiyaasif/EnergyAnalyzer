using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace EnergyAnalyzerApp.EnergyUsage
{
    public class EnergyUsageExcelService : IEnergyUsageService
    {

        private readonly IConfiguration Configuration;

        public EnergyUsageExcelService(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public Task<HttpResponseMessage> getDailyUsage(DateTime startDate, DateTime endDate)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            List<EnergyConsumedModel> energyConsumed = new List<EnergyConsumedModel>();
            var dayData = new List<Tuple<DateTime, double>>();

            using (var reader = new StreamReader(@"DailyMeterUsage"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if(DateTime.TryParse(values[1], out DateTime date))
                    {
                        dayData.Add(new Tuple<DateTime, double>(date, Convert.ToDouble(values[5])));
                    }
                }
            }

            foreach(var day in dayData)
            {
                if(day.Item1 >= startDate && day.Item1 <= endDate)
                {
                    energyConsumed.Add(new EnergyConsumedModel(day.Item1, day.Item2));
                }
            }
            response.Content = new StringContent(JsonConvert.SerializeObject(energyConsumed), Encoding.UTF8, "application/json");
            return Task.FromResult(response);
            }

    }
}
