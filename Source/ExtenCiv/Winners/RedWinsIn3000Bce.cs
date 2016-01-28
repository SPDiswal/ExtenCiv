using ExtenCiv.Players;
using ExtenCiv.Winners.Abstractions;
using ExtenCiv.WorldAges.Abstractions;
using static ExtenCiv.Players.Player;

namespace ExtenCiv.Winners
{
    /// <summary>
    ///     From 3000 BCE and onwards, the winner is always a player named 'Red'. Until then, there is no winner.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     World age.
    /// </summary>
    public sealed class RedWinsIn3000Bce : IWinnerStrategy
    {
        private const int YearOfWinning = -3000;
        private static readonly Player Red = new Player("Red");

        private readonly IWorldAge worldAge;

        public RedWinsIn3000Bce(IWorldAge worldAge) { this.worldAge = worldAge; }

        /// <summary>
        ///     The winner of the game, or <c>Player.Nobody</c> if there is no winner yet.
        /// </summary>
        public Player Winner => worldAge.CurrentWorldAge >= YearOfWinning ? Red : Nobody;
    }
}
