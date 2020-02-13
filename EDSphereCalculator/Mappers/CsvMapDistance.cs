using CsvHelper.Configuration;
using EDSphereCalculator.CalculatorModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDSphereCalculator.Mappers
{
    public class CsvMapDistance : ClassMap<Distance>
    {
        public CsvMapDistance()
        {
            Map(m => m.DistanceFrom).ConvertUsing(_ => _.DistanceFrom.ToString()).Index(0).Name("Start System");
            Map(m => m.DistanceTo.Name).Index(1).Name("Target System");
            Map(m => m.DistanceTo.Coordinates).ConvertUsing(_ => _.DistanceTo.Coordinates.ToString()).Index(2).Name("Target System Coordinates");
            Map(m => m.LightYears).ConvertUsing(_ => _.LightYears.ToString("N2")).Index(3).Name("Distance");
        }
    }
}
