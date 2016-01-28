using ExtenCiv.Benchmarks.Benchmarks.Abstractions;
using ExtenCiv.Composition.Ninject.Builders;
using ExtenCiv.Games.Abstractions;

namespace ExtenCiv.Benchmarks.Benchmarks
{
    /// <summary>
    ///     Benchmark for Ninject.
    /// </summary>
    public sealed class NinjectBenchmark : IBenchmark
    {
        /// <summary>
        ///     Runs the benchmark program with the AlphaCiv configuration.
        /// </summary>
        public IGame AlphaCiv() => new NinjectAlphaCiv().BuildGame();

        /// <summary>
        ///     Runs the benchmark program with the SemiCiv configuration.
        /// </summary>
        public IGame SemiCiv() => new NinjectSemiCiv().BuildGame();

        public override string ToString() => "Ninject";
    }
}
