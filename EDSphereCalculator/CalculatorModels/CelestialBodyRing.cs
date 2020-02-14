using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EDSphereCalculator.CalculatorModels
{
    public class CelestialBodyRing : BaseModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("mass")]
        public long Mass { get; set; }
        [JsonProperty("innerRadius")]
        public long InnerRadius { get; set; }
        [JsonProperty("outerRadius")]
        public long OuterRadius { get; set; }
        [JsonIgnore]
        [Required]
        public virtual CelestialBody Body { get; set; }
    }
}
