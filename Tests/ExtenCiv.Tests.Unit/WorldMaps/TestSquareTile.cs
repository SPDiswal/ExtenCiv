using ExtenCiv.WorldMaps.Tiles;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.WorldMaps
{
    public sealed class TestSquareTile
    {
        /// <summary>
        ///     DistanceTo returns the maximum of the row difference and the column difference between the square tiles.
        /// </summary>
        [Theory]
        [MemberData(nameof(WhenRowDifferenceAndColumnDifferenceAreZero))]
        [MemberData(nameof(WhenRowDifferenceIsGreaterThanColumnDifference))]
        [MemberData(nameof(WhenColumnDifferenceIsGreaterThanRowDifference))]
        [MemberData(nameof(WhenRowDifferenceIsEqualToColumnDifference))]
        public void DistanceTo_ReturnsMaximumRowOrColumnDifferenceBetweenTiles(SquareTile origin,
                                                                               SquareTile destination,
                                                                               int expectedDistance)
        {
            // :::: ACT ::::
            var actualDistance = origin.DistanceTo(destination);

            // :::: ASSERT ::::
            actualDistance.Should().Be(expectedDistance);
        }

        /// <summary>
        ///     When the row difference and the column difference are zero, the distance is zero.
        /// </summary>
        public static TheoryData WhenRowDifferenceAndColumnDifferenceAreZero => new TheoryData
            <SquareTile, SquareTile, int>
        {
            /* The distance between (2, 0) and (2, 0) is 0. */
            { new SquareTile(2, 0), new SquareTile(2, 0), 0 },
            //
            /* The distance between (4, 5) and (4, 5) is 0. */
            { new SquareTile(4, 5), new SquareTile(4, 5), 0 },
        };

        /// <summary>
        ///     When the row difference is greater than the column difference, the distance equals the row difference.
        /// </summary>
        public static TheoryData WhenRowDifferenceIsGreaterThanColumnDifference => new TheoryData
            <SquareTile, SquareTile, int>
        {
            /* The distance between (2, 0) and (3, 0) is 1. */
            { new SquareTile(2, 0), new SquareTile(3, 0), 1 },
            //
            /* The distance between (4, 5) and (1, 3) is 3. */
            { new SquareTile(4, 5), new SquareTile(1, 3), 3 },
        };

        /// <summary>
        ///     When the column difference is greater than the row difference, the distance equals the column difference.
        /// </summary>
        public static TheoryData WhenColumnDifferenceIsGreaterThanRowDifference => new TheoryData
            <SquareTile, SquareTile, int>
        {
            /* The distance between (2, 0) and (2, 1) is 1. */
            { new SquareTile(2, 0), new SquareTile(2, 1), 1 },
            //
            /* The distance between (4, 5) and (2, 2) is 3. */
            { new SquareTile(4, 5), new SquareTile(2, 2), 3 },
        };

        /// <summary>
        ///     When the row difference is equal to the column difference, the distance equals either difference.
        /// </summary>
        public static TheoryData WhenRowDifferenceIsEqualToColumnDifference => new TheoryData
            <SquareTile, SquareTile, int>
        {
            /* The distance between (2, 0) and (3, 1) is 1. */
            { new SquareTile(2, 0), new SquareTile(3, 1), 1 },
            //
            /* The distance between (4, 5) and (2, 3) is 2. */
            { new SquareTile(4, 5), new SquareTile(2, 3), 2 },
        };
    }
}
