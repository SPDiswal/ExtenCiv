using ExtenCiv.Players;

namespace ExtenCiv.Winners
{
    public sealed class CityConquerorWins : IWinnerStrategy
    {
        /// <summary>
        ///     The winner of the game, or <c>Player.Nobody</c> if there is no winner yet.
        /// </summary>
        public Player Winner { get; } = Player.Nobody;
    }
}