using ExtenCiv.Benchmarks.Benchmarks.Abstractions;
using ExtenCiv.Composition.Windsor.Builders;
using ExtenCiv.Games.Abstractions;

namespace ExtenCiv.Benchmarks.Benchmarks
{
    /// <summary>
    ///     Benchmark for Windsor.
    /// </summary>
    public sealed class WindsorBenchmark : IBenchmark
    {
        /// <summary>
        ///     Runs the benchmark program with the AlphaCiv configuration.
        /// </summary>
        public IGame AlphaCiv() => new WindsorAlphaCiv().BuildGame();

        /// <summary>
        ///     Runs the benchmark program with the SemiCiv configuration.
        /// </summary>
        public IGame SemiCiv() => new WindsorSemiCiv().BuildGame();

        public override string ToString() => "Windsor";
    }
}
