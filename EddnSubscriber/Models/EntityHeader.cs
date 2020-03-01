using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EddnSubscriber.Models
{
    public class EntityHeader
    {
        [JsonProperty("gatewayTimestamp")]
        public DateTime? GatewayTimeStamp { get; set; }
        [JsonProperty("softwareName")]
        public string SoftwareName { get; set; }
        [JsonProperty("softwareVersion")]
        public string SoftwareVersion { get; set; }
        [JsonProperty("uploaderID")]
        public string UploaderId { get; set; }
    }
}
