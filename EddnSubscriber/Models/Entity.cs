using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace EddnSubscriber.Models
{
    public class Entity<T>
    {
        [JsonProperty("$schemaRef")]
        public Uri Reference { get; set; }
        [JsonProperty("header")]
        public EntityHeader Header { get; set; }
        [JsonProperty("message")]
        public T Message { get; set; }
    }
}
