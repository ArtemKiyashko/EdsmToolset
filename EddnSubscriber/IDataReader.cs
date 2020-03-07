using System;
using System.Collections.Generic;
using System.Text;

namespace EddnSubscriber
{
    public interface IDataReader
    {
        T Read<T>(string entity);
    }
}
