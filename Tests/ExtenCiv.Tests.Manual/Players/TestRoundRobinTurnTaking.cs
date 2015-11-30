using ExtenCiv.Players;
using ExtenCiv.Utilities.Extensions;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Players
{
    public sealed class TestRoundRobinTurnTaking
    {
        private static readonly Player Red = new Player("Red");
        private static readonly Player Blue = new Player("Blue");
        private static readonly Player Green = new Player("Green");
        private static readonly Player Yellow = new Player("Yellow");

        private static readonly Player[] TwoPlayers = { Red, Blue };
        private static readonly Player[] FourPlayers = { Blue, Green, Red, Yellow };

        public static readonly TheoryData CurrentPlayerAdvancesToNextPlayer = new TheoryData
            <Player[], int, Player>
        {
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // When available players are Red, Blue:
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //
            /* Current player is Red from start. */
            { TwoPlayers, 0, Red },
            //
            /* Current player is Blue after ending turn as Red. */
            { TwoPlayers, 1, Blue },
            //
            /* Current player is Red after ending turn as Blue. */
            { TwoPlayers, 2, Red },
            //
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // When available players are Blue, Green, Red, Yellow:
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //
            /* Current player is Blue from start. */
            { FourPlayers, 0, Blue },
            //
            /* Current player is Green after ending turn as Blue. */
            { FourPlayers, 1, Green },
            //
            /* Current player is Red after ending turn as Green. */
            { FourPlayers, 2, Red },
            //
            /* Current player is Yellow after ending turn as Red. */
            { FourPlayers, 3, Yellow },
            //
            /* Current player is Blue after ending turn as Yellow. */
            { FourPlayers, 4, Blue }
        };

        [Theory]
        [MemberData(nameof(CurrentPlayerAdvancesToNextPlayer))]
        public void CurrentPlayer_AdvancesToNextPlayer(Player[] players, int turnsToAdvance, Player expectedPlayer)
        {
            // :::: ARRANGE ::::
            var roundRobin = new RoundRobinTurnTaking(players);
            turnsToAdvance.Times(() => roundRobin.AdvanceToNextPlayer());

            // :::: ACT ::::
            var actualPlayer = roundRobin.CurrentPlayer;

            // :::: ASSERT ::::
            actualPlayer.Should().Be(expectedPlayer);
        }
    }
}
