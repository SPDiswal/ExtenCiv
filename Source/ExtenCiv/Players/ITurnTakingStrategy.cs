namespace ExtenCiv.Players
{
    /// <summary>
    ///     A turn-taking strategy decides which player is currently in turn.
    /// </summary>
    public interface ITurnTakingStrategy
    {
        /// <summary>
        ///     The current player in turn.
        /// </summary>
        Player CurrentPlayer { get; }

        /// <summary>
        ///     Ends the turn of the current player, moving on to the next player.
        ///     Once all players have ended their turns, a new round begins.
        /// </summary>
        void AdvanceToNextPlayer();
    }
}
