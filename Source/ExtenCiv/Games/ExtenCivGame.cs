using System.Collections.Generic;
using System.Linq;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Games.Abstractions;
using ExtenCiv.Games.ViewModels;
using ExtenCiv.Players;
using ExtenCiv.Players.Abstractions;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Winners.Abstractions;
using ExtenCiv.WorldAges.Abstractions;
using ExtenCiv.WorldMaps.Abstractions;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Games
{
    /// <summary>
    ///     A game is the facade of the ExtenCiv system.
    ///     It exposes a view model of the current state of the game as well as actions for changing the game state properly.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     City layer,
    ///     Terrain layer,
    ///     Unit layer,
    ///     Turn-taking,
    ///     World age,
    ///     Winner strategy,
    ///     Dictionary from terrain types and unit type to type names,
    ///     Dictionary from type names to production projects.
    /// </summary>
    public sealed class ExtenCivGame : IGame
    {
        private readonly ICityLayer cityLayer;
        private readonly ITerrainLayer terrainLayer;
        private readonly IUnitLayer unitLayer;
        private readonly ITurnTaking turnTaking;
        private readonly IWorldAge worldAge;
        private readonly IWinnerStrategy winnerStrategy;
        private readonly IDictionary<string, IProductionProject> productionProjects;

        public ExtenCivGame(ICityLayer cityLayer,
                            ITerrainLayer terrainLayer,
                            IUnitLayer unitLayer,
                            ITurnTaking turnTaking,
                            IWorldAge worldAge,
                            IWinnerStrategy winnerStrategy,
                            IDictionary<string, IProductionProject> productionProjects)
        {
            this.cityLayer = cityLayer;
            this.terrainLayer = terrainLayer;
            this.unitLayer = unitLayer;
            this.turnTaking = turnTaking;
            this.worldAge = worldAge;
            this.winnerStrategy = winnerStrategy;
            this.productionProjects = productionProjects;
        }

        /// <summary>
        ///     Returns a view model of the terrain at the given tile.
        /// </summary>
        public TerrainViewModel TerrainAt(ITile tile)
        {
            var terrain = terrainLayer.Terrains.Single(t => t.Location.Equals(tile));
            return new TerrainViewModel { Type = terrain.Type };
        }

        /// <summary>
        ///     Returns a view model of the city at the given tile, or <c>null</c> if there is no city.
        /// </summary>
        public CityViewModel CityAt(ITile tile)
        {
            var city = FindCityAt(tile);
            return city == null
                       ? null
                       : new CityViewModel
                       {
                           Type = city.Type, // TODO: Unit test.
                           Owner = city.Owner,
                           Population = city.Population
                       };
        }

        private ICity FindCityAt(ITile tile) => cityLayer.Cities.SingleOrDefault(c => c.Location.Equals(tile));

        /// <summary>
        ///     Returns a view model of the unit at the given tile, or <c>null</c> if there is no unit.
        /// </summary>
        public UnitViewModel UnitAt(ITile tile)
        {
            var unit = FindUnitAt(tile);
            return unit == null
                       ? null
                       : new UnitViewModel
                       {
                           Type = unit.Type,
                           Owner = unit.Owner,
                           RemainingMovement = unit.RemainingMoves
                       };
        }

        private IUnit FindUnitAt(ITile tile) => unitLayer.Units.SingleOrDefault(u => u.Location.Equals(tile));

        /// <summary>
        ///     The current player in turn.
        /// </summary>
        public Player CurrentPlayer => turnTaking.CurrentPlayer;

        /// <summary>
        ///     The winner of the game.
        /// </summary>
        public Player Winner => winnerStrategy.Winner;

        /// <summary>
        ///     The current world age.
        /// </summary>
        public int WorldAge => worldAge.CurrentWorldAge;

        /// <summary>
        ///     The current round number.
        /// </summary>
        public int Round => turnTaking.CurrentRound;

        /// <summary>
        ///     Ends the turn of the current player, moving on to the next player.
        ///     Once all players have ended their turns, a new round begins.
        /// </summary>
        public void EndTurn() => turnTaking.AdvanceToNextPlayer();

        /// <summary>
        ///     Moves a unit to a new tile, potentially going into combat with an opponent unit.
        /// </summary>
        /// <param name="origin">The current tile of the unit.</param>
        /// <param name="destination">The destination of the unit.</param>
        public void MoveUnit(ITile origin, ITile destination) => FindUnitAt(origin).MoveTo(destination);

        /// <summary>
        ///     Performs the special action of the unit at the given tile.
        /// </summary>
        public void PerformUnitActionAt(ITile tile) => FindUnitAt(tile).PerformAction();

        /// <summary>
        ///     Changes the current production project in the city at the given tile.
        /// </summary>
        /// <param name="tile">The tile of the city.</param>
        /// <param name="productionProject">The unit type that is the new production project in the city.</param>
        public void ChangeCityProductionProjectAt(ITile tile, string productionProject)
            => FindCityAt(tile).ProductionProject = productionProjects[productionProject];

        /// <summary>
        ///     Identifies the dependency injection container used to construct this game.
        /// </summary>
        public string ContainerName { get; set; } = "None";

        public override string ToString() => ContainerName;
    }
}
