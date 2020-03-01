using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EddnSubscriber.Models
{
    public class EddnComposition
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Percent")]
        public double Percent { get; set; }
    }
}
