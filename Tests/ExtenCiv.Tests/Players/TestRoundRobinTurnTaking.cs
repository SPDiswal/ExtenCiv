using System.Linq;
using ExtenCiv.Players;
using ExtenCiv.Tests.Utilities;
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

        [Theory]
        //
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        // When available players are Red, Blue:
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //
        /* DONE Current player is Red from start. */
        [InlineData(new[] { Red, Blue }, 0, Red)]
        //
        /* DONE Current player is Blue after ending turn as Red. */
        [InlineData(new[] { Red, Blue }, 1, Blue)]
        //
        /* DONE Current player is Red after ending turn as Blue. */
        [InlineData(new[] { Red, Blue }, 2, Red)]
        //
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        // When available players are Blue, Green, Red, Yellow:
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //
        /* DONE Current player is Blue from start. */
        [InlineData(new[] { Blue, Green, Red, Yellow }, 0, Blue)]
        //
        /* DONE Current player is Green after ending turn as Blue. */
        [InlineData(new[] { Blue, Green, Red, Yellow }, 1, Green)]
        //
        /* DONE Current player is Red after ending turn as Green. */
        [InlineData(new[] { Blue, Green, Red, Yellow }, 2, Red)]
        //
        /* DONE Current player is Yellow after ending turn as Red. */
        [InlineData(new[] { Blue, Green, Red, Yellow }, 3, Yellow)]
        //
        /* DONE Current player is Blue after ending turn as Yellow. */
        [InlineData(new[] { Blue, Green, Red, Yellow }, 4, Blue)]
        //
        public void CurrentPlayer_AdvancesToNextPlayer(string[] playerNames,
                                                       int turnsToAdvance,
                                                       string expectedPlayerName)
        {
            // :::: ARRANGE ::::
            var roundRobin = new RoundRobinTurnTaking(playerNames.Select(Player.For));
            turnsToAdvance.Times(() => roundRobin.AdvanceToNextPlayer());

            // :::: ACT ::::
            var actualPlayer = roundRobin.CurrentPlayer;

            // :::: ASSERT ::::
            actualPlayer.Should().Be(Player.For(expectedPlayerName));
        }
    }
}
