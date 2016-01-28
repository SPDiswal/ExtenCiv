using ExtenCiv.Cities.Types;
using ExtenCiv.Cities.Types.Factories;
using ExtenCiv.Cities.Types.Factories.Abstractions;
using ExtenCiv.Players;
using ExtenCiv.WorldMaps.Tiles;
using ExtenCiv.WorldMaps.Tiles.Abstractions;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.Cities.Types.Factories
{
    public sealed class TestCityFactories
    {
        /// <summary>
        ///     The factory sets the owner and location of the newly created city.
        /// </summary>
        /// <param name="location">The location of the city.</param>
        /// <param name="owner">The owner of the city.</param>
        /// <param name="factory">The city factory.</param>
        [Theory]
        [MemberData(nameof(WhenCreatingACity))]
        public void Create_ReturnsAUnitWithALocationAndAnOwner(ITile location, Player owner, ICityFactory<City> factory)
        {
            // :::: ACT ::::
            var city = factory.Create(location, owner);

            // :::: ASSERT ::::
            city.Location.Should().Be(location);
            city.Owner.Should().Be(owner);
        }

        /// <summary>
        ///     When creating a city, the factory sets the owner and location of the city.
        /// </summary>
        public static TheoryData WhenCreatingACity => new TheoryData
            <ITile, Player, ICityFactory<City>>
        {
            /* Creating a Red City at (2, 0). */
            { Location(2, 0), Red, CityFactory },
            //
            /* Creating a Blue City at (3, 2). */
            { Location(3, 2), Blue, CityFactory },
        };

        #region HELPERS: Shortcuts

        private static Player Red => new Player("Red");
        private static Player Blue => new Player("Blue");

        private static ITile Location(int row, int column) => new SquareTile(row, column);

        private static ICityFactory<City> CityFactory => new CityFactory(() => new City());

        #endregion
    }
}
