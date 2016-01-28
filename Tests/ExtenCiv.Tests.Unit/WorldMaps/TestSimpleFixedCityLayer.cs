using System.Linq;
using ExtenCiv.Players;
using ExtenCiv.Tests.Utilities.Stubs;
using ExtenCiv.WorldMaps;
using ExtenCiv.WorldMaps.Tiles;
using ExtenCiv.WorldMaps.Tiles.Abstractions;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.WorldMaps
{
    public sealed class TestSimpleFixedCityLayer
    {
        /// <summary>
        ///     There are exactly two cities in the city layer.
        /// </summary>
        [Fact]
        public void CityLayer_ContainsExactlyTwoCities()
        {
            // :::: ARRANGE and ACT ::::
            var stubCities = StubWorld.NoCities;
            var stubCityFactory = StubFactories.SimpleCityFactory;
            var simpleFixedCityLayer = new SimpleFixedCityLayer(stubCities, stubCityFactory);

            // :::: ASSERT ::::
            simpleFixedCityLayer.Cities.Should().HaveCount(2);
        }

        /// <summary>
        ///     Initially, there is a Red City and a Blue City.
        /// </summary>
        /// <param name="location">The city location.</param>
        /// <param name="expectedOwner">The expected city owner.</param>
        [Theory]
        [MemberData(nameof(AtGameStart))]
        public void CityLayer_ContainsARedCityAndABlueCity(ITile location, Player expectedOwner)
        {
            // :::: ARRANGE ::::
            var stubCities = StubWorld.NoCities;
            var stubCityFactory = StubFactories.SimpleCityFactory;
            var simpleFixedCityLayer = new SimpleFixedCityLayer(stubCities, stubCityFactory);

            // :::: ACT ::::
            var actualCity = simpleFixedCityLayer.Cities.Single(city => city.Location.Equals(location));

            // :::: ASSERT ::::
            actualCity.Owner.Should().Be(expectedOwner);
        }

        /// <summary>
        ///     Initially, there is a Red City at (1, 1) and a Blue City at (4, 1).
        /// </summary>
        public static TheoryData AtGameStart => new TheoryData
            <ITile, Player>
        {
            /* There is a Red City at (1, 1). */
            { Location(1, 1), Red },
            //
            /* There is a Blue City at (4, 1). */
            { Location(4, 1), Blue },
        };

        #region HELPERS: Shortcuts

        private static Player Red => new Player("Red");
        private static Player Blue => new Player("Blue");

        private static ITile Location(int row, int column) => new SquareTile(row, column);

        #endregion
    }
}
