using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EddnSubscriber.Models
{
    public class EddnSystem : EntityMessageBase
    {
        [JsonProperty("Body")]
        public string Body { get; set; }
        [JsonProperty("BodyID")]
        public int? BodyId { get; set; }
        [JsonProperty("BodyType")]
        public string BodyType { get; set; }
        [JsonProperty("Population")]
        public long? Population { get; set; }
        [JsonProperty("StarPos")]
        public IEnumerable<double> StarPos { get; set; }
        [JsonProperty("StarSystem")]
        public string StarSystem { get; set; }
        [JsonProperty("SystemAddress")]
        public long? SystemAddress { get; set; }
        [JsonProperty("SystemAllegiance")]
        public string SystemAllegiance { get; set; }
        [JsonProperty("SystemEconomy")]
        public string SystemEconomy { get; set; }
        [JsonProperty("SystemGovernment")]
        public string SystemGovernment { get; set; }
        [JsonProperty("SystemSecondEconomy")]
        public string SystemSecondEconomy { get; set; }
        [JsonProperty("SystemSecurity")]
        public string SystemSecurity { get; set; }
    }
}
