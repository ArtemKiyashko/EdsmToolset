using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EDSphereCalculator.CalculatorModels
{
    public class CelestialBody : BaseModel
    {
        [JsonProperty("id")]
        public int EdsmId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
