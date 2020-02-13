using System;
using System.Collections.Generic;
using System.Text;

namespace EDSphereCalculator.CalculatorModels
{
    public class Distance : BaseModel
    {
        public virtual Star DistanceFrom { get; set; }
        public virtual Star DistanceTo { get; set; }
        public double LightYears { get; set; }
    }
}
