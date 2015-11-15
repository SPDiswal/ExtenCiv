using System.Collections.Generic;
using System.Linq;

namespace ExtenCiv.Players
{
    /// <summary>
    ///     Players take turns in a round-robin fashion.
    ///     <para></para>
    ///     Dependencies: Collection of available players.
    /// </summary>
    public sealed class RoundRobinTurnTaking : ITurnTakingStrategy
    {
        private readonly Player[] players;
        private int indexOfCurrentPlayer;

        /// <summary>
        ///     Creates a round-robin turn strategy from a collection of players.
        ///     The first player in the collection is in turn from start.
        /// </summary>
        /// <param name="playerStrategy">A player strategy that defines the collection of players taking turns.</param>
        public RoundRobinTurnTaking(IPlayerStrategy playerStrategy)
        {
            players = playerStrategy.Players.ToArray();
            indexOfCurrentPlayer = 0;
        }

        /// <summary>
        ///     The current player in turn.
        /// </summary>
        public Player CurrentPlayer => players[indexOfCurrentPlayer];

        /// <summary>
        ///     Ends the turn of the current player, moving on to the next player.
        ///     Once all players have ended their turns, a new round begins.
        /// </summary>
        public void AdvanceToNextPlayer()
        {
            if (indexOfCurrentPlayer != players.Length - 1) indexOfCurrentPlayer = indexOfCurrentPlayer + 1;
            else indexOfCurrentPlayer = 0;
        }
    }
}
