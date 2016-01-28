using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtenCiv.Utilities.Extensions
{
    /// <summary>
    ///     This class provides some helpful extension methods for integers.
    /// </summary>
    public static class IntegerExtensions
    {
        /// <summary>
        ///     Repeats an action sequentially a certain number of times.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><c>repetitions</c> is negative.</exception>
        /// <exception cref="ArgumentNullException"><c>action</c> is null.</exception>
        public static void Times(this int repetitions, Action action)
        {
            if (repetitions < 0) throw new ArgumentOutOfRangeException(nameof(repetitions));
            if (action == null) throw new ArgumentNullException(nameof(action));

            for (var i = 0; i < repetitions; i++)
                action.Invoke();
        }

        /// <summary>
        ///     Returns a range of integers.
        /// </summary>
        /// <param name="start">The lower inclusive bound of the range.</param>
        /// <param name="end">The upper inclusive bound of the range.</param>
        public static IEnumerable<int> To(this int start, int end) => Enumerable.Range(start, end - start + 1);
    }
}
