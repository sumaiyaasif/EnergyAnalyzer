using System;
namespace EnergyAnalyzerApp.Weather
{
    public class WeatherModel
    {
        public DateTime date { get; set; }
        public double averageTemp { get; set; }
        public double minimumTemp { get; set; }
        public double maximumTemp { get; set; }

        public WeatherModel()
        {

        }
    }
}
