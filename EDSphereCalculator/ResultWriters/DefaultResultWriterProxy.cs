using EDSphereCalculator.CalculatorModels;
using EDSphereCalculator.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EDSphereCalculator.ResultWriters
{
    public class DefaultResultWriterProxy : IResultWriterProxy<Star>
    {
        private readonly IEnumerable<IResultWriter<Star>> _resultWriters;

        public DefaultResultWriterProxy(IEnumerable<IResultWriter<Star>> resultWriters)
        {
            _resultWriters = resultWriters;
        }

        public async Task WriteResultAsync(Star result)
        {
            await _resultWriters.ForEachAsync(async _ => await _.WriteResultAsync(result));
        }
    }
}
