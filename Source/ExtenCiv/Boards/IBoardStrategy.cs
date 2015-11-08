using System.Collections.Generic;
using ExtenCiv.Cities;
using ExtenCiv.Tiles;
using ExtenCiv.Units;

namespace ExtenCiv.Boards
{
    /// <summary>
    ///     A board strategy decides how cities, tiles and units are related to positions on the game board.
    /// </summary>
    public interface IBoardStrategy
    {
        /// <summary>
        ///     Returns the set of cities on the game board.
        /// </summary>
        IDictionary<IPosition, ICity> Cities { get; }

        /// <summary>
        ///     Returns the set of tiles on the game board.
        /// </summary>
        IDictionary<IPosition, ITile> Tiles { get; }

        /// <summary>
        ///     Returns the set of units on the game board.
        /// </summary>
        IDictionary<IPosition, IUnit> Units { get; }
    }
}
