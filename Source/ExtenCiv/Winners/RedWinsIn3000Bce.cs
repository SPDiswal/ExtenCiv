using ExtenCiv.Players;
using ExtenCiv.WorldAges;
using static ExtenCiv.Players.Player;

namespace ExtenCiv.Winners
{
    /// <summary>
    ///     From 3000 BCE and onwards, the winner is always a player named 'Red'. Until then, there is no winner.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     World age strategy.
    /// </summary>
    public sealed class RedWinsIn3000Bce : IWinnerStrategy
    {
        private const int YearOfWinning = -3000;
        private static readonly Player Red = new Player("Red");

        private readonly IWorldAgeStrategy worldAgeStrategy;

        public RedWinsIn3000Bce(IWorldAgeStrategy worldAgeStrategy) { this.worldAgeStrategy = worldAgeStrategy; }

        /// <summary>
        ///     The winner of the game, or <c>Player.Nobody</c> if there is no winner yet.
        /// </summary>
        public Player Winner => worldAgeStrategy.WorldAge >= YearOfWinning ? Red : Nobody;
    }
}
