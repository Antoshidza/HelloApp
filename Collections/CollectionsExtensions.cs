using System;
using System.Collections.Generic;
using System.Linq;
using Source.Core.Random;

namespace Source.Core.Collections.Extensions
{
    public static class CollectionsExtensions
    {
        public static T Take<T>(this IList<T> list, in int index)
        {
            var value = list[index];
            list.RemoveAt(index);
            return value;
        }

        public static T Take<T>(this IList<T> list, T item)
        {
            list.Remove(item);
            return item;
        }

        public static int GetRandomElementIndex<T, TRndProvider>(this ICollection<T> list, TRndProvider rnd)
            where TRndProvider : IRandomProvider 
            => rnd.Range(0, list.Count);
        
        public static int GetRandomElementIndex<T, TRndProvider>(this IReadOnlyCollection<T> list, TRndProvider rnd)
            where TRndProvider : IRandomProvider 
            => rnd.Range(0, list.Count);

        public static T GetRandom<T>(this IReadOnlyList<T> list, IRandomProvider rnd)
            => list[list.GetRandomElementIndex(rnd)];

        public static IEnumerable<T> GetRandom<T>(this IEnumerable<T> collection, IRandomProvider rnd, int count)
            => collection.OrderBy(x => rnd.NextInt).Take(count);

        public static T TakeRandom<T, TRndProvider>(this IList<T> list, TRndProvider rnd)
            where TRndProvider : IRandomProvider 
            => list.Take(list.GetRandomElementIndex(rnd));

        public static TValue[] ConstructArrayForEnumAccess<TValue, TEnum>(Func<TValue> factory = null)
            where TEnum : Enum
        {
            var enumValues = Enum.GetValues(typeof(TEnum));
            var result = new TValue[enumValues.Length];

            if (factory == null) return result;

            for (int i = 0; i < result.Length; i++)
                result[i] = factory();

            return result;
        }
    }
}