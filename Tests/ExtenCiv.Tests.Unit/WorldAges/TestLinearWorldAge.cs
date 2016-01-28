using ExtenCiv.Players.Events;
using ExtenCiv.Utilities.Extensions;
using ExtenCiv.WorldAges;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.WorldAges
{
    public sealed class TestLinearWorldAge
    {
        /// <summary>
        ///     The world age increases linearly by 100 years in every round.
        /// </summary>
        /// <param name="rounds">The number of rounds to advance.</param>
        /// <param name="expectedWorldAge">The expected world age after advancing the given number of rounds.</param>
        [Theory]
        [MemberData(nameof(WhenTheNextRoundBegins))]
        public void TheWorldAge_IncreasesBy100Years(int rounds, int expectedWorldAge)
        {
            // :::: ARRANGE ::::
            var stubNotifier = A.Fake<INotifyBeginningNextRound>();
            var linear = new LinearWorldAge(stubNotifier);

            // :::: ACT ::::
            rounds.Times(() => stubNotifier.BeginningNextRound += Raise.With(DummyEventArgs));
            var actualWorldAge = linear.CurrentWorldAge;

            // :::: ASSERT ::::
            actualWorldAge.Should().Be(expectedWorldAge);
        }

        /// <summary>
        ///     When the next round begins, the world age increases by 100 years.
        /// </summary>
        public static TheoryData WhenTheNextRoundBegins => new TheoryData
            <int, int>
        {
            /* The world age is 4000 BCE from start. */
            { 0, -4000 },
            //
            /* The world age is 3900 BCE after advancing one round. */
            { 1, -3900 },
            //
            /* The world age is 3800 BCE after advancing two rounds. */
            { 2, -3800 },
        };

        #region HELPERS: Dummies

        private static BeginningNextRoundEventArgs DummyEventArgs => new BeginningNextRoundEventArgs(42);

        #endregion
    }
}
