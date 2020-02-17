using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EDSphereCalculator.CalculatorModels
{
    public class EdSystem : BaseModel
    {
        [JsonProperty("id")]
        public long EdsmId { get; set; }
        [JsonProperty("id64")]
        public long? EdsmId64 { get; set; }

        [JsonProperty("name")]
        [Required]
        public string Name { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("coords")]
        public virtual EdSystemCoordinates Coordinates { get; set; }

        public virtual ICollection<CelestialBody> Bodies { get; set; }

        public virtual ICollection<Distance> DistancesFrom { get; set; }

        public virtual ICollection<Distance> DistancesTo { get; set; }

        public override string ToString()
        {
            return $"{Name}({Coordinates})";
        }
    }
}
