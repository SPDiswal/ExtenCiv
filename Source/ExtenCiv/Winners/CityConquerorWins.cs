using ExtenCiv.Players;

namespace ExtenCiv.Winners
{
    /// <summary>
    ///     The winner is the first player to be the owner of all cities on the game board. Until then, there is no winner.
    ///     <para></para>
    ///     Dependencies: Game board strategy.
    /// </summary>
    public sealed class CityConquerorWins : IWinnerStrategy
    {
        /// <summary>
        ///     The winner of the game, or <c>Player.Nobody</c> if there is no winner yet.
        /// </summary>
        public Player Winner { get; } = Player.Nobody;
    }
}
