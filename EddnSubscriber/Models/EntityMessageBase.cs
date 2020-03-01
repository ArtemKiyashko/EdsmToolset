using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EddnSubscriber.Models
{
    public class EntityMessageBase
    {
        [JsonProperty("event")]
        public string Event { get; set; }
        [JsonProperty("timestamp")]
        public DateTime? Timestamp { get; set; }
    }
}
