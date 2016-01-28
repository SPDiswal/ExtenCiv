using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Movement;
using ExtenCiv.Units.Types;
using ExtenCiv.WorldMaps.Tiles;
using ExtenCiv.WorldMaps.Tiles.Abstractions;
using FakeItEasy;
using Xunit;

namespace ExtenCiv.Tests.Unit.Units.Movement
{
    public sealed class TestLimitedMoveRange
    {
        /// <summary>
        ///     Moving to a destination within range of the remaining moves is allowed.
        /// </summary>
        /// <param name="moves">The number of remaining moves of the unit to move.</param>
        /// <param name="origin">The location of the unit to move.</param>
        /// <param name="destination">The destination tile.</param>
        [Theory]
        [MemberData(nameof(WhenMovingOneTileWithOneRemainingMove))]
        public void MoveTo_IsForwarded_BecauseDestinationIsWithinRange(int moves, ITile origin, ITile destination)
        {
            // :::: ARRANGE ::::
            var spyUnit = A.Fake<IUnit<Archer>>();
            var unit = new LimitedMoveRange<Archer>(spyUnit);

            A.CallTo(() => spyUnit.RemainingMoves).Returns(moves);
            A.CallTo(() => spyUnit.Location).Returns(origin);

            // :::: ACT ::::
            unit.MoveTo(destination);

            // :::: ASSERT ::::
            A.CallTo(() => spyUnit.MoveTo(destination)).MustHaveHappened();
        }

        /// <summary>
        ///     Moving one tile with a unit that has one remaining move is allowed.
        /// </summary>
        public static TheoryData WhenMovingOneTileWithOneRemainingMove => new TheoryData
            <int, ITile, ITile>
        {
            /* An Archer with one remaining move can move one tile north from (2, 2) to (1, 2). */
            { 1, From(2, 2), To(1, 2) },
            //
            /* A Legion with one remaining move can move one tile north-east from (4, 3) to (3, 4). */
            { 1, From(4, 3), To(3, 4) },
            //
            /* An Archer with one remaining move can move one tile east from (2, 2) to (2, 3). */
            { 1, From(2, 2), To(2, 3) },
            //
            /* A Legion with one remaining move can move one tile south-east from (4, 3) to (5, 4). */
            { 1, From(4, 3), To(5, 4) },
            //
            /* An Archer with one remaining move can move one tile south from (2, 2) to (3, 2). */
            { 1, From(2, 2), To(3, 2) },
            //
            /* A Legion with one remaining move can move one tile south-west from (4, 3) to (5, 2). */
            { 1, From(4, 3), To(5, 2) },
            //
            /* An Archer with one remaining move can move one tile west from (2, 2) to (2, 1). */
            { 1, From(2, 2), To(2, 1) },
            //
            /* A Legion with one remaining move can move one tile north-west from (4, 3) to (3, 2). */
            { 1, From(4, 3), To(3, 2) },
        };

        /// <summary>
        ///     Moving to a destination out of range of the remaining moves is not allowed.
        /// </summary>
        /// <param name="moves">The number of remaining moves of the unit to move.</param>
        /// <param name="origin">The location of the unit to move.</param>
        /// <param name="destination">The destination tile.</param>
        [Theory]
        [MemberData(nameof(WhenMovingZeroTiles))]
        [MemberData(nameof(WhenMovingOneTileWithNoRemainingMoves))]
        [MemberData(nameof(WhenMovingTwoTilesWithOneRemainingMove))]
        [MemberData(nameof(WhenMovingThreeTilesWithOneRemainingMove))]
        public void MoveTo_IsForwarded_BecauseDestinationIsOutOfRange(int moves, ITile origin, ITile destination)
        {
            // :::: ARRANGE ::::
            var spyUnit = A.Fake<IUnit<Archer>>();
            var unit = new LimitedMoveRange<Archer>(spyUnit);

            A.CallTo(() => spyUnit.RemainingMoves).Returns(moves);
            A.CallTo(() => spyUnit.Location).Returns(origin);

            // :::: ACT ::::
            unit.MoveTo(destination);

            // :::: ASSERT ::::
            A.CallTo(() => spyUnit.MoveTo(destination)).MustNotHaveHappened();
        }

        /// <summary>
        ///     Moving zero tiles, that is, staying on the same tile, is not allowed.
        /// </summary>
        public static TheoryData WhenMovingZeroTiles => new TheoryData
            <int, ITile, ITile>
        {
            /* When moving Archer with one remaining move at (2, 2) zero tiles to (2, 2). */
            { 1, From(2, 2), To(2, 2) },
            //
            /* When moving Legion with one remaining move at (4, 3) zero tiles to (4, 3). */
            { 1, From(4, 3), To(4, 3) },
        };

        /// <summary>
        ///     Moving one tile with a unit that has no remaining moves is not allowed.
        /// </summary>
        public static TheoryData WhenMovingOneTileWithNoRemainingMoves => new TheoryData
            <int, ITile, ITile>
        {
            /* An Archer with no remaining moves cannot move one tile from (2, 2) to (1, 2). */
            { 0, From(2, 2), To(1, 2) },
            //
            /* A Legion with no remaining moves cannot move one tile from (4, 3) to (3, 4). */
            { 0, From(4, 3), To(3, 4) },
        };

        /// <summary>
        ///     Moving two tiles with a unit that has one remaining move is not allowed.
        /// </summary>
        public static TheoryData WhenMovingTwoTilesWithOneRemainingMove => new TheoryData
            <int, ITile, ITile>
        {
            /* An Archer with one remaining move cannot move two tiles from (2, 2) to (4, 2). */
            { 1, From(2, 2), To(4, 2) },
            //
            /* A Legion with one remaining move cannot move two tiles from (4, 3) to (2, 4). */
            { 1, From(4, 3), To(2, 4) },
        };

        /// <summary>
        ///     Moving three tiles with a unit that has one remaining move is not allowed.
        /// </summary>
        public static TheoryData WhenMovingThreeTilesWithOneRemainingMove => new TheoryData
            <int, ITile, ITile>
        {
            /* An Archer with one remaining move cannot move three tiles from (2, 2) to (5, 5). */
            { 1, From(2, 2), To(5, 5) },
            //
            /* A Legion with one remaining move cannot move three tiles from (4, 3) to (3, 0). */
            { 1, From(4, 3), To(3, 0) },
        };

        #region HELPERS: Shortcuts

        private static ITile From(int row, int column) => new SquareTile(row, column);
        private static ITile To(int row, int column) => new SquareTile(row, column);

        #endregion
    }
}
