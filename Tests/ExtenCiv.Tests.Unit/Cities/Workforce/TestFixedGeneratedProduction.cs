using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Types;
using ExtenCiv.Cities.Workforce;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.Cities.Workforce
{
    public sealed class TestFixedGeneratedProduction
    {
        /// <summary>
        ///     The generated production is fixed to six points per round.
        /// </summary>
        [Fact]
        public void GeneratedProduction_IsSix()
        {
            // :::: ARRANGE and ACT ::::
            var dummyCity = A.Fake<ICity<City>>();
            var fixedProductionCity = new FixedGeneratedProduction<City>(dummyCity);

            // :::: ASSERT ::::
            fixedProductionCity.GeneratedProduction.Should().Be(6);
        }
    }
}
