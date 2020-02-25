using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdsmDbImporter.Extensions
{
    public  static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T element in source)
                action(element);
        }

        public static async Task ForEachAsync<T>(this IEnumerable<T> source, Func<T, Task> action)
        {
            foreach (T element in source)
                await action(element);
        }

        public static IEnumerable<T> ContinueIfAny<T>(this IEnumerable<T> source)
        {
            return source.Any() ? source : throw new ArgumentException("Sequence contains no elements");
        }

        public static IEnumerable<T> OrEmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }
    }
}
