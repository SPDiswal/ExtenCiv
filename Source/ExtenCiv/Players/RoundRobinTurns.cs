using System;
using ExtenCiv.Players.Abstractions;
using ExtenCiv.Players.Events;

namespace ExtenCiv.Players
{
    /// <summary>
    ///     Players take turns in a round-robin fashion, beginning with round 1.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Array of players.
    /// </summary>
    public sealed class RoundRobinTurns : ITurnTaking, INotifyBeginningNextRound
    {
        private readonly Player[] players;
        private int indexOfCurrentPlayer;

        public event EventHandler<BeginningNextRoundEventArgs> BeginningNextRound;

        /// <summary>
        ///     Creates a round-robin turn taking from an array of players.
        ///     The first player in the array is in turn from start.
        /// </summary>
        /// <param name="players">An array of the players taking turns.</param>
        public RoundRobinTurns(Player[] players)
        {
            this.players = players;
            indexOfCurrentPlayer = 0;
        }

        /// <summary>
        ///     The current player in turn.
        /// </summary>
        public Player CurrentPlayer => players[indexOfCurrentPlayer];

        /// <summary>
        ///     The number of the current round.
        /// </summary>
        public int CurrentRound { get; private set; } = 1;

        /// <summary>
        ///     Ends the turn of the current player, moving on to the next player.
        ///     Once all players have ended their turns, a new round begins.
        /// </summary>
        public void AdvanceToNextPlayer()
        {
            indexOfCurrentPlayer = (indexOfCurrentPlayer + 1) % players.Length;
            if (indexOfCurrentPlayer == 0) BeginNextRound();
        }

        private void BeginNextRound()
        {
            CurrentRound++;
            BeginningNextRound?.Invoke(this, new BeginningNextRoundEventArgs(CurrentRound));
        }
    }
}
