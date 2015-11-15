using System.Collections.Generic;
using System.Linq;
using ExtenCiv.Common.Utilities.Extensions;
using ExtenCiv.Common.Utilities.Theories;
using ExtenCiv.Players;
using ExtenCiv.Resolvers;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Players
{
    public sealed class TestRoundRobinTurnTaking
    {
        private const string Red = "Red";
        private const string Blue = "Blue";
        private const string Green = "Green";
        private const string Yellow = "Yellow";

        public static readonly IEnumerable<object> CurrentPlayerAdvancesToNextPlayer = new ExtenCivTheory
        {
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // When available players are Red, Blue:
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //
            /* DONE Current player is Red from start. */
            { new[] { Red, Blue }.Select(Player.For), 0, Player.For(Red) },
            //
            /* DONE Current player is Blue after ending turn as Red. */
            { new[] { Red, Blue }.Select(Player.For), 1, Player.For(Blue) },
            //
            /* DONE Current player is Red after ending turn as Blue. */
            { new[] { Red, Blue }.Select(Player.For), 2, Player.For(Red) },
            //
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // When available players are Blue, Green, Red, Yellow:
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //
            /* DONE Current player is Blue from start. */
            { new[] { Blue, Green, Red, Yellow }.Select(Player.For), 0, Player.For(Blue) },
            //
            /* DONE Current player is Green after ending turn as Blue. */
            { new[] { Blue, Green, Red, Yellow }.Select(Player.For), 1, Player.For(Green) },
            //
            /* DONE Current player is Red after ending turn as Green. */
            { new[] { Blue, Green, Red, Yellow }.Select(Player.For), 2, Player.For(Red) },
            //
            /* DONE Current player is Yellow after ending turn as Red. */
            { new[] { Blue, Green, Red, Yellow }.Select(Player.For), 3, Player.For(Yellow) },
            //
            /* DONE Current player is Blue after ending turn as Yellow. */
            { new[] { Blue, Green, Red, Yellow }.Select(Player.For), 4, Player.For(Blue) }
        };

        [Theory]
        [MemberData(nameof(CurrentPlayerAdvancesToNextPlayer))]
        public void CurrentPlayer_AdvancesToNextPlayer(IResolver resolver,
                                                       IEnumerable<Player> players,
                                                       int turnsToAdvance,
                                                       Player expectedPlayer)
        {
            // :::: ARRANGE ::::
            var stubPlayerStrategy = A.Fake<IPlayerStrategy>();
            A.CallTo(() => stubPlayerStrategy.Players).Returns(players);

            resolver.Inject(stubPlayerStrategy);
            var roundRobin = resolver.Resolve<RoundRobinTurnTaking>();

            turnsToAdvance.Times(() => roundRobin.AdvanceToNextPlayer());

            // :::: ACT ::::
            var actualPlayer = roundRobin.CurrentPlayer;

            // :::: ASSERT ::::
            actualPlayer.Should().Be(expectedPlayer);
        }
    }
}
