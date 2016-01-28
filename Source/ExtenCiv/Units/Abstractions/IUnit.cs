using System;
using ExtenCiv.Players;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Units.Abstractions
{
    /// <summary>
    ///     A unit belongs to a player, can be moved around on the game board, engage in combat and perform special actions.
    /// </summary>
    public interface IUnit
    {
        /// <summary>
        ///     The unique identifier of this unit.
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        ///     The type string identifying the type of this unit.
        /// </summary>
        string Type { get; set; }

        /// <summary>
        ///     The location of this unit on the world map.
        /// </summary>
        ITile Location { get; set; }

        /// <summary>
        ///     The player that controls this unit.
        /// </summary>
        Player Owner { get; set; }

        /// <summary>
        ///     The remaining moves in the current round for this unit.
        /// </summary>
        int RemainingMoves { get; set; }

        /// <summary>
        ///     The total moves per round for this unit.
        /// </summary>
        int TotalMoves { get; set; }

        /// <summary>
        ///     The attacking strength of this unit.
        /// </summary>
        int Attack { get; set; }

        /// <summary>
        ///     The defensive strength of this unit.
        /// </summary>
        int Defence { get; set; }

        /// <summary>
        ///     Moves this unit to the specified location.
        /// </summary>
        /// <param name="destination">The tile to move the unit to.</param>
        void MoveTo(ITile destination);

        /// <summary>
        ///     Performs the special action of this unit.
        /// </summary>
        void PerformAction();
    }

    /// <summary>
    ///     A unit belongs to a player, can be moved around on the game board, engage in combat and perform special actions.
    /// </summary>
    public interface IUnit<TUnit> : IUnit where TUnit : IUnit<TUnit>
    {
    }
}
