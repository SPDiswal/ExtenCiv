using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using ExtenCiv.Benchmarks.Benchmarks;
using ExtenCiv.Benchmarks.Benchmarks.Abstractions;

namespace ExtenCiv.Benchmarks.Runners
{
    public class BenchmarkRunner
    {
        private const int AlphaCivIterations = 389;
        private const int SemiCivIterations = 389;
        private const int TotalNumberOfGames = AlphaCivIterations + SemiCivIterations;

        private static readonly Stopwatch Stopwatch = new Stopwatch();

        private static readonly IDictionary<IBenchmark, long> BenchmarkEntries = new Dictionary<IBenchmark, long>
        {
            [new PoorManBenchmark()] = 0,
            [new AutofacBenchmark()] = 0,
            [new DryIocBenchmark()] = 0,
            [new LightInjectBenchmark()] = 0,
            [new NinjectBenchmark()] = 0,
            [new SimpleInjectorBenchmark()] = 0,
            [new StructureMapBenchmark()] = 0,
            [new UnityBenchmark()] = 0,
            [new WindsorBenchmark()] = 0,
        };

        private static IBenchmark[] Benchmarks => BenchmarkEntries.Keys.ToArray();

        public static void Main(string[] args)
        {
            Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(1);

            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            Initialise();
            Console.Clear();

            AlphaCiv();
            Console.Clear();

            SemiCiv();
            Console.Clear();

            PrintResults();
            Console.ReadKey();
        }

        private static void Initialise()
        {
            Console.Write("Initialising...");

            foreach (var benchmark in Benchmarks)
            {
                benchmark.AlphaCiv();
                benchmark.SemiCiv();
            }
        }

        private static void AlphaCiv()
        {
            for (var i = 1; i <= AlphaCivIterations; i++)
            {
                Console.Write($"\rAlphaCiv, iteration {i}");
                GC.Collect();

                RunBenchmarks(b => b.AlphaCiv());
            }
        }

        private static void SemiCiv()
        {
            for (var i = 1; i <= SemiCivIterations; i++)
            {
                Console.Write($"\rSemiCiv, iteration {i}");
                GC.Collect();

                RunBenchmarks(b => b.SemiCiv());
            }
        }

        private static void RunBenchmarks(Action<IBenchmark> gameConfiguration)
        {
            foreach (var benchmark in Benchmarks)
            {
                Stopwatch.Restart();

                gameConfiguration.Invoke(benchmark);

                Stopwatch.Stop();

                // Computes elapsed time in high resolution.
                var ticks = Stopwatch.ElapsedTicks;
                var elapsedMicroseconds = (double) ticks / Stopwatch.Frequency * 1000000;

                BenchmarkEntries[benchmark] += (long) elapsedMicroseconds;
            }
        }

        private static void PrintResults()
        {
            foreach (var benchmark in Benchmarks)
            {
                var totalTime = BenchmarkEntries[benchmark];
                var averageTime = (double) totalTime / TotalNumberOfGames;
                Console.WriteLine($"{benchmark,20}: {averageTime / 1000,0:0.00} ms on average"
                                  + $" ({(double) totalTime / 1000000,0:0.00} s in total)");
            }

            Console.WriteLine();
            Console.WriteLine($"Total elapsed time: {(double) BenchmarkEntries.Values.Sum() / 1000000,0:0.00} s");
        }
    }
}
