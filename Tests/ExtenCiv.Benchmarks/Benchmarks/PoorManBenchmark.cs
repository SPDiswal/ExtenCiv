using ExtenCiv.Benchmarks.Benchmarks.Abstractions;
using ExtenCiv.Composition.PoorMan.Builders;
using ExtenCiv.Games.Abstractions;

namespace ExtenCiv.Benchmarks.Benchmarks
{
    /// <summary>
    ///     Benchmark for poor man's dependency injection (manually resolved games).
    /// </summary>
    public sealed class PoorManBenchmark : IBenchmark
    {
        /// <summary>
        ///     Runs the benchmark program with the AlphaCiv configuration.
        /// </summary>
        public IGame AlphaCiv() => new PoorManAlphaCiv().BuildGame();

        /// <summary>
        ///     Runs the benchmark program with the SemiCiv configuration.
        /// </summary>
        public IGame SemiCiv() => new PoorManSemiCiv().BuildGame();

        public override string ToString() => "Poor man's DI";
    }
}
