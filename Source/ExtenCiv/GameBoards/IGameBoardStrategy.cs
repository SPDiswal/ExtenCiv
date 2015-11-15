using System.Collections.Generic;
using ExtenCiv.Boards;
using ExtenCiv.Cities;
using ExtenCiv.Tiles;
using ExtenCiv.Units;

namespace ExtenCiv.GameBoards
{
    /// <summary>
    ///     A game board strategy decides how cities, tiles and units are related to positions on the game board.
    /// </summary>
    public interface IGameBoardStrategy
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
