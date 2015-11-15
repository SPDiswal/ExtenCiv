using System;

namespace ExtenCiv.Common.Utilities.Extensions
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
    }
}
