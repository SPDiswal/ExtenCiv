using ExtenCiv.Players.Events;
using ExtenCiv.Tests.Utilities.Extensions;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Movement;
using ExtenCiv.Units.Types;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.Units.Movement
{
    public sealed class TestRestorationOfMoves
    {
        /// <summary>
        ///     The remaining moves of a unit are restored to the total number of moves when the next round begins.
        /// </summary>
        /// <param name="unit">The unit whose remaining moves are to be restored.</param>
        [Theory]
        [MemberData(nameof(WhenAUnitHasLessRemainingMovesThanTotalMoves))]
        public void RemainingMoves_IsRestoredToTotalMoves_BecauseTheNextRoundHasBegun(IUnit<Archer> unit)
        {
            // :::: ARRANGE ::::
            var stubNotifier = A.Fake<INotifyBeginningNextRound>();
            var restoringUnit = new RestorationOfMoves<Archer>(unit, stubNotifier);

            // :::: ACT ::::
            stubNotifier.BeginningNextRound += Raise.With(DummyEventArgs);

            // :::: ASSERT ::::
            restoringUnit.RemainingMoves.Should().Be(restoringUnit.TotalMoves);
        }

        /// <summary>
        ///     When a unit has less remaining moves than total moves, the remaining moves are restored.
        /// </summary>
        public static TheoryData WhenAUnitHasLessRemainingMovesThanTotalMoves => new TheoryData
            <IUnit<Archer>>
        {
            /* A unit has no remaining moves left of one total move. */
            Archer.ThatCanMove(0).Of(1),
            //
            /* A unit has one remaining move left of three total moves. */
            Archer.ThatCanMove(1).Of(3),
        };

        #region HELPERS: Shortcuts

        private static IUnit<Archer> Archer => new Archer();

        #endregion

        #region HELPERS: Dummies

        private static BeginningNextRoundEventArgs DummyEventArgs => new BeginningNextRoundEventArgs(42);

        #endregion
    }
}
