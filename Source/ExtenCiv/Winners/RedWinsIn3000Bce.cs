using ExtenCiv.Players;
using ExtenCiv.WorldAges;

namespace ExtenCiv.Winners
{
    /// <summary>
    ///     From 3000 BCE and onwards, the winner is always a player named 'Red'. Until then, there is no winner.
    ///     <para></para>
    ///     Dependencies: World age strategy.
    /// </summary>
    public sealed class RedWinsIn3000Bce : IWinnerStrategy
    {
        private readonly IWorldAgeStrategy worldAgeStrategy;

        public RedWinsIn3000Bce(IWorldAgeStrategy worldAgeStrategy) { this.worldAgeStrategy = worldAgeStrategy; }

        /// <summary>
        ///     The winner of the game, or <c>Player.Nobody</c> if there is no winner yet.
        /// </summary>
        public Player Winner => worldAgeStrategy.WorldAge >= -3000 ? Player.For("Red") : Player.Nobody;
    }
}
