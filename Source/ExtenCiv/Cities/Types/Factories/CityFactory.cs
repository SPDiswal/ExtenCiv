using System;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Types.Factories.Abstractions;
using ExtenCiv.Players;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Cities.Types.Factories
{
    public sealed class CityFactory : ICityFactory<City>
    {
        private readonly Func<ICity<City>> cityFactory;

        public CityFactory(Func<ICity<City>> cityFactory) { this.cityFactory = cityFactory; }

        public ICity<City> Create(ITile location, Player owner)
        {
            var city = cityFactory.Invoke();

            city.Location = location;
            city.Owner = owner;

            return city;
        }
    }
}
