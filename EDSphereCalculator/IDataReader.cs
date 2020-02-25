using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EdsmDbImporter
{
    public interface IDataReader<T> where T : new()
    {
        Task<bool> ReadAsync();
        Task<bool> ValidateAsync();
        T Result { get; }
    }
}
