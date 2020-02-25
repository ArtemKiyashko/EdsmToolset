using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class DictionaryModelBase<T1, T2> : BaseModel
    {
        public T1 Key { get; set; }
        public T2 Value { get; set; }
    }
}
