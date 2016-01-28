using ExtenCiv.Benchmarks.Benchmarks.Abstractions;
using ExtenCiv.Composition.StructureMap.Builders;
using ExtenCiv.Games.Abstractions;

namespace ExtenCiv.Benchmarks.Benchmarks
{
    /// <summary>
    ///     Benchmark for StructureMap.
    /// </summary>
    public sealed class StructureMapBenchmark : IBenchmark
    {
        /// <summary>
        ///     Runs the benchmark program with the AlphaCiv configuration.
        /// </summary>
        public IGame AlphaCiv() => new StructureMapAlphaCiv().BuildGame();

        /// <summary>
        ///     Runs the benchmark program with the SemiCiv configuration.
        /// </summary>
        public IGame SemiCiv() => new StructureMapSemiCiv().BuildGame();

        public override string ToString() => "StructureMap";
    }
}
