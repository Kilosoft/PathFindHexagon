using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions.Linq
{
    public static class EnumerableExtensions
    {
        private static Random random = new Random();
        public static T Random<T>(this IEnumerable<T> input)
        {
            return input.ElementAt(random.Next(input.Count()));
        }
    }
}
