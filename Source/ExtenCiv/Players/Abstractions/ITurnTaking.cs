namespace ExtenCiv.Players.Abstractions
{
    /// <summary>
    ///     A turn-taking decides which player is currently in turn.
    /// </summary>
    public interface ITurnTaking
    {
        /// <summary>
        ///     The current player in turn.
        /// </summary>
        Player CurrentPlayer { get; }

        /// <summary>
        ///     The number of the current round.
        /// </summary>
        int CurrentRound { get; }

        /// <summary>
        ///     Ends the turn of the current player, moving on to the next player.
        ///     Once all players have ended their turns, a new round begins.
        /// </summary>
        void AdvanceToNextPlayer();
    }
}
