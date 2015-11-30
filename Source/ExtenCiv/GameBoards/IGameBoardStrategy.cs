using System.Collections.Generic;
using ExtenCiv.Cities;
using ExtenCiv.Terrains;
using ExtenCiv.Units;

namespace ExtenCiv.GameBoards
{
    /// <summary>
    ///     A game board strategy decides how terrains, cities and units are related to positions on the game board.
    /// </summary>
    public interface IGameBoardStrategy
    {
        /// <summary>
        ///     Returns the set of cities on the game board.
        /// </summary>
        IDictionary<Position, ICity> Cities { get; }

        /// <summary>
        ///     Returns the set of terrains on the game board.
        /// </summary>
        IDictionary<Position, ITerrain> Terrains { get; }

        /// <summary>
        ///     Returns the set of units on the game board.
        /// </summary>
        IDictionary<Position, IUnit> Units { get; }
    }
}
