namespace ExtenCiv.WorldAges.Abstractions
{
    /// <summary>
    ///     A world age decides how the calendar progresses during the game.
    /// </summary>
    public interface IWorldAge
    {
        /// <summary>
        ///     The current age of the world, in years.
        /// </summary>
        int CurrentWorldAge { get; }
    }
}
