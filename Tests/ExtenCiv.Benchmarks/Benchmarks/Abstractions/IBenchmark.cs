using ExtenCiv.Games.Abstractions;

namespace ExtenCiv.Benchmarks.Benchmarks.Abstractions
{
    /// <summary>
    ///     A benchmark program of a single dependency injection container.
    /// </summary>
    public interface IBenchmark
    {
        /// <summary>
        /// Runs the benchmark program with the AlphaCiv configuration.
        /// </summary>
        IGame AlphaCiv();

        /// <summary>
        /// Runs the benchmark program with the SemiCiv configuration.
        /// </summary>
        IGame SemiCiv();
    }
}
