using ExtenCiv.Composition.Autofac.Builders;
using ExtenCiv.Composition.LightInject.Builders;
using ExtenCiv.Composition.Ninject.Builders;
using ExtenCiv.Composition.PoorMan.Builders;
using ExtenCiv.Composition.SimpleInjector.Builders;
using ExtenCiv.Composition.StructureMap.Builders;
using ExtenCiv.Composition.Unity.Builders;
using ExtenCiv.Composition.Windsor.Builders;
using ExtenCiv.CompositionRoot.DryIoc.Builders;
using ExtenCiv.Games.Abstractions;
using ExtenCiv.Players;
using ExtenCiv.Utilities.Extensions;
using ExtenCiv.WorldMaps.Tiles;
using ExtenCiv.WorldMaps.Tiles.Abstractions;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Integration.SemiCiv
{
    public sealed class TestSemiCiv
    {
        /// <summary>
        ///     The world age is 4000 BCE in round 1 (at game start).
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void WorldAge_Is4000BCE_InRound1(IGame game)
        {
            // :::: ASSERT ::::
            game.WorldAge.Should().Be(-4000);
        }

        /// <summary>
        ///     The world age is 3900 BCE in round 2.
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void WorldAge_Is3900BCE_InRound2(IGame game)
        {
            // :::: ACT ::::
            SkipRounds(game, 1);

            // :::: ASSERT ::::
            game.WorldAge.Should().Be(-3900);
        }

        /// <summary>
        ///     The world age is 50 CE in round 42.
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void WorldAge_Is50CE_InRound42(IGame game)
        {
            // :::: ACT ::::
            SkipRounds(game, 42);

            // :::: ASSERT ::::
            game.WorldAge.Should().Be(50);
        }

        /// <summary>
        ///     There is no winner at game start.
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void Winner_IsNobody_AtGameStart(IGame game)
        {
            // :::: ASSERT ::::
            game.Winner.Should().Be(Player.Nobody);
        }

        /// <summary>
        ///     Red is the winner when he has conquered the Blue City.
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void Winner_IsRed_WhenRedHasConqueredTheBlueCity(IGame game)
        {
            // :::: ARRANGE ::::
            game.MoveUnit(RedArcherTile, To(3, 1));
            SkipRounds(game, 1);

            // :::: ACT ::::
            game.MoveUnit(From(3, 1), BlueCityTile);

            // :::: ASSERT ::::
            game.Winner.Should().Be(Red);
        }

        /// <summary>
        ///     Blue is the winner when he has conquered the Red City.
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void Winner_IsBlue_WhenBlueHasConqueredTheRedCity(IGame game)
        {
            // :::: ARRANGE ::::
            game.EndTurn();
            game.MoveUnit(BlueLegionTile, To(2, 1));
            SkipRounds(game, 1);

            // :::: ACT ::::
            game.MoveUnit(From(2, 1), RedCityTile);

            // :::: ASSERT ::::
            game.Winner.Should().Be(Blue);
        }

        /// <summary>
        ///     The Red City at (1, 1) produces a Red Chariot after four rounds.
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void RedCityAt1x1_ProducesARedChariot_AfterFourRounds(IGame game)
        {
            // :::: ARRANGE ::::
            game.ChangeCityProductionProjectAt(RedCityTile, Chariot);

            // :::: ACT ::::
            SkipRounds(game, 4);

            // :::: ASSERT ::::
            game.UnitAt(RedCityTile).Owner.Should().Be(Red);
            game.UnitAt(RedCityTile).Type.Should().Be(Chariot);
            game.UnitAt(RedCityTile).RemainingMovement.Should().Be(1);
        }

        /// <summary>
        ///     The Blue City at (4, 1) produces a Blue Chariot after four rounds.
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void BlueCityAt4x1_ProducesABlueChariot_AfterFourRounds(IGame game)
        {
            // :::: ARRANGE ::::
            game.EndTurn();
            game.ChangeCityProductionProjectAt(BlueCityTile, Chariot);

            // :::: ACT ::::
            SkipRounds(game, 4);

            // :::: ASSERT ::::
            game.UnitAt(BlueCityTile).Owner.Should().Be(Blue);
            game.UnitAt(BlueCityTile).Type.Should().Be(Chariot);
            game.UnitAt(BlueCityTile).RemainingMovement.Should().Be(1);
        }

        /// <summary>
        ///     When Red is in turn, the Red Archer at (2, 0) fortifies.
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void RedArcherAt2x0_Fortifies_WhenRedIsInTurn(IGame game)
        {
            // :::: ACT ::::
            game.PerformUnitActionAt(RedArcherTile);

            // :::: ASSERT ::::
            game.UnitAt(RedArcherTile).RemainingMovement.Should().Be(0);
        }

        /// <summary>
        ///     When Blue is in turn, the Red Archer at (2, 0) does not fortify.
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void RedArcherAt2x0_DoesNotFortify_WhenBlueIsInTurn(IGame game)
        {
            // :::: ARRANGE ::::
            game.EndTurn();

            // :::: ACT ::::
            game.PerformUnitActionAt(RedArcherTile);

            // :::: ASSERT ::::
            game.UnitAt(RedArcherTile).RemainingMovement.Should().Be(1);
        }

        /// <summary>
        ///     When Blue is in turn, the Blue Chariot spawned at (4, 1) fortifies.
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void BlueChariotAt4x1_Fortifies_WhenBlueIsInTurn(IGame game)
        {
            // :::: ARRANGE ::::
            game.EndTurn();
            game.ChangeCityProductionProjectAt(BlueCityTile, Chariot);
            SkipRounds(game, 4);

            // :::: ACT ::::
            game.PerformUnitActionAt(BlueCityTile);

            // :::: ASSERT ::::
            game.UnitAt(BlueCityTile).RemainingMovement.Should().Be(0);
        }

        /// <summary>
        ///     When Red is in turn, the Blue Chariot spawned at (4, 1) does not fortify.
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void BlueChariotAt4x1_DoesNotFortify_WhenRedIsInTurn(IGame game)
        {
            // :::: ARRANGE ::::
            game.EndTurn();
            game.ChangeCityProductionProjectAt(BlueCityTile, Chariot);
            SkipRounds(game, 4);
            game.EndTurn();

            // :::: ACT ::::
            game.PerformUnitActionAt(BlueCityTile);

            // :::: ASSERT ::::
            game.UnitAt(BlueCityTile).RemainingMovement.Should().Be(1);
        }

        /// <summary>
        ///     When Red is in turn, the Red Settler at (4, 3) builds a Red City.
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void RedSettlerAt4x3_BuildsARedCity_WhenRedIsInTurn(IGame game)
        {
            // :::: ACT ::::
            game.PerformUnitActionAt(RedSettlerTile);

            // :::: ASSERT ::::
            game.UnitAt(RedSettlerTile).Should().BeNull();
            game.CityAt(RedSettlerTile).Should().NotBeNull();
        }

        /// <summary>
        ///     When Blue is in turn, the Red Settler at (4, 3) does not build a city.
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void RedSettlerAt4x3_DoesNotBuildACity_WhenBlueIsInTurn(IGame game)
        {
            // :::: ARRANGE ::::
            game.EndTurn();

            // :::: ACT ::::
            game.PerformUnitActionAt(RedSettlerTile);

            // :::: ASSERT ::::
            game.UnitAt(RedSettlerTile).Should().NotBeNull();
            game.CityAt(RedSettlerTile).Should().BeNull();
        }

        /// <summary>
        ///     For every dependency injection container, the dependencies have been resolved correctly.
        /// </summary>
        public static TheoryData ForEveryContainer => new TheoryData
            <IGame>
        {
            new PoorManSemiCiv().BuildGame(),
            new AutofacSemiCiv().BuildGame(),
            new DryIocSemiCiv().BuildGame(),
            new LightInjectSemiCiv().BuildGame(),
            new NinjectSemiCiv().BuildGame(),
            new SimpleInjectorSemiCiv().BuildGame(),
            new StructureMapSemiCiv().BuildGame(),
            new UnitySemiCiv().BuildGame(),
            new WindsorSemiCiv().BuildGame(),
        };

        #region HELPERS: Shortcuts

        private const string Chariot = "Chariot";

        private static Player Red => new Player("Red");
        private static Player Blue => new Player("Blue");

        private static ITile From(int row, int column) => new SquareTile(row, column);
        private static ITile To(int row, int column) => new SquareTile(row, column);
        private static ITile Location(int row, int column) => new SquareTile(row, column);

        private static ITile RedCityTile => Location(1, 1);
        private static ITile BlueCityTile => Location(4, 1);

        private static ITile RedArcherTile => Location(2, 0);
        private static ITile BlueLegionTile => Location(3, 2);
        private static ITile RedSettlerTile => Location(4, 3);

        private static void SkipRounds(IGame game, int rounds) => (2 * rounds).Times(game.EndTurn);

        #endregion
    }
}
