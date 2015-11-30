namespace ExtenCiv.WorldAges
{
    /// <summary>
    ///     The world age progresses linearly by 100 years every round, starting in 4000 BCE.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     None.
    /// </summary>
    public sealed class LinearWorldAge : IWorldAgeStrategy
    {
        /// <summary>
        ///     The current age of the world, in years.
        /// </summary>
        public int WorldAge { get; private set; } = -4000;

        /// <summary>
        ///     Moves one round forward in time.
        /// </summary>
        public void AdvanceWorldAge() => WorldAge += 100;
    }
}
