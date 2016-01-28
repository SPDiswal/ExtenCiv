using System.Collections.Generic;
using System.Linq;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Units.Movement
{
    /// <summary>
    ///     The unit conquers an opponent city when entering its tile.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Decorated unit,
    ///     Set of cities.
    /// </summary>
    public sealed class CityConquest<TUnit> : UnitDecorator<TUnit> where TUnit : IUnit<TUnit>
    {
        private readonly ISet<ICity> cities;

        public CityConquest(IUnit<TUnit> unit, ISet<ICity> cities) : base(unit) { this.cities = cities; }

        /// <summary>
        ///     Moves this unit to the specified location.
        /// </summary>
        /// <param name="destination">The tile to move the unit to.</param>
        public override void MoveTo(ITile destination)
        {
            base.MoveTo(destination);

            var cityAtDestination = cities.SingleOrDefault(city => city.Location.Equals(destination));
            if (cityAtDestination != null) cityAtDestination.Owner = Owner;
        }
    }
}
