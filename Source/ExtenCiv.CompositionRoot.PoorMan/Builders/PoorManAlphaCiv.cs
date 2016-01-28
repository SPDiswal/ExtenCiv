using System.Collections.Generic;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Types;
using ExtenCiv.Cities.Types.Factories;
using ExtenCiv.Cities.Utilities;
using ExtenCiv.Cities.Workforce;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using ExtenCiv.CompositionRoot.Utilities;
using ExtenCiv.Games;
using ExtenCiv.Games.Abstractions;
using ExtenCiv.Players;
using ExtenCiv.Terrains.Abstractions;
using ExtenCiv.Terrains.Types;
using ExtenCiv.Terrains.Types.Factories;
using ExtenCiv.Terrains.Utilities;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Combat;
using ExtenCiv.Units.Movement;
using ExtenCiv.Units.Types;
using ExtenCiv.Units.Types.Factories;
using ExtenCiv.Units.Types.ProductionProjects;
using ExtenCiv.Units.Utilities;
using ExtenCiv.Winners;
using ExtenCiv.WorldAges;
using ExtenCiv.WorldMaps;

namespace ExtenCiv.Composition.PoorMan.Builders
{
    public sealed class PoorManAlphaCiv : IGameBuilder
    {
        public IGame BuildGame()
        {
            // This composition of the game using poor man's DI does not support automatic registration.
            // To give a fairer view in the benchmark, it invokes the reflection used for automatic registration,
            // though it discards the results.
            var cityTypes = TypeConstraints.Cities;
            var cityFactoryTypes = TypeConstraints.CityFactories;
            var terrainTypes = TypeConstraints.Terrains;
            var terrainFactoryTypes = TypeConstraints.TerrainFactories;
            var unitTypes = TypeConstraints.Units;
            var unitFactoryTypes = TypeConstraints.UnitFactories;
            var productionProjectTypes = TypeConstraints.ProductionProjects;

            // :::: TURN-TAKING ::::
            var players = new[] { new Player("Red"), new Player("Blue") };
            var turnTaking = new RoundRobinTurns(players);

            // :::: UNIT COMBAT ::::
            var unitCombat = new AttackerIsAlwaysVictorious();

            // :::: WORLD MAP COLLECTIONS ::::
            var cities = new HashSet<ICity>(new CityEqualityComparer());
            var terrains = new HashSet<ITerrain>(new TerrainEqualityComparer());
            var units = new HashSet<IUnit>(new UnitEqualityComparer());

            // :::: CITIES ::::
            var cityFactory = new CityFactory(
                () => new FriendlyCityManagementOnly<City>(
                          new ProductionAccumulation<City>(
                              new FixedGeneratedProduction<City>(
                                  new NoCityGrowth<City>(new City())
                                  ), units, turnTaking
                              ), turnTaking
                          ));

            // :::: TERRAINS ::::
            var forestsFactory = new ForestsFactory(() => new Forests());
            var hillsFactory = new HillsFactory(() => new Hills());
            var mountainsFactory = new MountainsFactory(() => new Mountains());
            var oceansFactory = new OceansFactory(() => new Oceans());
            var plainsFactory = new PlainsFactory(() => new Plains());

            // :::: UNITS ::::
            var archerFactory = new ArcherFactory(
                () => new FriendlyUnitManagementOnly<Archer>(
                          new NoEntranceToImpassableTerrain<Archer>(
                              new NoFriendlyUnitStacking<Archer>(
                                  new LimitedMoveRange<Archer>(
                                      new OneToOneCombatEngagement<Archer>(
                                          new CityConquest<Archer>(
                                              new RestorationOfMoves<Archer>(
                                                  new MoveCosts<Archer>(
                                                      new Movability<Archer>(new Archer())
                                                      ), turnTaking
                                                  ), cities
                                              ), units, unitCombat
                                          )
                                      ), units
                                  ), terrains
                              ), turnTaking
                          ));

            var legionFactory = new LegionFactory(
                () => new FriendlyUnitManagementOnly<Legion>(
                          new NoEntranceToImpassableTerrain<Legion>(
                              new NoFriendlyUnitStacking<Legion>(
                                  new LimitedMoveRange<Legion>(
                                      new OneToOneCombatEngagement<Legion>(
                                          new CityConquest<Legion>(
                                              new RestorationOfMoves<Legion>(
                                                  new MoveCosts<Legion>(
                                                      new Movability<Legion>(new Legion())
                                                      ), turnTaking
                                                  ), cities
                                              ), units, unitCombat
                                          )
                                      ), units
                                  ), terrains
                              ), turnTaking
                          ));

            var settlerFactory = new SettlerFactory(
                () => new FriendlyUnitManagementOnly<Settler>(
                          new NoEntranceToImpassableTerrain<Settler>(
                              new NoFriendlyUnitStacking<Settler>(
                                  new LimitedMoveRange<Settler>(
                                      new OneToOneCombatEngagement<Settler>(
                                          new RestorationOfMoves<Settler>(
                                              new MoveCosts<Settler>(
                                                  new Movability<Settler>(new Settler())
                                                  ), turnTaking
                                              ), units, unitCombat
                                          )
                                      ), units
                                  ), terrains
                              ), turnTaking
                          ));

            // :::: WORLD MAP LAYERS ::::
            var cityLayer = new SimpleFixedCityLayer(cities, cityFactory);

            var terrainLayer = new SimpleFixedTerrainLayer(terrains,
                                                           hillsFactory,
                                                           mountainsFactory,
                                                           oceansFactory,
                                                           plainsFactory);

            var unitLayer = new SimpleFixedUnitLayer(units, archerFactory, legionFactory, settlerFactory);

            // :::: WORLD AGE ::::
            var worldAge = new LinearWorldAge(turnTaking);

            // :::: WINNER STRATEGY ::::
            var winnerStrategy = new RedWinsIn3000Bce(worldAge);

            // :::: PRODUCTION PROJECTS ::::
            var productionProjects = new Dictionary<string, IProductionProject>
            {
                ["Archer"] = new ArcherProject(archerFactory),
                ["Legion"] = new LegionProject(legionFactory),
                ["Settler"] = new SettlerProject(settlerFactory),
            };

            // :::: GAME ::::
            var game = new ExtenCivGame(cityLayer, terrainLayer, unitLayer,
                                        turnTaking, worldAge, winnerStrategy, productionProjects)
            {
                ContainerName = "Manual/AlphaCiv"
            };

            return game;
        }
    }
}
