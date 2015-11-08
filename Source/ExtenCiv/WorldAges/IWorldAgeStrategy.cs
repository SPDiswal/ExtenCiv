namespace ExtenCiv.WorldAges
{
    /// <summary>
    /// A world age strategy decides how the world age calendar progresses during the game.
    /// </summary>
    public interface IWorldAgeStrategy
    {
        /// <summary>
        ///     The current age of the world, in years.
        /// </summary>
        int WorldAge { get; }

        /// <summary>
        ///     Moves one step forward in time.
        /// </summary>
        void AdvanceWorldAge();
    }
}
