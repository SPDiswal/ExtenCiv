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
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Integration.AlphaCiv
{
    public sealed class TestAlphaCiv
    {
        /// <summary>
        ///     The world age is 4000 BCE in round 1 (at game start).
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void WorldAge_Is4000BCE_InRound1(IGame game)
        {
            // :::: ACT ::::
            var actualWorldAge = game.WorldAge;

            // :::: ASSERT ::::
            actualWorldAge.Should().Be(-4000);
        }

        /// <summary>
        ///     The world age is 3900 BCE in round 2.
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void WorldAge_Is3900BCE_InRound2(IGame game)
        {
            // :::: ARRANGE ::::
            SkipRounds(game, 1);

            // :::: ACT ::::
            var actualWorldAge = game.WorldAge;

            // :::: ASSERT ::::
            actualWorldAge.Should().Be(-3900);
        }

        /// <summary>
        ///     The world age is 200 CE in round 42.
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void WorldAge_Is200CE_InRound42(IGame game)
        {
            // :::: ARRANGE ::::
            SkipRounds(game, 42);

            // :::: ACT ::::
            var actualWorldAge = game.WorldAge;

            // :::: ASSERT ::::
            actualWorldAge.Should().Be(200);
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
        ///     There is no winner in 3100 BCE (round 9).
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void Winner_IsNobody_In3100BCE(IGame game)
        {
            // :::: ARRANGE and ACT ::::
            SkipRounds(game, 9);

            // :::: ASSERT ::::
            game.Winner.Should().Be(Player.Nobody);
        }

        /// <summary>
        ///     Red is the winner in 3000 BCE (round 10).
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void Winner_IsRed_In3000BCE(IGame game)
        {
            // :::: ARRANGE and ACT ::::
            SkipRounds(game, 10);

            // :::: ASSERT ::::
            game.Winner.Should().Be(Red);
        }

        /// <summary>
        ///     Red is the winner in 2900 BCE (round 11).
        /// </summary>
        [Theory]
        [MemberData(nameof(ForEveryContainer))]
        public void Winner_IsRed_In2900BCE(IGame game)
        {
            // :::: ARRANGE and ACT ::::
            SkipRounds(game, 11);

            // :::: ASSERT ::::
            game.Winner.Should().Be(Red);
        }

        /// <summary>
        ///     For every dependency injection container, the dependencies have been resolved correctly.
        /// </summary>
        public static TheoryData ForEveryContainer => new TheoryData
            <IGame>
        {
            new PoorManAlphaCiv().BuildGame(),
            new AutofacAlphaCiv().BuildGame(),
            new DryIocAlphaCiv().BuildGame(),
            new LightInjectAlphaCiv().BuildGame(),
            new NinjectAlphaCiv().BuildGame(),
            new SimpleInjectorAlphaCiv().BuildGame(),
            new StructureMapAlphaCiv().BuildGame(),
            new UnityAlphaCiv().BuildGame(),
            new WindsorAlphaCiv().BuildGame(),
        };

        #region HELPERS: Shortcuts

        private static Player Red => new Player("Red");

        private static void SkipRounds(IGame game, int rounds) => (2 * rounds).Times(game.EndTurn);

        #endregion
    }
}
