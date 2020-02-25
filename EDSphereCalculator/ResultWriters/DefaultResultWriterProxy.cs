using EdsmDbImporter.CalculatorModels;
using EdsmDbImporter.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EdsmDbImporter.ResultWriters
{
    public class DefaultResultWriterProxy<T> : IResultWriterProxy<T>
    {
        private readonly IEnumerable<IResultWriter<T>> _resultWriters;

        public DefaultResultWriterProxy(IEnumerable<IResultWriter<T>> resultWriters)
        {
            _resultWriters = resultWriters;
        }

        public async Task WriteResultAsync(T result)
        {
            await _resultWriters.ForEachAsync(async _ => await _.WriteResultAsync(result));
        }
    }
}
