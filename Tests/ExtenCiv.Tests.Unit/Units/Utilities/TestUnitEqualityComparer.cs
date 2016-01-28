using ExtenCiv.Tests.Utilities;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Utilities;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.Units.Utilities
{
    public sealed class TestUnitEqualityComparer
    {
        /// <summary>
        ///     Two unit instances are equal when they have the same unique identifier.
        /// </summary>
        [Theory]
        [MemberData(nameof(WhenTwoUnitInstancesHaveTheSameId))]
        public void Equals_ReturnsTrue_BecauseTheUnitsAreEqual(IUnit first, IUnit second)
        {
            // :::: ARRANGE ::::
            var comparer = new UnitEqualityComparer();

            // :::: ACT ::::
            var actualEquality = comparer.Equals(first, second);

            // :::: ASSERT ::::
            actualEquality.Should().BeTrue();
        }

        /// <summary>
        ///     Two unit instances have the same hash code when they have the same unique identifier.
        /// </summary>
        [Theory]
        [MemberData(nameof(WhenTwoUnitInstancesHaveTheSameId))]
        public void GetHashCode_ReturnsTheSameHashCodeForBothUnits_BecauseTheUnitsAreEqual(IUnit first, IUnit second)
        {
            // :::: ARRANGE ::::
            var comparer = new UnitEqualityComparer();

            // :::: ACT ::::
            var firstHashCode = comparer.GetHashCode(first);
            var secondHashCode = comparer.GetHashCode(second);

            // :::: ASSERT ::::
            firstHashCode.Should().Be(secondHashCode);
        }

        /// <summary>
        ///     When two unit instances have the same id, they are equal.
        /// </summary>
        public static TheoryData WhenTwoUnitInstancesHaveTheSameId => new TheoryData
            <IUnit, IUnit>
        {
            /* Two unit instances have id 1. */
            { StubUnit(1), StubUnit(1) },
            //
            /* Two unit instances have id 2. */
            { StubUnit(2), StubUnit(2) },
        };

        /// <summary>
        ///     Two unit instances are not equal when they have different unique identifiers.
        /// </summary>
        [Theory]
        [MemberData(nameof(WhenTwoUnitInstancesHaveDifferentIds))]
        public void Equals_ReturnsFalse_BecauseTheUnitsAreNotEqual(IUnit first, IUnit second)
        {
            // :::: ARRANGE ::::
            var comparer = new UnitEqualityComparer();

            // :::: ACT ::::
            var actualEquality = comparer.Equals(first, second);

            // :::: ASSERT ::::
            actualEquality.Should().BeFalse();
        }

        /// <summary>
        ///     When two unit instances have different ids, they are not equal.
        /// </summary>
        public static TheoryData WhenTwoUnitInstancesHaveDifferentIds => new TheoryData
            <IUnit, IUnit>
        {
            /* Two unit instances have id 1 and id 2, respectively. */
            { StubUnit(1), StubUnit(2) },
            //
            /* Two unit instances have id 3 and id 4, respectively. */
            { StubUnit(3), StubUnit(4) },
        };

        #region HELPERS: Stubs

        private static IUnit StubUnit(int id)
        {
            var stubUnit = A.Fake<IUnit>();
            A.CallTo(() => stubUnit.Id).Returns(GuidUtilities.Id(id));
            return stubUnit;
        }

        #endregion
    }
}
