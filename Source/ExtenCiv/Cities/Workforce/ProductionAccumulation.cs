using System.Collections.Generic;
using System.Linq;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Players.Events;
using ExtenCiv.Units.Abstractions;

namespace ExtenCiv.Cities.Workforce
{
    /// <summary>
    ///     The city accumulates production points in its production treasury in the beginning of every round.
    ///     It spawns the unit of the current production project when it has accumulated enough production points,
    ///     subtracting the cost of the unit from the treasury.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Decorated city,
    ///     Set of units,
    ///     Notifier of when the next round begins.
    /// </summary>
    public sealed class ProductionAccumulation<TCity> : CityDecorator<TCity> where TCity : ICity<TCity>
    {
        private readonly ISet<IUnit> units;

        public ProductionAccumulation(ICity<TCity> city, ISet<IUnit> units, INotifyBeginningNextRound notifier)
            : base(city)
        {
            this.units = units;
            notifier.BeginningNextRound += OnBeginningNextRound;

            /* TODO There is a memory leak here. The city must unsubscribe from the event if it is somehow removed 
                    from the world map in order to garbage-collect it. */
        }

        private void OnBeginningNextRound(object sender, BeginningNextRoundEventArgs e)
        {
            ProductionTreasury += GeneratedProduction;

            if (ProductionTreasury >= ProductionProject.Cost && !IsCityTileOccupiedByUnit)
                ProduceNewUnit();
        }

        private bool IsCityTileOccupiedByUnit => units.Any(unit => unit.Location.Equals(Location));

        private void ProduceNewUnit()
        {
            var newlyProducedUnit = ProductionProject.Factory.Create(Location, Owner);
            units.Add(newlyProducedUnit);

            ProductionTreasury -= ProductionProject.Cost;
        }
    }
}
