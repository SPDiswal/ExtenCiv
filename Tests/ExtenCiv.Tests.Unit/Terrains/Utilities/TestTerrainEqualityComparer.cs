using ExtenCiv.Terrains.Abstractions;
using ExtenCiv.Terrains.Utilities;
using ExtenCiv.Tests.Utilities;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.Terrains.Utilities
{
    public sealed class TestTerrainEqualityComparer
    {
        /// <summary>
        ///     Two terrain instances are equal when they have the same unique identifier.
        /// </summary>
        [Theory]
        [MemberData(nameof(WhenTwoTerrainInstancesHaveTheSameId))]
        public void Equals_ReturnsTrue_BecauseTheTerrainsAreEqual(ITerrain first, ITerrain second)
        {
            // :::: ARRANGE ::::
            var comparer = new TerrainEqualityComparer();

            // :::: ACT ::::
            var actualEquality = comparer.Equals(first, second);

            // :::: ASSERT ::::
            actualEquality.Should().BeTrue();
        }

        /// <summary>
        ///     Two terrain instances have the same hash code when they have the same unique identifier.
        /// </summary>
        [Theory]
        [MemberData(nameof(WhenTwoTerrainInstancesHaveTheSameId))]
        public void GetHashCode_ReturnsTheSameHashCodeForBothTerrains_BecauseTheTerrainsAreEqual(ITerrain first,
                                                                                                 ITerrain second)
        {
            // :::: ARRANGE ::::
            var comparer = new TerrainEqualityComparer();

            // :::: ACT ::::
            var firstHashCode = comparer.GetHashCode(first);
            var secondHashCode = comparer.GetHashCode(second);

            // :::: ASSERT ::::
            firstHashCode.Should().Be(secondHashCode);
        }

        /// <summary>
        ///     When two terrain instances have the same id, they are equal.
        /// </summary>
        public static TheoryData WhenTwoTerrainInstancesHaveTheSameId => new TheoryData
            <ITerrain, ITerrain>
        {
            /* Two terrain instances have id 1. */
            { StubTerrain(1), StubTerrain(1) },
            //
            /* Two terrain instances have id 2. */
            { StubTerrain(2), StubTerrain(2) },
        };

        /// <summary>
        ///     Two terrain instances are not equal when they have different unique identifiers.
        /// </summary>
        [Theory]
        [MemberData(nameof(WhenTwoTerrainInstancesHaveDifferentIds))]
        public void Equals_ReturnsFalse_BecauseTheTerrainsAreNotEqual(ITerrain first, ITerrain second)
        {
            // :::: ARRANGE ::::
            var comparer = new TerrainEqualityComparer();

            // :::: ACT ::::
            var actualEquality = comparer.Equals(first, second);

            // :::: ASSERT ::::
            actualEquality.Should().BeFalse();
        }

        /// <summary>
        ///     When two terrain instances have different ids, they are not equal.
        /// </summary>
        public static TheoryData WhenTwoTerrainInstancesHaveDifferentIds => new TheoryData
            <ITerrain, ITerrain>
        {
            /* Two terrain instances have id 1 and id 2, respectively. */
            { StubTerrain(1), StubTerrain(2) },
            //
            /* Two terrain instances have id 3 and id 4, respectively. */
            { StubTerrain(3), StubTerrain(4) },
        };

        #region HELPERS: Stubs

        private static ITerrain StubTerrain(int id)
        {
            var stubTerrain = A.Fake<ITerrain>();
            A.CallTo(() => stubTerrain.Id).Returns(GuidUtilities.Id(id));
            return stubTerrain;
        }

        #endregion
    }
}
