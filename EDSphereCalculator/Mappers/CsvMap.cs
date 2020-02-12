using CsvHelper.Configuration;
using EDSphereCalculator.CalculatorModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDSphereCalculator.Mappers
{
    public class CsvMap : ClassMap<Star>
    {
        public CsvMap()
        {
            Map(m => m.DistanceFrom).ConvertUsing(_ => _.DistanceFrom.ToString()).Index(0).Name("Start System");
            Map(m => m.Name).Index(1).Name("Target System");
            Map(m => m.Coordinates).ConvertUsing(_ => _.Coordinates.ToString()).Index(2).Name("Target System Coordinates");
            Map(m => m.Distance).ConvertUsing(_ => _.Distance.ToString("N2")).Index(3).Name("Distance");
        }
    }
}
