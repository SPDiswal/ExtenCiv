namespace ExtenCiv.Benchmarks.Common
{
    /// <summary>
    ///     A benchmark program of a single dependency injection container.
    /// </summary>
    public interface IBenchmark
    {
        /// <summary>
        /// Runs the benchmark program with the AlphaCiv configuration.
        /// </summary>
        void AlphaCiv();

        /// <summary>
        /// Runs the benchmark program with the BetaCiv configuration.
        /// </summary>
        void BetaCiv();

        /// <summary>
        /// Runs the benchmark program with the GammaCiv configuration.
        /// </summary>
        void GammaCiv();

        /// <summary>
        /// Runs the benchmark program with the DeltaCiv configuration.
        /// </summary>
        void DeltaCiv();

        /// <summary>
        /// Runs the benchmark program with the EpsilonCiv configuration.
        /// </summary>
        void EpsilonCiv();

        /// <summary>
        /// Runs the benchmark program with the ZetaCiv configuration.
        /// </summary>
        void ZetaCiv();

        /// <summary>
        /// Runs the benchmark program with the EtaCiv configuration.
        /// </summary>
        void EtaCiv();

        /// <summary>
        /// Runs the benchmark program with the ThetaCiv configuration.
        /// </summary>
        void ThetaCiv();

        /// <summary>
        /// Runs the benchmark program with the SemiCiv configuration.
        /// </summary>
        void SemiCiv();
    }
}
