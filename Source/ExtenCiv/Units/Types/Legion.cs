using System;
using ExtenCiv.Players;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Units.Types
{
    /// <summary>
    ///     Legions move 1 tile per round, have an attacking strength of 4 and a defensive strength of 2.
    /// </summary>
    public sealed class Legion : IUnit<Legion>
    {
        /// <summary>
        ///     The unique identifier of this unit.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        ///     The type string identifying the type of this unit.
        /// </summary>
        public string Type { get; set; } = "Legion";

        /// <summary>
        ///     The location of this unit on the world map.
        /// </summary>
        public ITile Location { get; set; }

        /// <summary>
        ///     The player that controls this unit.
        /// </summary>
        public Player Owner { get; set; } = Player.Nobody;

        /// <summary>
        ///     The remaining moves in the current round for this unit.
        /// </summary>
        public int RemainingMoves { get; set; } = 1;

        /// <summary>
        ///     The total moves per round for this unit.
        /// </summary>
        public int TotalMoves { get; set; } = 1;

        /// <summary>
        ///     The attacking strength of this unit.
        /// </summary>
        public int Attack { get; set; } = 4;

        /// <summary>
        ///     The defensive strength of this unit.
        /// </summary>
        public int Defence { get; set; } = 2;

        /// <summary>
        ///     Moves this unit to the specified location.
        /// </summary>
        /// <param name="destination">The tile to move the unit to.</param>
        public void MoveTo(ITile destination) { }

        /// <summary>
        ///     Performs the special action of this unit.
        /// </summary>
        public void PerformAction() { }

        public override string ToString() => $"{Owner} {Type}";
    }
}
