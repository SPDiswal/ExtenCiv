using ExtenCiv.Players;
using ExtenCiv.Players.Events;
using ExtenCiv.Utilities.Extensions;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.Players
{
    public sealed class TestRoundRobinTurnTaking
    {
        /// <summary>
        ///     The current player is updated when advancing to the next turn.
        /// </summary>
        /// <param name="players">The available players.</param>
        /// <param name="turns">The number of turns to advance.</param>
        /// <param name="expectedPlayer">The expected current player after advancing the specified number of turns.</param>
        [Theory]
        [MemberData(nameof(WhenPlayersAreRedBlue))]
        [MemberData(nameof(WhenPlayersAreBlueGreenRedYellow))]
        public void CurrentPlayer_AdvancesToTheNextPlayer_BecauseTheNextPlayerIsInTurn(Player[] players,
                                                                                       int turns,
                                                                                       Player expectedPlayer)
        {
            // :::: ARRANGE ::::
            var roundRobin = new RoundRobinTurns(players);

            // :::: ACT ::::
            turns.Times(() => roundRobin.AdvanceToNextPlayer());
            var actualPlayer = roundRobin.CurrentPlayer;

            // :::: ASSERT ::::
            actualPlayer.Should().Be(expectedPlayer);
        }

        /// <summary>
        ///     There are two available players: Red and Blue.
        /// </summary>
        public static TheoryData WhenPlayersAreRedBlue => new TheoryData
            <Player[], int, Player>
        {
            /* The current player is Red from start. */
            { TwoPlayers, 0, Red },
            //
            /* The current player is Blue after ending turn as Red. */
            { TwoPlayers, 1, Blue },
            //
            /* The current player is Red after ending turn as Blue. */
            { TwoPlayers, 2, Red },
        };

        /// <summary>
        ///     There are four available players: Blue, Green, Red and Yellow.
        /// </summary>
        public static TheoryData WhenPlayersAreBlueGreenRedYellow => new TheoryData
            <Player[], int, Player>
        {
            /* The current player is Blue from start. */
            { FourPlayers, 0, Blue },
            //
            /* The current player is Green after ending turn as Blue. */
            { FourPlayers, 1, Green },
            //
            /* The current player is Red after ending turn as Green. */
            { FourPlayers, 2, Red },
            //
            /* The current player is Yellow after ending turn as Red. */
            { FourPlayers, 3, Yellow },
            //
            /* The current player is Blue after ending turn as Yellow. */
            { FourPlayers, 4, Blue }
        };

        /// <summary>
        ///     It is round number one at game start.
        /// </summary>
        [Fact]
        public void CurrentRound_Returns1_AtGameStart()
        {
            // :::: ARRANGE ::::
            var roundRobin = new RoundRobinTurns(TwoPlayers);

            // :::: ACT ::::
            var actualRound = roundRobin.CurrentRound;

            // :::: ASSERT ::::
            actualRound.Should().Be(1);
        }

        /// <summary>
        ///     The current round increases by one when all players have been in turn.
        /// </summary>
        /// <param name="players">The available players.</param>
        /// <param name="rounds">The number of rounds to advance.</param>
        [Theory]
        [MemberData(nameof(WhenThereAreTwoPlayers))]
        [MemberData(nameof(WhenThereAreFourPlayers))]
        public void CurrentRound_IncreasesByOneWhenAllPlayersHaveBeenInTurn_BecauseTheNextRoundBegins(Player[] players,
                                                                                                      int rounds)
        {
            // :::: ARRANGE ::::
            var roundRobin = new RoundRobinTurns(players);

            // :::: ACT ::::
            var turnsToAdvance = rounds * players.Length;
            turnsToAdvance.Times(() => roundRobin.AdvanceToNextPlayer());

            var actualRound = roundRobin.CurrentRound;

            // :::: ASSERT ::::
            var expectedRound = 1 + rounds;
            actualRound.Should().Be(expectedRound);
        }

        /// <summary>
        ///     The turn-taking announces when the next round begins.
        /// </summary>
        /// <param name="players">The available players.</param>
        /// <param name="rounds">The number of rounds to advance.</param>
        [Theory]
        [MemberData(nameof(WhenThereAreTwoPlayers))]
        [MemberData(nameof(WhenThereAreFourPlayers))]
        public void CurrentRound_RaisesBeginningNextRoundEvent_BecauseTheNextRoundBegins(Player[] players, int rounds)
        {
            // :::: ARRANGE ::::
            var roundRobin = new RoundRobinTurns(players);
            roundRobin.MonitorEvents();

            // :::: ACT ::::
            var turnsToAdvance = rounds * players.Length;
            turnsToAdvance.Times(() => roundRobin.AdvanceToNextPlayer());

            // :::: ASSERT ::::
            var expectedRound = 1 + rounds;
            roundRobin.ShouldRaise(nameof(roundRobin.BeginningNextRound))
                      .WithSender(roundRobin)
                      .WithArgs<BeginningNextRoundEventArgs>(args => args.Round == expectedRound);
        }

        /// <summary>
        ///     There are two players.
        /// </summary>
        public static TheoryData WhenThereAreTwoPlayers => new TheoryData
            <Player[], int>
        {
            /* Advancing one round when there are two players. */
            { TwoPlayers, 1 },
            //
            /* Advancing two rounds when there are two players. */
            { TwoPlayers, 2 },
        };

        /// <summary>
        ///     There are four players.
        /// </summary>
        public static TheoryData WhenThereAreFourPlayers => new TheoryData
            <Player[], int>
        {
            /* Advacing one round when there are four players. */
            { FourPlayers, 1 },
            //
            /* Advacing two rounds when there are four players. */
            { FourPlayers, 2 },
        };

        #region HELPERS: Shortcuts

        private static Player Red => new Player("Red");
        private static Player Blue => new Player("Blue");
        private static Player Green => new Player("Green");
        private static Player Yellow => new Player("Yellow");

        private static Player[] TwoPlayers => new[] { Red, Blue };
        private static Player[] FourPlayers => new[] { Blue, Green, Red, Yellow };

        #endregion
    }
}
