using System;
namespace EnergyAnalyzerApp.EnergyUsage
{
    public class EnergyConsumedModel
    {
        public EnergyConsumedModel(DateTime item1, double item2)
        {
            date = item1;
            usage = item2;
        }

        public DateTime date { get; set; }
        public double usage { get; set; }
    }
}
