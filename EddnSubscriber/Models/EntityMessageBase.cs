using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EddnSubscriber.Models
{
    public class EntityMessageBase
    {
        [JsonProperty("event")]
        [JsonConverter(typeof(StringEnumConverter))]
        [DefaultValue(EddnEvent.Unknown)]
        public EddnEvent Event { get; set; }
        [JsonProperty("timestamp")]
        public DateTime? Timestamp { get; set; }
    }
}
