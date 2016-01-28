using ExtenCiv.Players.Events;
using ExtenCiv.Utilities.Extensions;
using ExtenCiv.WorldAges;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.WorldAges
{
    public sealed class TestDeceleratingWorldAge
    {
        /// <summary>
        ///     The world age increases at a decelerating pace in every round.
        /// </summary>
        /// <param name="rounds">The number of rounds to advance.</param>
        /// <param name="expectedWorldAge">The expected world age after advancing the given number of rounds.</param>
        [Theory]
        [MemberData(nameof(WhenTheNextRoundBegins))]
        public void TheWorldAge_IncreasesAtADeceleratingPace(int rounds, int expectedWorldAge)
        {
            // :::: ARRANGE ::::
            var stubNotifier = A.Fake<INotifyBeginningNextRound>();
            var decelerating = new DeceleratingWorldAge(stubNotifier);

            // :::: ACT ::::
            rounds.Times(() => stubNotifier.BeginningNextRound += Raise.With(DummyEventArgs));
            var actualWorldAge = decelerating.CurrentWorldAge;

            // :::: ASSERT ::::
            actualWorldAge.Should().Be(expectedWorldAge);
        }

        /// <summary>
        ///     When the next round begins, the world age increases at a decelerating pace.
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
            //
            /* The world age is 100 BCE after advancing 39 rounds. */
            { 39, -100 },
            //
            /* The world age is 1 BCE after advancing 40 rounds. */
            { 40, -1 },
            //
            /* The world age is 1 CE after advancing 41 rounds. */
            { 41, 1 },
            //
            /* The world age is 50 CE after advancing 42 rounds. */
            { 42, 50 },
            //
            /* The world age is 100 CE after advancing 43 rounds. */
            { 43, 100 },
            //
            /* The world age is 1750 CE after advancing 76 rounds. */
            { 76, 1750 },
            //
            /* The world age is 1775 CE after advancing 77 rounds. */
            { 77, 1775 },
            //
            /* The world age is 1900 CE after advancing 82 rounds. */
            { 82, 1900 },
            //
            /* The world age is 1905 CE after advancing 83 rounds. */
            { 83, 1905 },
            //
            /* The world age is 1970 CE after advancing 96 rounds. */
            { 96, 1970 },
            //
            /* The world age is 1971 CE after advancing 97 rounds. */
            { 97, 1971 },
            //
            /* The world age is 1972 CE after advancing 98 rounds. */
            { 98, 1972 },
        };

        #region HELPERS: Dummies

        private static BeginningNextRoundEventArgs DummyEventArgs => new BeginningNextRoundEventArgs(42);

        #endregion
    }
}
