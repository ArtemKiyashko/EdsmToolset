using System;
using System.Collections.Generic;
using System.Text;

namespace EDSphereCalculator.CalculatorModels
{
    public class Distance
    {
        public Star DistanceFrom { get; set; }
        public Star DistanceTo { get; set; }
        public double LightYears { get; set; }
    }
}
