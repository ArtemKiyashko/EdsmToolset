using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EDSphereCalculator.CalculatorModels
{
    public class Star : BaseModel
    {
        [JsonProperty("id")]
        public int EdsmId { get; set; }
        [JsonProperty("id64")]
        public long? EdsmId64 { get; set; }

        [JsonProperty("name")]
        [Required]
        public string Name { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("coords")]
        public virtual StarCoordinates Coordinates { get; set; }

        public virtual ICollection<CelestialBody> Bodies { get; set; }

        public virtual ICollection<Distance> DistancesFrom { get; set; }

        public virtual ICollection<Distance> DistancesTo { get; set; }

        public override string ToString()
        {
            return $"{Name}({Coordinates})";
        }
    }
}
