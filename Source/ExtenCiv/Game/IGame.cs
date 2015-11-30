using ExtenCiv.GameBoards;

namespace ExtenCiv.Game
{
    /// <summary>
    ///     A game is the facade of the ExtenCiv system.
    ///     It exposes a view model of the current state of the game as well as actions for changing the game state properly.
    /// </summary>
    public interface IGame
    {
        /// <summary>
        ///     Returns a view model of the terrain at the given position.
        /// </summary>
        /// <param name="position">The position in the world matrix.</param>
        TerrainViewModel TerrainAt(Position position);

        /// <summary>
        ///     Returns a view model of the city at the given position, or <c>null</c> if there is no city.
        /// </summary>
        /// <param name="position">The position in the world matrix.</param>
        CityViewModel CityAt(Position position);

        /// <summary>
        ///     Returns a view model of the unit at the given position, or <c>null</c> if there is no unit.
        /// </summary>
        /// <param name="position">The position in the world matrix.</param>
        UnitViewModel UnitAt(Position position);

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
        bool MoveUnit(Position @from, Position to);

        /// <summary>
        ///     Performs the special action of the unit at the given position.
        /// </summary>
        /// <param name="position">The position of the unit.</param>
        void PerformUnitActionAt(Position position);

        // TODO: City production.

        //        /// <summary>
        //        ///     Changes the current production in the city at the given position.
        //        /// </summary>
        //        /// <param name="position">The position of the city.</param>
        //        /// <param name="production">The new production in the city.</param>
        //        void ChangeCityProductionAt(Position position, Production production);
        //
        //        /// <summary>
        //        ///     Changes the workforce focus in the city at the given position.
        //        /// </summary>
        //        /// <param name="position">The position of the city.</param>
        //        /// <param name="workforceFocus">The new workforce focus to apply in the city.</param>
        //        void ChangeCityWorkforceFocusAt(Position position, WorkforceFocus workforceFocus);
    }
}
