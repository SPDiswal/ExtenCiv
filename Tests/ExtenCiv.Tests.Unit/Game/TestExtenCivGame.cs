using System.Collections.Generic;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Games;
using ExtenCiv.Players;
using ExtenCiv.Players.Abstractions;
using ExtenCiv.Terrains.Abstractions;
using ExtenCiv.Terrains.Types;
using ExtenCiv.Tests.Utilities.Extensions;
using ExtenCiv.Tests.Utilities.Stubs;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Winners.Abstractions;
using ExtenCiv.WorldAges.Abstractions;
using ExtenCiv.WorldMaps.Abstractions;
using ExtenCiv.WorldMaps.Tiles;
using ExtenCiv.WorldMaps.Tiles.Abstractions;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.Game
{
    public sealed class TestExtenCivGame
    {
        /// <summary>
        ///     The game facade exposes terrains as view models.
        /// </summary>
        /// <param name="terrain">The terrain to expose.</param>
        /// <param name="expectedTerrainType">The expected string to represent the terrain type in the view model.</param>
        [Theory]
        [MemberData(nameof(WhenTheTileHasATerrain))]
        public void TerrainAt_ReturnsTheTerrainOnTheTile(ITerrain terrain, string expectedTerrainType)
        {
            // :::: ARRANGE ::::
            var stubTerrainLayer = StubWorld.TerrainLayer(new[] { terrain });
            var game = new ExtenCivGame(DummyCityLayer, stubTerrainLayer, DummyUnitLayer,
                                        DummyTurnTaking, DummyWorldAge, DummyWinnerStrategy,
                                        DummyProjects);

            // :::: ACT ::::
            var location = terrain.Location;
            var actualTerrainViewModel = game.TerrainAt(location);

            // :::: ASSERT ::::
            actualTerrainViewModel.Type.Should().Be(expectedTerrainType);
        }

        /// <summary>
        ///     When a tile has a terrain, the game facade exposes it as a view model.
        /// </summary>
        public static TheoryData WhenTheTileHasATerrain => new TheoryData
            <ITerrain, string>
        {
            /* There are Forests at (1, 1). */
            { Forests.At(1, 1), "Forests" },
            //
            /* There are Hills at (2, 1). */
            { Hills.At(2, 1), "Hills" },
            //
            /* There are Mountains at (0, 1). */
            { Mountains.At(0, 1), "Mountains" },
            //
            /* There are Oceans at (2, 2). */
            { Oceans.At(2, 2), "Oceans" },
            //
            /* There are Plains at (1, 3). */
            { Plains.At(1, 3), "Plains" },
        };

        /// <summary>
        ///     The game facade exposes non-existing cities as null values.
        /// </summary>
        [Fact]
        public void CityAt_ReturnsNull_WhenThereIsNoCityOnTheTile()
        {
            // :::: ARRANGE ::::
            var game = new ExtenCivGame(DummyCityLayer, DummyTerrainLayer, DummyUnitLayer,
                                        DummyTurnTaking, DummyWorldAge, DummyWinnerStrategy,
                                        DummyProjects);

            // :::: ACT ::::
            var actualCityViewModel = game.CityAt(DummyTile);

            // :::: ASSERT ::::
            actualCityViewModel.Should().BeNull();
        }

        /// <summary>
        ///     The game facade exposes cities as view models.
        /// </summary>
        /// <param name="city">The city to expose.</param>
        [Theory]
        [MemberData(nameof(WhenTheTileHasACity))]
        public void CityAt_ReturnsTheCityOnTheTile(ICity city)
        {
            // :::: ARRANGE ::::
            var stubCityLayer = StubWorld.CityLayer(new[] { city });
            var game = new ExtenCivGame(stubCityLayer, DummyTerrainLayer, DummyUnitLayer,
                                        DummyTurnTaking, DummyWorldAge, DummyWinnerStrategy,
                                        DummyProjects);

            // :::: ACT ::::
            var location = city.Location;
            var actualCityViewModel = game.CityAt(location);

            // :::: ASSERT ::::
            actualCityViewModel.Owner.Should().Be(city.Owner);
            actualCityViewModel.Population.Should().Be(city.Population);
        }

        /// <summary>
        ///     When a tile has a city, the game facade exposes it as a view model.
        /// </summary>
        public static TheoryData WhenTheTileHasACity => new TheoryData
            <ICity>
        {
            /* There is a Red City of size 1 at (1, 1). */
            Red.City().At(1, 1).OfSize(1),
            //
            /* There is Blue City of size 3 at (4, 1). */
            Blue.City().At(4, 1).OfSize(3),
        };

        /// <summary>
        ///     The game facade exposes non-existing units as null values.
        /// </summary>
        [Fact]
        public void UnitAt_ReturnsNull_WhenThereIsNoUnitOnTheTile()
        {
            // :::: ARRANGE ::::
            var game = new ExtenCivGame(DummyCityLayer, DummyTerrainLayer, DummyUnitLayer,
                                        DummyTurnTaking, DummyWorldAge, DummyWinnerStrategy,
                                        DummyProjects);

            // :::: ACT ::::
            var actualUnitViewModel = game.UnitAt(DummyTile);

            // :::: ASSERT ::::
            actualUnitViewModel.Should().BeNull();
        }

        /// <summary>
        ///     The game facade exposes units as view models.
        /// </summary>
        /// <param name="unit">The unit to expose.</param>
        /// <param name="expectedUnitType">The expected string to represent the unit type in the view model.</param>
        [Theory]
        [MemberData(nameof(WhenTheTileHasAUnit))]
        public void UnitAt_ReturnsTheUnitOnTheTile(IUnit unit, string expectedUnitType)
        {
            // :::: ARRANGE ::::
            var stubUnitLayer = StubWorld.UnitLayer(new[] { unit });
            var game = new ExtenCivGame(DummyCityLayer, DummyTerrainLayer, stubUnitLayer,
                                        DummyTurnTaking, DummyWorldAge, DummyWinnerStrategy,
                                        DummyProjects);

            // :::: ACT ::::
            var location = unit.Location;
            var actualUnitViewModel = game.UnitAt(location);

            // :::: ASSERT ::::
            actualUnitViewModel.Type.Should().Be(expectedUnitType);
            actualUnitViewModel.Owner.Should().Be(unit.Owner);
            actualUnitViewModel.RemainingMovement.Should().Be(unit.RemainingMoves);
        }

        /// <summary>
        ///     When a tile has a unit, the game facade exposes it as a view model.
        /// </summary>
        public static TheoryData WhenTheTileHasAUnit => new TheoryData
            <IUnit, string>
        {
            /* There is a Red Archer with one remaining move at (2, 0). */
            { Red.Archer().At(2, 0).ThatCanMove(1), "Archer" },
            //
            /* There is a Blue Legion with two remaining moves at (3, 2). */
            { Blue.Legion().At(3, 2).ThatCanMove(2), "Legion" },
            //
            /* There is a Red Settler with no remaining moves at (4, 3). */
            { Red.Settler().At(4, 3).ThatCanMove(0), "Settler" },
        };

        /// <summary>
        ///     The game facade exposes the current player in turn.
        /// </summary>
        /// <param name="player">The player to expose.</param>
        [Theory]
        [MemberData(nameof(WhenTheGameKnowsThePlayerInTurn))]
        public void CurrentPlayer_ReturnsTheCurrentPlayerInTurn(Player player)
        {
            // :::: ARRANGE ::::
            var stubTurnTaking = A.Fake<ITurnTaking>();
            var game = new ExtenCivGame(DummyCityLayer, DummyTerrainLayer, DummyUnitLayer,
                                        stubTurnTaking, DummyWorldAge, DummyWinnerStrategy,
                                        DummyProjects);

            A.CallTo(() => stubTurnTaking.CurrentPlayer).Returns(player);

            // :::: ACT ::::
            var actualCurrentPlayer = game.CurrentPlayer;

            // :::: ASSERT ::::
            actualCurrentPlayer.Should().Be(player);
        }

        /// <summary>
        ///     When the game knows the player that is currently in turn, the game facade exposes him.
        /// </summary>
        public static TheoryData WhenTheGameKnowsThePlayerInTurn => new TheoryData
            <Player>
        {
            /* Red is in turn. */
            Red,
            //
            /* Blue is in turn. */
            Blue,
        };

        /// <summary>
        ///     The game facade exposes the winner.
        /// </summary>
        /// <param name="winner">The winner to expose.</param>
        [Theory]
        [MemberData(nameof(WhenTheGameKnowsTheWinner))]
        public void Winner_ReturnsTheWinner(Player winner)
        {
            // :::: ARRANGE ::::
            var stubWinnerStrategy = A.Fake<IWinnerStrategy>();
            var game = new ExtenCivGame(DummyCityLayer, DummyTerrainLayer, DummyUnitLayer,
                                        DummyTurnTaking, DummyWorldAge, stubWinnerStrategy,
                                        DummyProjects);

            A.CallTo(() => stubWinnerStrategy.Winner).Returns(winner);

            // :::: ACT ::::
            var actualWinner = game.Winner;

            // :::: ASSERT ::::
            actualWinner.Should().Be(winner);
        }

        /// <summary>
        ///     When the game knows the winner, the game facade exposes him.
        /// </summary>
        public static TheoryData WhenTheGameKnowsTheWinner => new TheoryData
            <Player>
        {
            /* There is no winner. */
            Player.Nobody,
            //
            /* The winner is Red. */
            Red,
            //
            /* The winner is Blue. */
            Blue,
        };

        /// <summary>
        ///     The game facade exposes the world age.
        /// </summary>
        /// <param name="worldAge">The world age to expose.</param>
        [Theory]
        [MemberData(nameof(WhenTheGameKnowsTheWorldAge))]
        public void WorldAge_ReturnsTheWorldAge(int worldAge)
        {
            // :::: ARRANGE ::::
            var stubWorldAge = A.Fake<IWorldAge>();
            var game = new ExtenCivGame(DummyCityLayer, DummyTerrainLayer, DummyUnitLayer,
                                        DummyTurnTaking, stubWorldAge, DummyWinnerStrategy,
                                        DummyProjects);

            A.CallTo(() => stubWorldAge.CurrentWorldAge).Returns(worldAge);

            // :::: ACT ::::
            var actualWorldAge = game.WorldAge;

            // :::: ASSERT ::::
            actualWorldAge.Should().Be(worldAge);
        }

        /// <summary>
        ///     When the game knows the world age, the game facade exposes it.
        /// </summary>
        public static TheoryData WhenTheGameKnowsTheWorldAge => new TheoryData
            <int>
        {
            /* The world age is 4000 BCE. */
            -4000,
            //
            /* The world age is 1200 BCE. */
            -1200,
            //
            /* The world age is 1550 CE. */
            1550,
        };

        /// <summary>
        ///     The game facade exposes the current round number.
        /// </summary>
        /// <param name="round">The round number expose.</param>
        [Theory]
        [MemberData(nameof(WhenTheGameKnowsTheRoundNumber))]
        public void Round_ReturnsTheCurrentRoundNumber(int round)
        {
            // :::: ARRANGE ::::
            var stubTurnTaking = A.Fake<ITurnTaking>();
            var game = new ExtenCivGame(DummyCityLayer, DummyTerrainLayer, DummyUnitLayer,
                                        stubTurnTaking, DummyWorldAge, DummyWinnerStrategy,
                                        DummyProjects);

            A.CallTo(() => stubTurnTaking.CurrentRound).Returns(round);

            // :::: ACT ::::
            var actualRound = game.Round;

            // :::: ASSERT ::::
            actualRound.Should().Be(round);
        }

        /// <summary>
        ///     When the game knows the player that is currently in turn, the game facade exposes him.
        /// </summary>
        public static TheoryData WhenTheGameKnowsTheRoundNumber => new TheoryData
            <int>
        {
            /* Round 1. */
            1,
            //
            /* Round 20. */
            20,
            //
            /* Round 42. */
            42,
        };

        /// <summary>
        ///     When ending turns, the game facade invokes the AdvanceToNextPlayer method on the turn-taking.
        /// </summary>
        [Fact]
        public void EndTurn_InvokesAdvanceToNextPlayerOnTheTurnTaking()
        {
            // :::: ARRANGE ::::
            var spyTurnTaking = A.Fake<ITurnTaking>();
            var game = new ExtenCivGame(DummyCityLayer, DummyTerrainLayer, DummyUnitLayer,
                                        spyTurnTaking, DummyWorldAge, DummyWinnerStrategy,
                                        DummyProjects);

            // :::: ACT ::::
            game.EndTurn();

            // :::: ASSERT ::::
            A.CallTo(() => spyTurnTaking.AdvanceToNextPlayer()).MustHaveHappened();
        }

        /// <summary>
        ///     When moving a unit, the game facade invokes the MoveTo method on the unit.
        /// </summary>
        /// <param name="origin">The origin of the move.</param>
        /// <param name="destination">The destination of the move.</param>
        [Theory]
        [MemberData(nameof(WhenMovingAUnit))]
        public void MoveUnit_InvokesMoveToOnTheUnit(ITile origin, ITile destination)
        {
            // :::: ARRANGE ::::
            var spyUnit = A.Fake<IUnit>();
            var stubUnitLayer = StubWorld.UnitLayer(new[] { spyUnit });
            var game = new ExtenCivGame(DummyCityLayer, DummyTerrainLayer, stubUnitLayer,
                                        DummyTurnTaking, DummyWorldAge, DummyWinnerStrategy,
                                        DummyProjects);

            A.CallTo(() => spyUnit.Location).Returns(origin);

            // :::: ACT ::::
            game.MoveUnit(origin, destination);

            // :::: ASSERT ::::
            A.CallTo(() => spyUnit.MoveTo(destination)).MustHaveHappened();
        }

        /// <summary>
        ///     When moving a unit, the game facade invokes MoveTo on the unit.
        /// </summary>
        public static TheoryData WhenMovingAUnit => new TheoryData
            <ITile, ITile>
        {
            /* Moving a unit from (1, 1) to (2, 1). */
            { From(1, 1), To(2, 1) },
            //
            /* Moving a unit from (3, 2) to (2, 2). */
            { From(3, 2), To(2, 2) },
        };

        /// <summary>
        ///     When performing a unit action, the game facade invokes the PerformAction method on the unit.
        /// </summary>
        /// <param name="tile">The location of the unit.</param>
        [Theory]
        [MemberData(nameof(WhenPerformingAUnitAction))]
        public void PerformUnitActionAt_InvokesPerformActionOnTheUnit(ITile tile)
        {
            // :::: ARRANGE ::::
            var spyUnit = A.Fake<IUnit>();
            var stubUnitLayer = StubWorld.UnitLayer(new[] { spyUnit });
            var game = new ExtenCivGame(DummyCityLayer, DummyTerrainLayer, stubUnitLayer,
                                        DummyTurnTaking, DummyWorldAge, DummyWinnerStrategy,
                                        DummyProjects);

            A.CallTo(() => spyUnit.Location).Returns(tile);

            // :::: ACT ::::
            game.PerformUnitActionAt(tile);

            // :::: ASSERT ::::
            A.CallTo(() => spyUnit.PerformAction()).MustHaveHappened();
        }

        /// <summary>
        ///     When performing a unit action, the game facade invokes PerformAction on the unit.
        /// </summary>
        public static TheoryData WhenPerformingAUnitAction => new TheoryData
            <ITile>
        {
            /* Performing a unit action at (2, 0). */
            Location(2, 0),
            //
            /* Performing a unit action at (4, 3). */
            Location(4, 3),
        };

        /// <summary>
        ///     When changing production project in a city, the game facade invokes the ProductionProject setter on the city.
        /// </summary>
        /// <param name="tile">The location of the unit.</param>
        /// <param name="project">The production project to set.</param>
        [Theory]
        [MemberData(nameof(WhenChangingProductionProjectInACity))]
        public void ChangeCityProductionProjectAt_InvokesSetProductionProjectOnTheCity(ITile tile, string project)
        {
            // :::: ARRANGE ::::
            var dummyProject = A.Fake<IProductionProject>();
            var stubProjects = new Dictionary<string, IProductionProject> { [project] = dummyProject };
            var spyCity = A.Fake<ICity>();
            var stubCityLayer = StubWorld.CityLayer(new[] { spyCity });
            var game = new ExtenCivGame(stubCityLayer, DummyTerrainLayer, DummyUnitLayer,
                                        DummyTurnTaking, DummyWorldAge, DummyWinnerStrategy,
                                        stubProjects);

            A.CallTo(() => spyCity.Location).Returns(tile);

            // :::: ACT ::::
            game.ChangeCityProductionProjectAt(tile, project);

            // :::: ASSERT ::::
            // The setter of ProductionProject has been invoked.
            A.CallTo(spyCity)
             .Where(x => x.Method.Name == $"set_{nameof(spyCity.ProductionProject)}"
                         && ReferenceEquals(x.Arguments[0], dummyProject))
             .MustHaveHappened();
        }

        /// <summary>
        ///     When performing a unit action, the game facade invokes PerformAction on the unit.
        /// </summary>
        public static TheoryData WhenChangingProductionProjectInACity => new TheoryData
            <ITile, string>
        {
            /* Changing the production project in a city at (1, 1) to 'Archer'. */
            { Location(1, 1), "Archer" },
            //
            /* Changing the production project in a city at (4, 1) to 'Legion'. */
            { Location(4, 1), "Legion" },
        };

        #region HELPERS: Shortcuts

        private static Player Red => new Player("Red");
        private static Player Blue => new Player("Blue");

        private static ITerrain Forests => new Forests();
        private static ITerrain Hills => new Hills();
        private static ITerrain Mountains => new Mountains();
        private static ITerrain Oceans => new Oceans();
        private static ITerrain Plains => new Plains();

        private static ITile From(int row, int column) => new SquareTile(row, column);
        private static ITile To(int row, int column) => new SquareTile(row, column);
        private static ITile Location(int row, int column) => new SquareTile(row, column);

        #endregion

        #region HELPERS: Dummies

        private static ICityLayer DummyCityLayer => StubWorld.EmptyCityLayer;
        private static ITerrainLayer DummyTerrainLayer => StubWorld.EmptyTerrainLayer;
        private static IUnitLayer DummyUnitLayer => StubWorld.EmptyUnitLayer;
        private static ITurnTaking DummyTurnTaking => A.Fake<ITurnTaking>();
        private static IWorldAge DummyWorldAge => A.Fake<IWorldAge>();
        private static IWinnerStrategy DummyWinnerStrategy => A.Fake<IWinnerStrategy>();

        private static ITile DummyTile => new SquareTile(0, 0);

        private static IDictionary<string, IProductionProject> DummyProjects
            => new Dictionary<string, IProductionProject>();

        #endregion
    }
}
