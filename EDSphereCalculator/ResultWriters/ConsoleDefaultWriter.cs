﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EDSphereCalculator.ResultWriters
{
    public class ConsoleDefaultWriter : IResultWriter<string>
    {
        public Task WriteResultAsync(string result)
        {
            Console.WriteLine(result);
            return Task.CompletedTask;
        }
    }
}
