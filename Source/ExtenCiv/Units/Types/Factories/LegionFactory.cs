using System;
using ExtenCiv.Players;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Types.Factories.Abstractions;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Units.Types.Factories
{
    /// <summary>
    ///     A legion factory.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Delegate factory of legions.
    /// </summary>
    public sealed class LegionFactory : IUnitFactory<Legion>, IUnitFactory
    {
        private readonly Func<IUnit<Legion>> legionFactory;

        public LegionFactory(Func<IUnit<Legion>> legionFactory) { this.legionFactory = legionFactory; }

        public IUnit<Legion> Create(ITile location, Player owner)
        {
            var unit = legionFactory.Invoke();

            unit.Location = location;
            unit.Owner = owner;

            return unit;
        }

        IUnit IUnitFactory.Create(ITile location, Player owner) => Create(location, owner);
    }
}
