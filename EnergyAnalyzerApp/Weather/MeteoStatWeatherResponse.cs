using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EnergyAnalyzerApp.Weather
{

    public class MeteoStatWeatherResponse
    {
        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }

        [JsonPropertyName("data")]
        public List<Datum> Data { get; set; }
    }

    public class Meta
    {
        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("exec_time")]
        public double ExecTime { get; set; }

        [JsonPropertyName("generated")]
        public string Generated { get; set; }
    }

    public class Datum
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("tavg")]
        public double Tavg { get; set; }

        [JsonPropertyName("tmin")]
        public double Tmin { get; set; }

        [JsonPropertyName("tmax")]
        public double Tmax { get; set; }

        [JsonPropertyName("prcp")]
        public double Prcp { get; set; }

        [JsonPropertyName("snow")]
        public int Snow { get; set; }

        [JsonPropertyName("wdir")]
        public int? Wdir { get; set; }

        [JsonPropertyName("wspd")]
        public int Wspd { get; set; }

        [JsonPropertyName("wpgt")]
        public object Wpgt { get; set; }

        [JsonPropertyName("pres")]
        public object Pres { get; set; }

        [JsonPropertyName("tsun")]
        public object Tsun { get; set; }
    }

}
