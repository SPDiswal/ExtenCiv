using ExtenCiv.Boards;
using ExtenCiv.Cities;
using ExtenCiv.Tiles;
using ExtenCiv.Units;

namespace ExtenCiv.X
{
    public interface IGame
    {
        /// <summary>
        ///     Returns the tile at the given position.
        /// </summary>
        /// <param name="position">The position in the world matrix.</param>
        ITile TileAt(SquarePosition position);

        /// <summary>
        ///     Returns the city at the given position, or <c>null</c> if there is no city.
        /// </summary>
        /// <param name="position">The position in the world matrix.</param>
        ICity CityAt(SquarePosition position);

        /// <summary>
        ///     Returns the unit at the given position, or <c>null</c> if there is no unit.
        /// </summary>
        /// <param name="position">The position in the world matrix.</param>
        IUnit UnitAt(SquarePosition position);

        /// <summary>
        ///     Ends the turn of the current player, moving on to the next player.
        ///     Once all players have ended their turns, a new round begins.
        /// </summary>
        void EndTurn();

        /// <summary>
        ///     Moves a unit to a new position, potentially going into combat with an opponent unit.
        /// </summary>
        /// <param name="from">The current position of the unit.</param>
        /// <param name="to">The destination of the unit.</param>
        /// <returns>
        ///     <c>true</c> if the move is valid and has been done,
        ///     or <c>false</c> if the move is invalid and has been rejected.
        /// </returns>
        bool MoveUnit(SquarePosition from, SquarePosition to);

        /// <summary>
        ///     Performs the special action of the unit at the given position.
        /// </summary>
        /// <param name="position">The position of the unit.</param>
        void PerformUnitActionAt(SquarePosition position);

        /// <summary>
        ///     Changes the current production in the city at the given position.
        /// </summary>
        /// <param name="position">The position of the city.</param>
        /// <param name="production">The new production in the city.</param>
        void ChangeCityProductionAt(SquarePosition position, Production production);

        /// <summary>
        ///     Changes the workforce focus in the city at the given position.
        /// </summary>
        /// <param name="position">The position of the city.</param>
        /// <param name="workforceFocus">The new workforce focus to apply in the city.</param>
        void ChangeCityWorkforceFocusAt(SquarePosition position, WorkforceFocus workforceFocus);
    }
}
