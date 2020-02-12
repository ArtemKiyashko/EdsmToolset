using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EDSphereCalculator.ResultWriters
{
    public interface IResultWriterProxy<T>
    {
        Task WriteResultAsync(T result);
    }
}
