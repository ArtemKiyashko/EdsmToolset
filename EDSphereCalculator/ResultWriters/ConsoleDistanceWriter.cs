using EDSphereCalculator.CalculatorModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EDSphereCalculator.ResultWriters
{
    public class ConsoleDistanceWriter : IResultWriter<Distance>
    {
        public Task WriteResultAsync(Distance result)
        {
            Console.WriteLine($"{result.DistanceTo}: Distance from: {result.DistanceFrom} - {result.LightYears}");
            return Task.CompletedTask;
        }
    }
}
