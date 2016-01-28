using ExtenCiv.Games.ViewModels;
using ExtenCiv.Players;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Games.Abstractions
{
    /// <summary>
    ///     A game is the facade of the ExtenCiv system.
    ///     It exposes a view model of the current state of the game as well as actions for changing the game state properly.
    /// </summary>
    public interface IGame
    {
        /// <summary>
        ///     Returns a view model of the terrain at the given tile.
        /// </summary>
        TerrainViewModel TerrainAt(ITile tile);

        /// <summary>
        ///     Returns a view model of the city at the given tile, or <c>null</c> if there is no city.
        /// </summary>
        CityViewModel CityAt(ITile tile);

        /// <summary>
        ///     Returns a view model of the unit at the given tile, or <c>null</c> if there is no unit.
        /// </summary>
        UnitViewModel UnitAt(ITile tile);

        /// <summary>
        ///     The name of the current player in turn.
        /// </summary>
        Player CurrentPlayer { get; }

        /// <summary>
        ///     The name of the winner of the game.
        /// </summary>
        Player Winner { get; }

        /// <summary>
        ///     The current world age.
        /// </summary>
        int WorldAge { get; }

        /// <summary>
        ///     The current round number.
        /// </summary>
        int Round { get; }

        /// <summary>
        ///     Ends the turn of the current player, moving on to the next player.
        ///     Once all players have ended their turns, a new round begins.
        /// </summary>
        void EndTurn();

        /// <summary>
        ///     Moves a unit to a new tile, potentially going into combat with an opponent unit.
        /// </summary>
        /// <param name="origin">The current tile of the unit.</param>
        /// <param name="destination">The destination of the unit.</param>
        void MoveUnit(ITile origin, ITile destination);

        /// <summary>
        ///     Performs the special action of the unit at the given tile.
        /// </summary>
        void PerformUnitActionAt(ITile tile);

        /// <summary>
        ///     Changes the current production project in the city at the given tile.
        /// </summary>
        /// <param name="tile">The tile of the city.</param>
        /// <param name="productionProject">The unit type that is the new production project in the city.</param>
        void ChangeCityProductionProjectAt(ITile tile, string productionProject);

        /// <summary>
        ///     Identifies the dependency injection container used to construct this game.
        /// </summary>
        string ContainerName { get; set; }
    }
}
