using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Types;
using ExtenCiv.Cities.Workforce;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.Cities.Workforce
{
    public sealed class TestNoCityGrowth
    {
        /// <summary>
        ///     The generated food is fixed to zero points per round.
        /// </summary>
        [Fact]
        public void GeneratedFood_IsZero()
        {
            // :::: ARRANGE and ACT ::::
            var dummyCity = A.Fake<ICity<City>>();
            var noGrowthCity = new NoCityGrowth<City>(dummyCity);

            // :::: ASSERT ::::
            noGrowthCity.GeneratedFood.Should().Be(0);
        }
    }
}
