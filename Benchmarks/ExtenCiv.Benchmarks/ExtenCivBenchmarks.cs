using System;
using System.Diagnostics;
using ExtenCiv.Autofac;
using ExtenCiv.Benchmarks.Common;

namespace ExtenCiv.Benchmarks
{
    public class ExtenCivBenchmarks
    {
        private static readonly Stopwatch Stopwatch = new Stopwatch();

        private static readonly IBenchmark[] Benchmarks =
        {
            new AutofacBenchmarks()
        };

        public static void Main(string[] args)
        {
            foreach (var benchmark in Benchmarks)
            {
                Console.WriteLine($":::: {benchmark} ::::");

                Run(() => benchmark.AlphaCiv(), "AlphaCiv");
                Run(() => benchmark.BetaCiv(), "BetaCiv");
                Run(() => benchmark.GammaCiv(), "GammaCiv");
                Run(() => benchmark.DeltaCiv(), "DeltaCiv");
                Run(() => benchmark.EpsilonCiv(), "EpsilonCiv");
                Run(() => benchmark.ZetaCiv(), "ZetaCiv");
                Run(() => benchmark.EtaCiv(), "EtaCiv");
                Run(() => benchmark.ThetaCiv(), "ThetaCiv");
                Run(() => benchmark.SemiCiv(), "SemiCiv");

                Console.WriteLine("");
            }
        }

        private static void Run(Action benchmark, string configurationName)
        {
            Stopwatch.Restart();
            benchmark.Invoke();
            Stopwatch.Stop();

            Console.WriteLine($"{configurationName}: {Stopwatch.ElapsedMilliseconds} ms.");
        }
    }
}
