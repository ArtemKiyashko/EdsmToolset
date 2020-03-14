using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace EddnSubscriberTests.Helpers
{

    public static class MakeGeneric
    {
        public static Type GetEnumerable(Type typeArgument)
        {
            Type genericClass = typeof(IEnumerable<>);
            return genericClass.MakeGenericType(typeArgument);
        }
    }
}
