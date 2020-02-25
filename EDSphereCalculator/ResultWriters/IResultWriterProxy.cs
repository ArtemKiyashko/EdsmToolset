using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EdsmDbImporter.ResultWriters
{
    public interface IResultWriterProxy<T>
    {
        Task WriteResultAsync(T result);
    }
}
