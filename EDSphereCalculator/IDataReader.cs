using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EDSphereCalculator
{
    public interface IDataReader<T> where T : new()
    {
        Task<bool> ReadAsync();
        T Result { get; }
    }
}
