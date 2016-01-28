using System.Collections.Generic;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Types;
using ExtenCiv.Cities.Types.Factories.Abstractions;
using ExtenCiv.Players;
using ExtenCiv.WorldMaps.Abstractions;
using ExtenCiv.WorldMaps.Tiles;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.WorldMaps
{
    /// <summary>
    ///     Initially, the players named 'Red' and 'Blue' have a city each.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Set of cities,
    ///     City factory.
    /// </summary>
    public sealed class SimpleFixedCityLayer : ICityLayer
    {
        private static readonly Player Red = new Player("Red");
        private static readonly Player Blue = new Player("Blue");

        private static readonly ITile RedCityTile = new SquareTile(1, 1);
        private static readonly ITile BlueCityTile = new SquareTile(4, 1);

        public SimpleFixedCityLayer(ISet<ICity> cities, ICityFactory<City> cityFactory)
        {
            Cities = cities;

            Cities.Add(cityFactory.Create(RedCityTile, Red));
            Cities.Add(cityFactory.Create(BlueCityTile, Blue));
        }

        /// <summary>
        ///     Returns the cities on the world map.
        /// </summary>
        public ISet<ICity> Cities { get; }
    }
}
