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

namespace ExtenCiv.Tests.Integration.Common
{
    public sealed class TestExtenCiv
    {
        /// <summary>
        ///     The current player in turn is Red at game start.
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void CurrentPlayer_IsRed_AtGameStart(IGame game)
        {
            // :::: ASSERT ::::
            game.CurrentPlayer.Should().Be(Red);
        }

        /// <summary>
        ///     The current player in turn is Blue after Red.
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void CurrentPlayer_IsBlue_AfterRed(IGame game)
        {
            // :::: ACT ::::
            game.EndTurn();

            // :::: ASSERT ::::
            game.CurrentPlayer.Should().Be(Blue);
        }

        /// <summary>
        ///     The current player in turn is Red after Blue.
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void CurrentPlayer_IsRed_AfterBlue(IGame game)
        {
            // :::: ARRANGE ::::
            game.EndTurn();

            // :::: ACT ::::
            game.EndTurn();

            // :::: ASSERT ::::
            game.CurrentPlayer.Should().Be(Red);
        }

        /// <summary>
        ///     There are Oceans at (1, 0).
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void TerrainAt1x0_IsOceans(IGame game)
        {
            // :::: ASSERT ::::
            game.TerrainAt(Location(1, 0)).Type.Should().Be(Oceans);
        }

        /// <summary>
        ///     There are Hills at (0, 1).
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void TerrainAt0x1_IsHills(IGame game)
        {
            // :::: ASSERT ::::
            game.TerrainAt(Location(0, 1)).Type.Should().Be(Hills);
        }

        /// <summary>
        ///     There are Mountains at (2, 2).
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void TerrainAt2x2_IsMountains(IGame game)
        {
            // :::: ASSERT ::::
            game.TerrainAt(Location(2, 2)).Type.Should().Be(Mountains);
        }

        /// <summary>
        ///     There are Plains at (2, 1).
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void TerrainAt2x1_IsPlains(IGame game)
        {
            // :::: ASSERT ::::
            game.TerrainAt(Location(2, 1)).Type.Should().Be(Plains);
        }

        /// <summary>
        ///     When Red is in turn, the Red Archer at (2, 0) moves to (2, 1).
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void RedArcherAt2x0_MovesTo2x1_WhenRedIsInTurn(IGame game)
        {
            // :::: ACT ::::
            game.MoveUnit(RedArcherTile, To(2, 1));

            // :::: ASSERT ::::
            game.UnitAt(RedArcherTile).Should().BeNull();
            game.UnitAt(Location(2, 1)).Owner.Should().Be(Red);
            game.UnitAt(Location(2, 1)).Type.Should().Be(Archer);
            game.UnitAt(Location(2, 1)).RemainingMovement.Should().Be(0);
        }

        /// <summary>
        ///     When Blue is in turn, the Red Archer at (2, 0) does not move to (2, 1).
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void RedArcherAt2x0_DoesNotMoveTo2x1_WhenBlueIsInTurn(IGame game)
        {
            // :::: ARRANGE ::::
            game.EndTurn();

            // :::: ACT ::::
            game.MoveUnit(RedArcherTile, To(2, 1));

            // :::: ASSERT ::::
            game.UnitAt(RedArcherTile).Owner.Should().Be(Red);
            game.UnitAt(RedArcherTile).Type.Should().Be(Archer);
            game.UnitAt(RedArcherTile).RemainingMovement.Should().Be(1);
            game.UnitAt(Location(2, 1)).Should().BeNull();
        }

        /// <summary>
        ///     The Red Archer defeats the Blue Legion at (3, 2).
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void RedArcher_DefeatsTheBlueLegionAt3x2(IGame game)
        {
            // :::: ARRANGE ::::
            game.MoveUnit(RedArcherTile, To(3, 1));
            SkipRounds(game, 1);

            // :::: ACT ::::
            game.MoveUnit(From(3, 1), BlueLegionTile);

            // :::: ASSERT ::::
            game.UnitAt(Location(3, 1)).Should().BeNull();
            game.UnitAt(BlueLegionTile).Owner.Should().Be(Red);
            game.UnitAt(BlueLegionTile).Type.Should().Be(Archer);
            game.UnitAt(BlueLegionTile).RemainingMovement.Should().Be(0);
        }

        /// <summary>
        ///     The Blue Legion defeats the Red Settler at (4, 3).
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void BlueLegion_DefeatsTheRedSettlerAt4x3(IGame game)
        {
            // :::: ARRANGE ::::
            game.EndTurn();

            // :::: ACT ::::
            game.MoveUnit(BlueLegionTile, RedSettlerTile);

            // :::: ASSERT ::::
            game.UnitAt(BlueLegionTile).Should().BeNull();
            game.UnitAt(RedSettlerTile).Owner.Should().Be(Blue);
            game.UnitAt(RedSettlerTile).Type.Should().Be(Legion);
            game.UnitAt(RedSettlerTile).RemainingMovement.Should().Be(0);
        }

        /// <summary>
        ///     The Red Archer conquers the Blue City at (4, 1).
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void RedArcher_ConquersTheBlueCityAt4x1(IGame game)
        {
            // :::: ARRANGE ::::
            game.MoveUnit(RedArcherTile, To(3, 1));
            SkipRounds(game, 1);

            // :::: ACT ::::
            game.MoveUnit(From(3, 1), BlueCityTile);

            // :::: ASSERT ::::
            game.CityAt(BlueCityTile).Owner.Should().Be(Red);
        }

        /// <summary>
        ///     The Blue Legion conquers the Red City at (1, 1).
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void BlueLegion_ConquersTheRedCityAt1x1(IGame game)
        {
            // :::: ARRANGE ::::
            game.EndTurn();
            game.MoveUnit(BlueLegionTile, To(2, 1));
            SkipRounds(game, 1);

            // :::: ACT ::::
            game.MoveUnit(From(2, 1), RedCityTile);

            // :::: ASSERT ::::
            game.CityAt(RedCityTile).Owner.Should().Be(Blue);
        }

        /// <summary>
        ///     The Red Settler does not conquer the Blue City at (4, 1).
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void RedSettler_DoesNotConquerTheBlueCityAt4x1(IGame game)
        {
            // :::: ARRANGE ::::
            game.MoveUnit(RedSettlerTile, To(4, 2));
            SkipRounds(game, 1);

            // :::: ACT ::::
            game.MoveUnit(From(4, 2), BlueCityTile);

            // :::: ASSERT ::::
            game.CityAt(BlueCityTile).Owner.Should().Be(Blue);
        }

        /// <summary>
        ///     The Red Archer at (2, 0) does not move to Oceans at (1, 0).
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void RedArcherAt2x0_DoesNotMoveToOceansAt1x0(IGame game)
        {
            // :::: ACT ::::
            game.MoveUnit(RedArcherTile, OceansTile);

            // :::: ASSERT ::::
            game.UnitAt(RedArcherTile).Owner.Should().Be(Red);
            game.UnitAt(RedArcherTile).Type.Should().Be(Archer);
            game.UnitAt(RedArcherTile).RemainingMovement.Should().Be(1);
            game.UnitAt(OceansTile).Should().BeNull();
        }

        /// <summary>
        ///     The Blue Legion at (3, 2) does not move to Mountains at (2, 2).
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void BlueLegionAt3x2_DoesNotMoveToMountainsAt2x2(IGame game)
        {
            // :::: ACT ::::
            game.MoveUnit(BlueLegionTile, MountainsTile);

            // :::: ASSERT ::::
            game.UnitAt(BlueLegionTile).Owner.Should().Be(Blue);
            game.UnitAt(BlueLegionTile).Type.Should().Be(Legion);
            game.UnitAt(BlueLegionTile).RemainingMovement.Should().Be(1);
            game.UnitAt(MountainsTile).Should().BeNull();
        }

        /// <summary>
        ///     The Red Archer does not move onto the Red Settler at (4, 3).
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void RedArcher_DoesNotMoveOntoTheRedSettlerAt4x3(IGame game)
        {
            // :::: ARRANGE ::::
            game.MoveUnit(RedArcherTile, To(3, 1));
            SkipRounds(game, 1);

            game.MoveUnit(From(3, 1), To(4, 2));
            SkipRounds(game, 1);

            // :::: ACT ::::
            game.MoveUnit(From(4, 2), RedSettlerTile);

            // :::: ASSERT ::::
            game.UnitAt(Location(4, 2)).Owner.Should().Be(Red);
            game.UnitAt(Location(4, 2)).Type.Should().Be(Archer);
            game.UnitAt(Location(4, 2)).RemainingMovement.Should().Be(1);

            game.UnitAt(RedSettlerTile).Owner.Should().Be(Red);
            game.UnitAt(RedSettlerTile).Type.Should().Be(Settler);
            game.UnitAt(RedSettlerTile).RemainingMovement.Should().Be(1);
        }

        /// <summary>
        ///     The Red Archer at (2, 0) does not move more than one tile during a round.
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void RedArcherAt2x0_DoesNotMoveMoreThanOneTileDuringARound(IGame game)
        {
            // :::: ARRANGE ::::
            game.MoveUnit(RedArcherTile, To(3, 1));

            // :::: ACT ::::
            game.MoveUnit(From(3, 1), RedArcherTile);

            // :::: ASSERT ::::
            game.UnitAt(RedArcherTile).Should().BeNull();
            game.UnitAt(Location(3, 1)).Owner.Should().Be(Red);
            game.UnitAt(Location(3, 1)).Type.Should().Be(Archer);
            game.UnitAt(Location(3, 1)).RemainingMovement.Should().Be(0);
        }

        /// <summary>
        ///     The Blue Legion at (3, 2) does not move more than one tile during a round.
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void BlueLegionAt3x2_DoesNotMoveMoreThanOneTileDuringARound(IGame game)
        {
            // :::: ARRANGE ::::
            game.EndTurn();
            game.MoveUnit(BlueLegionTile, To(3, 1));

            // :::: ACT ::::
            game.MoveUnit(From(3, 1), BlueLegionTile);

            // :::: ASSERT ::::
            game.UnitAt(BlueLegionTile).Should().BeNull();
            game.UnitAt(Location(3, 1)).Owner.Should().Be(Blue);
            game.UnitAt(Location(3, 1)).Type.Should().Be(Legion);
            game.UnitAt(Location(3, 1)).RemainingMovement.Should().Be(0);
        }

        /// <summary>
        ///     The Red Settler at (4, 3) does not move more than one tile during a round.
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void RedSettlerAt4x3_DoesNotMoveMoreThanOneTileDuringARound(IGame game)
        {
            // :::: ARRANGE ::::
            game.MoveUnit(RedSettlerTile, To(4, 2));

            // :::: ACT ::::
            game.MoveUnit(From(4, 2), RedSettlerTile);

            // :::: ASSERT ::::
            game.UnitAt(RedSettlerTile).Should().BeNull();
            game.UnitAt(Location(4, 2)).Owner.Should().Be(Red);
            game.UnitAt(Location(4, 2)).Type.Should().Be(Settler);
            game.UnitAt(Location(4, 2)).RemainingMovement.Should().Be(0);
        }

        /// <summary>
        ///     The Red City at (1, 1) produces a Red Archer after two rounds.
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void RedCityAt1x1_ProducesARedArcher_AfterTwoRounds(IGame game)
        {
            // :::: ARRANGE ::::
            game.ChangeCityProductionProjectAt(RedCityTile, Archer);

            // :::: ACT ::::
            SkipRounds(game, 2);

            // :::: ASSERT ::::
            game.UnitAt(RedCityTile).Owner.Should().Be(Red);
            game.UnitAt(RedCityTile).Type.Should().Be(Archer);
            game.UnitAt(RedCityTile).RemainingMovement.Should().Be(1);
        }

        /// <summary>
        ///     The Blue City at (4, 1) produces a Blue Legion after three rounds.
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void BlueCityAt4x1_ProducesABlueLegion_AfterThreeRounds(IGame game)
        {
            // :::: ARRANGE ::::
            game.EndTurn();
            game.ChangeCityProductionProjectAt(BlueCityTile, Legion);

            // :::: ACT ::::
            SkipRounds(game, 3);

            // :::: ASSERT ::::
            game.UnitAt(BlueCityTile).Owner.Should().Be(Blue);
            game.UnitAt(BlueCityTile).Type.Should().Be(Legion);
            game.UnitAt(BlueCityTile).RemainingMovement.Should().Be(1);
        }

        /// <summary>
        ///     The Blue City at (4, 1) produces a Blue Settler after five rounds.
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void BlueCityAt4x1_ProducesABlueSettler_AfterFiveRounds(IGame game)
        {
            // :::: ARRANGE ::::
            game.EndTurn();
            game.ChangeCityProductionProjectAt(BlueCityTile, Settler);

            // :::: ACT ::::
            SkipRounds(game, 5);

            // :::: ASSERT ::::
            game.UnitAt(BlueCityTile).Owner.Should().Be(Blue);
            game.UnitAt(BlueCityTile).Type.Should().Be(Settler);
            game.UnitAt(BlueCityTile).RemainingMovement.Should().Be(1);
        }

        /// <summary>
        ///     For every dependency injection container, the dependencies have been resolved correctly.
        /// </summary>
        public static TheoryData ForEveryContainer => new TheoryData
            <IGame>
        {
            new PoorManAlphaCiv().BuildGame(),
            new PoorManSemiCiv().BuildGame(),
            new AutofacAlphaCiv().BuildGame(),
            new AutofacSemiCiv().BuildGame(),
            new DryIocAlphaCiv().BuildGame(),
            new DryIocSemiCiv().BuildGame(),
            new LightInjectAlphaCiv().BuildGame(),
            new LightInjectSemiCiv().BuildGame(),
            new NinjectAlphaCiv().BuildGame(),
            new NinjectSemiCiv().BuildGame(),
            new SimpleInjectorAlphaCiv().BuildGame(),
            new SimpleInjectorSemiCiv().BuildGame(),
            new StructureMapAlphaCiv().BuildGame(),
            new StructureMapSemiCiv().BuildGame(),
            new UnityAlphaCiv().BuildGame(),
            new UnitySemiCiv().BuildGame(),
            new WindsorAlphaCiv().BuildGame(),
            new WindsorSemiCiv().BuildGame(),
        };

        #region HELPERS: Shortcuts

        private const string Archer = "Archer";
        private const string Legion = "Legion";
        private const string Settler = "Settler";

        private const string Hills = "Hills";
        private const string Mountains = "Mountains";
        private const string Oceans = "Oceans";
        private const string Plains = "Plains";

        private static Player Red => new Player("Red");
        private static Player Blue => new Player("Blue");

        private static ITile From(int row, int column) => new SquareTile(row, column);
        private static ITile To(int row, int column) => new SquareTile(row, column);
        private static ITile Location(int row, int column) => new SquareTile(row, column);

        private static ITile OceansTile => Location(1, 0);
        private static ITile MountainsTile => Location(2, 2);

        private static ITile RedCityTile => Location(1, 1);
        private static ITile BlueCityTile => Location(4, 1);

        private static ITile RedArcherTile => Location(2, 0);
        private static ITile BlueLegionTile => Location(3, 2);
        private static ITile RedSettlerTile => Location(4, 3);

        private static void SkipRounds(IGame game, int rounds) => (2 * rounds).Times(game.EndTurn);

        #endregion
    }
}
