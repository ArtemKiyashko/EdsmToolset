using EDSphereCalculator.CalculatorModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EDSphereCalculator.ResultWriters
{
    public class ConsoleWriter : IResultWriter<Star>
    {
        public Task WriteResultAsync(Star result)
        {
            Console.WriteLine($"{result}: Distance from: {result.DistanceFrom} - {result.Distance}");
            return Task.CompletedTask;
        }
    }
}
