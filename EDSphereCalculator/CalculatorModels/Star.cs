using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDSphereCalculator.CalculatorModels
{
    public class Star
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("id64")]
        public long? Id64 { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("distance")]
        public double Distance { get; set; }

        [JsonProperty("coords")]
        public StarCoordinates Coordinates { get; set; }

        [JsonProperty("distancefrom")]
        public Star DistanceFrom { get; set; }

        public override string ToString()
        {
            return $"{Name}({Coordinates})";
        }
    }
}
