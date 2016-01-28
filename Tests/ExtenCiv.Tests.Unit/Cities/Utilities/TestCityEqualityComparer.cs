using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Utilities;
using ExtenCiv.Tests.Utilities;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.Cities.Utilities
{
    public sealed class TestCityEqualityComparer
    {
        /// <summary>
        ///     Two city instances are equal when they have the same unique identifier.
        /// </summary>
        [Theory]
        [MemberData(nameof(WhenTwoCityInstancesHaveTheSameId))]
        public void Equals_ReturnsTrue_BecauseTheCitiesAreEqual(ICity first, ICity second)
        {
            // :::: ARRANGE ::::
            var comparer = new CityEqualityComparer();

            // :::: ACT ::::
            var actualEquality = comparer.Equals(first, second);

            // :::: ASSERT ::::
            actualEquality.Should().BeTrue();
        }

        /// <summary>
        ///     Two city instances have the same hash code when they have the same unique identifier.
        /// </summary>
        [Theory]
        [MemberData(nameof(WhenTwoCityInstancesHaveTheSameId))]
        public void GetHashCode_ReturnsTheSameHashCodeForBothCities_BecauseTheCitiesAreEqual(ICity first, ICity second)
        {
            // :::: ARRANGE ::::
            var comparer = new CityEqualityComparer();

            // :::: ACT ::::
            var firstHashCode = comparer.GetHashCode(first);
            var secondHashCode = comparer.GetHashCode(second);

            // :::: ASSERT ::::
            firstHashCode.Should().Be(secondHashCode);
        }

        /// <summary>
        ///     When two city instances have the same id, they are equal.
        /// </summary>
        public static TheoryData WhenTwoCityInstancesHaveTheSameId => new TheoryData
            <ICity, ICity>
        {
            /* Two city instances have id 1. */
            { StubCity(1), StubCity(1) },
            //
            /* Two city instances have id 2. */
            { StubCity(2), StubCity(2) },
        };

        /// <summary>
        ///     Two city instances are not equal when they have different unique identifiers.
        /// </summary>
        [Theory]
        [MemberData(nameof(WhenTwoCityInstancesHaveDifferentIds))]
        public void Equals_ReturnsFalse_BecauseTheCitiesAreNotEqual(ICity first, ICity second)
        {
            // :::: ARRANGE ::::
            var comparer = new CityEqualityComparer();

            // :::: ACT ::::
            var actualEquality = comparer.Equals(first, second);

            // :::: ASSERT ::::
            actualEquality.Should().BeFalse();
        }

        /// <summary>
        ///     When two city instances have different ids, they are not equal.
        /// </summary>
        public static TheoryData WhenTwoCityInstancesHaveDifferentIds => new TheoryData
            <ICity, ICity>
        {
            /* Two city instances have id 1 and id 2, respectively. */
            { StubCity(1), StubCity(2) },
            //
            /* Two city instances have id 3 and id 4, respectively. */
            { StubCity(3), StubCity(4) },
        };

        #region HELPERS: Stubs

        private static ICity StubCity(int id)
        {
            var stubCity = A.Fake<ICity>();
            A.CallTo(() => stubCity.Id).Returns(GuidUtilities.Id(id));
            return stubCity;
        }

        #endregion
    }
}
