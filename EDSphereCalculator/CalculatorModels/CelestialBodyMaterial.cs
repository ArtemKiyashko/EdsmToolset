using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EDSphereCalculator.CalculatorModels
{
    public class CelestialBodyMaterial : DictionaryModelBase<string, decimal>
    {
        [Required]
        public virtual CelestialBody Body { get; set; }
        public long BodyId { get; set; }
    }
}
