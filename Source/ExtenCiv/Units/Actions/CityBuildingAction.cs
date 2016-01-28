using System.Collections.Generic;
using System.Linq;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Types;
using ExtenCiv.Cities.Types.Factories.Abstractions;
using ExtenCiv.Units.Abstractions;

namespace ExtenCiv.Units.Actions
{
    /// <summary>
    ///     A city-building unit can perform a special action that replaces the unit with a new city.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Decorated unit,
    ///     Set of units,
    ///     Set of cities,
    ///     City factory.
    /// </summary>
    public sealed class CityBuildingAction<TUnit> : UnitDecorator<TUnit> where TUnit : IUnit<TUnit>
    {
        private readonly ISet<ICity> cities;
        private readonly ISet<IUnit> units;
        private readonly ICityFactory<City> cityFactory;

        public CityBuildingAction(IUnit<TUnit> unit,
                                  ISet<IUnit> units,
                                  ISet<ICity> cities,
                                  ICityFactory<City> cityFactory) : base(unit)
        {
            this.cities = cities;
            this.units = units;
            this.cityFactory = cityFactory;
        }

        /// <summary>
        ///     Performs the special action of this unit.
        /// </summary>
        public override void PerformAction()
        {
            base.PerformAction();

            if (!IsTileOccupiedByCity)
                BuildCity();
        }

        private bool IsTileOccupiedByCity => cities.Any(city => city.Location.Equals(Location));

        private void BuildCity()
        {
            var newCity = cityFactory.Create(Location, Owner);
            cities.Add(newCity);

            units.Remove(this);
        }
    }
}
