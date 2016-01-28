using ExtenCiv.Benchmarks.Benchmarks.Abstractions;
using ExtenCiv.Composition.Autofac.Builders;
using ExtenCiv.Games.Abstractions;

namespace ExtenCiv.Benchmarks.Benchmarks
{
    /// <summary>
    ///     Benchmark for Autofac.
    /// </summary>
    public sealed class AutofacBenchmark : IBenchmark
    {
        /// <summary>
        ///     Runs the benchmark program with the AlphaCiv configuration.
        /// </summary>
        public IGame AlphaCiv() => new AutofacAlphaCiv().BuildGame();

        /// <summary>
        ///     Runs the benchmark program with the SemiCiv configuration.
        /// </summary>
        public IGame SemiCiv() => new AutofacSemiCiv().BuildGame();

        public override string ToString() => "Autofac";
    }
}
