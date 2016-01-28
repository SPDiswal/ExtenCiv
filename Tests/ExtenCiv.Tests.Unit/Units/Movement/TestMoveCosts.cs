using ExtenCiv.Tests.Utilities.Extensions;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Movement;
using ExtenCiv.Units.Types;
using ExtenCiv.WorldMaps.Tiles;
using ExtenCiv.WorldMaps.Tiles.Abstractions;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.Units.Movement
{
    public sealed class TestMoveCosts
    {
        /// <summary>
        ///     Move decrements the remaining moves of the moving unit by one per tile moved.
        /// </summary>
        /// <param name="unit">The unit to move.</param>
        /// <param name="destination">The destination tile.</param>
        /// <param name="expectedRemainingMoves">
        ///     The expected number of moves that remain after moving to the destination.
        /// </param>
        [Theory]
        [MemberData(nameof(WhenMovingUnitsOneTileWithOneRemainingMove))]
        [MemberData(nameof(WhenMovingUnitsOneTileWithTwoRemainingMoves))]
        [MemberData(nameof(WhenMovingUnitsTwoTilesWithTwoRemainingMoves))]
        public void Move_SubtractsOneFromRemainingMovesPerTileMoved(IUnit<Archer> unit,
                                                                           ITile destination,
                                                                           int expectedRemainingMoves)
        {
            // :::: ARRANGE ::::
            var costlyUnit = new MoveCosts<Archer>(unit);

            // :::: ACT ::::
            costlyUnit.MoveTo(destination);

            // :::: ASSERT ::::
            costlyUnit.RemainingMoves.Should().Be(expectedRemainingMoves);
        }

        /// <summary>
        ///     When moving units with one remaining move one tile, they have no remaining moves.
        /// </summary>
        public static TheoryData WhenMovingUnitsOneTileWithOneRemainingMove => new TheoryData
            <IUnit<Archer>, ITile, int>
        {
            /* When moving an Archer with one remaining move from (2, 0) to (3, 1), it has no remaining moves. */
            { Archer.At(2, 0).ThatCanMove(1), To(3, 1), 0 },
            //
            /* When moving an Archer with one remaining move from (3, 2) to (2, 1), it has no remaining moves. */
            { Archer.At(3, 2).ThatCanMove(1), To(2, 1), 0 },
        };

        /// <summary>
        ///     When moving units with two remaining moves one tile, they have one remaining move.
        /// </summary>
        public static TheoryData WhenMovingUnitsOneTileWithTwoRemainingMoves => new TheoryData
            <IUnit, ITile, int>
        {
            /* When moving an Archer with two remaining moves from (2, 0) to (3, 1), it has one remaining move. */
            { Archer.At(2, 0).ThatCanMove(2), To(3, 1), 1 },
            //
            /* When moving an Archer with two remaining moves from (3, 2) to (2, 1), it has one remaining move. */
            { Archer.At(3, 2).ThatCanMove(2), To(2, 1), 1 },
        };

        /// <summary>
        ///     When moving units with two remaining moves two tiles, they have no remaining moves.
        /// </summary>
        public static TheoryData WhenMovingUnitsTwoTilesWithTwoRemainingMoves => new TheoryData
            <IUnit, ITile, int>
        {
            /* When moving an Archer with two remaining moves from (2, 0) to (4, 1), it has no remaining moves. */
            { Archer.At(2, 0).ThatCanMove(2), To(4, 1), 0 },
            //
            /* When moving an Archer with two remaining moves from (3, 2) to (4, 4), it has no remaining moves. */
            { Archer.At(3, 2).ThatCanMove(2), To(4, 4), 0 },
            //
            /* When moving an Archer with two remaining moves from (2, 0) to (0, 1), it has no remaining moves. */
            { Archer.At(2, 0).ThatCanMove(2), To(0, 1), 0 },
            //
            /* When moving an Archer with two remaining moves from (3, 2) to (1, 1), it has no remaining moves. */
            { Archer.At(3, 2).ThatCanMove(2), To(1, 1), 0 },
        };

        /// <summary>
        ///     <c>MoveTo</c> is forwarded after subtracting move costs from the remaining moves of the unit,
        ///     because <c>MoveTo</c> is most likely to change the location of the unit, thus invalidating the distance moved.
        /// </summary>
        [Fact(Skip = "Fake.CreateScope() in FakeItEasy is not thread-safe "
                     + "and suffers from race conditions when executed in parallel with other tests.")]
        public void MoveTo_IsForwardedAfterSubtractingMoveCostsFromTheRemainingMovesOfTheUnit()
        {
            // :::: ARRANGE ::::
            var spyUnit = A.Fake<IUnit<Archer>>();
            var costlyUnit = new MoveCosts<Archer>(spyUnit);

            using (var scope = Fake.CreateScope())
            {
                // :::: ACT ::::
                costlyUnit.MoveTo(DummyPosition);

                // :::: ASSERT ::::
                using (scope.OrderedAssertions())
                {
                    // The setter of RemainingMoves has been invoked.
                    A.CallTo(spyUnit).Where(x => x.Method.Name == $"set_{nameof(spyUnit.RemainingMoves)}")
                     .MustHaveHappened();

                    A.CallTo(() => spyUnit.MoveTo(DummyPosition)).MustHaveHappened();
                }
            }
        }

        #region HELPERS: Shortcuts

        private static IUnit<Archer> Archer => new Archer();

        private static ITile To(int row, int column) => new SquareTile(row, column);

        #endregion

        #region HELPERS: Dummies

        private static ITile DummyPosition => new SquareTile(0, 0);

        #endregion
    }
}
