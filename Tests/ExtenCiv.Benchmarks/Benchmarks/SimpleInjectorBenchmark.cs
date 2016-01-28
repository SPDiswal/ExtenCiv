using ExtenCiv.Benchmarks.Benchmarks.Abstractions;
using ExtenCiv.Composition.SimpleInjector.Builders;
using ExtenCiv.Games.Abstractions;

namespace ExtenCiv.Benchmarks.Benchmarks
{
    /// <summary>
    ///     Benchmark for Simple Injector.
    /// </summary>
    public sealed class SimpleInjectorBenchmark : IBenchmark
    {
        /// <summary>
        ///     Runs the benchmark program with the AlphaCiv configuration.
        /// </summary>
        public IGame AlphaCiv() => new SimpleInjectorAlphaCiv().BuildGame();

        /// <summary>
        ///     Runs the benchmark program with the SemiCiv configuration.
        /// </summary>
        public IGame SemiCiv() => new SimpleInjectorSemiCiv().BuildGame();

        public override string ToString() => "Simple Injector";
    }
}
