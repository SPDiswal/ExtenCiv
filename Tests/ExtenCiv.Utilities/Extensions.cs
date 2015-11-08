using System;

namespace ExtenCiv.Tests.Utilities
{
    public static class Extensions
    {
        public static void Times(this int repetitions, Action action)
        {
            for (var i = 0; i < repetitions; i++)
                action();
        }
    }
}
