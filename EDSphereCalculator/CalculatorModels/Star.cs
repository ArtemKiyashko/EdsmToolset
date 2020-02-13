using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDSphereCalculator.CalculatorModels
{
    public class Star : BaseModel
    {
        [JsonProperty("id64")]
        public long? Id64 { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("coords")]
        public virtual StarCoordinates Coordinates { get; set; }

        public virtual ICollection<CelestialBody> Bodies { get; set; }

        public override string ToString()
        {
            return $"{Name}({Coordinates})";
        }
    }
}
