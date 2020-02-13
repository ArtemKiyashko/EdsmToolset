using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EDSphereCalculator.CalculatorModels
{
    public class Distance
    {
        public virtual Star DistanceFrom { get; set; }
        public int DistanceFromId { get; set; }
        public virtual Star DistanceTo { get; set; }
        public int DistanceToId { get; set; }
        public double LightYears { get; set; }
    }
}
