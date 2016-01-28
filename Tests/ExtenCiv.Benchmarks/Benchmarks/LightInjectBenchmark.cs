using ExtenCiv.Benchmarks.Benchmarks.Abstractions;
using ExtenCiv.Composition.LightInject.Builders;
using ExtenCiv.Games.Abstractions;

namespace ExtenCiv.Benchmarks.Benchmarks
{
    /// <summary>
    ///     Benchmarks for LightInject.
    /// </summary>
    public sealed class LightInjectBenchmark : IBenchmark
    {
        /// <summary>
        ///     Runs the benchmark program with the AlphaCiv configuration.
        /// </summary>
        public IGame AlphaCiv() => new LightInjectAlphaCiv().BuildGame();

        /// <summary>
        ///     Runs the benchmark program with the SemiCiv configuration.
        /// </summary>
        public IGame SemiCiv() => new LightInjectSemiCiv().BuildGame();

        public override string ToString() => "LightInject";
    }
}
