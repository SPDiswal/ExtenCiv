using ExtenCiv.Players;

namespace ExtenCiv.Winners.Abstractions
{
    /// <summary>
    ///     A winner strategy decides which player has won the game.
    /// </summary>
    public interface IWinnerStrategy
    {
        /// <summary>
        ///     The winner of the game, or <c>Player.Nobody</c> if there is no winner yet.
        /// </summary>
        Player Winner { get; }
    }
}
