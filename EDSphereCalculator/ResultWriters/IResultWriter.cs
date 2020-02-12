using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EDSphereCalculator.ResultWriters
{
    public interface IResultWriter<T>
    {
        Task WriteResultAsync(T result);
    }
}
