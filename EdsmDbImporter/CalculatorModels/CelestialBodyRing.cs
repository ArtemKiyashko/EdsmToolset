using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EdsmDbImporter.CalculatorModels
{
    public class CelestialBodyRing : BaseModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("mass")]
        public double Mass { get; set; }
        [JsonProperty("innerRadius")]
        public double InnerRadius { get; set; }
        [JsonProperty("outerRadius")]
        public double OuterRadius { get; set; }
        [JsonIgnore]
        [Required]
        public virtual CelestialBody Body { get; set; }
        public long BodyId { get; set; }
    }
}
