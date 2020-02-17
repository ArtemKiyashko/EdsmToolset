using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EDSphereCalculator.CalculatorModels
{
    public class CelestialBodyAtmosphereComposition : DictionaryModelBase<string, decimal>
    {
        [Required]
        public virtual CelestialBody Body { get; set; }
        public long BodyId { get; set; }
    }
}
