using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtenCiv.Utilities.Extensions
{
    /// <summary>
    ///     This class provides some helpful extension methods.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        ///     Repeats an action sequentially a certain number of times.
        /// </summary>
        /// <param name="repetitions">Number of repetitions.</param>
        /// <param name="action">The action to repeat.</param>
        public static void Times(this int repetitions, Action action)
        {
            for (var i = 0; i < repetitions; i++)
                action();
        }

        /// <summary>
        ///     Returns a range of integers.
        /// </summary>
        /// <param name="start">The lower inclusive bound of the range.</param>
        /// <param name="end">The upper inclusive bound of the range.</param>
        public static IEnumerable<int> To(this int start, int end) => Enumerable.Range(start, end - start);

        /// <summary>
        ///     Computes the cartesian product of two collections and maps each element into a new element.
        /// </summary>
        /// <param name="first">The first collection.</param>
        /// <param name="second">The second collection.</param>
        /// <param name="resultSelector">The projection to apply on each element.</param>
        public static IEnumerable<TResult> Cartesian<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first,
                                                                               IEnumerable<TSecond> second,
                                                                               Func<TFirst, TSecond, TResult>
                                                                                   resultSelector)
        {
            return from item1 in first
                   from item2 in second
                   select resultSelector(item1, item2);
        }
    }
}
