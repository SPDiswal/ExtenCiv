using ExtenCiv.Benchmarks.Benchmarks.Abstractions;
using ExtenCiv.CompositionRoot.DryIoc.Builders;
using ExtenCiv.Games.Abstractions;

namespace ExtenCiv.Benchmarks.Benchmarks
{
    /// <summary>
    ///     Benchmark for DryIoc.
    /// </summary>
    public sealed class DryIocBenchmark : IBenchmark
    {
        /// <summary>
        ///     Runs the benchmark program with the AlphaCiv configuration.
        /// </summary>
        public IGame AlphaCiv() => new DryIocAlphaCiv().BuildGame();

        /// <summary>
        ///     Runs the benchmark program with the SemiCiv configuration.
        /// </summary>
        public IGame SemiCiv() => new DryIocSemiCiv().BuildGame();

        public override string ToString() => "DryIoc";
    }
}
