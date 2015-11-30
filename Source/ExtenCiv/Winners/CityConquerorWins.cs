using System.Linq;
using ExtenCiv.GameBoards;
using ExtenCiv.Players;

namespace ExtenCiv.Winners
{
    /// <summary>
    ///     The winner is the first player to be the owner of all cities on the game board. Until then, there is no winner.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Game board strategy.
    /// </summary>
    public sealed class CityConquerorWins : IWinnerStrategy
    {
        private readonly IGameBoardStrategy gameBoardStrategy;

        public CityConquerorWins(IGameBoardStrategy gameBoardStrategy) { this.gameBoardStrategy = gameBoardStrategy; }

        /// <summary>
        ///     The winner of the game, or <c>Player.Nobody</c> if there is no winner yet.
        /// </summary>
        public Player Winner
        {
            get
            {
                var cityOwners = gameBoardStrategy.Cities.Values.Select(city => city.Owner).Distinct().ToArray();
                return cityOwners.Length == 1 ? cityOwners.Single() : Player.Nobody;
            }
        }
    }
}
