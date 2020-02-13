using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDSphereCalculator.CalculatorModels
{
    public class BaseModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
