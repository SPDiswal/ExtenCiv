using System;
using ExtenCiv.Players;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Types.Factories.Abstractions;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Units.Types.Factories
{
    /// <summary>
    ///     A settler factory.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Delegate factory of settlers.
    /// </summary>
    public sealed class SettlerFactory : IUnitFactory<Settler>, IUnitFactory
    {
        private readonly Func<IUnit<Settler>> settlerFactory;

        public SettlerFactory(Func<IUnit<Settler>> settlerFactory) { this.settlerFactory = settlerFactory; }

        public IUnit<Settler> Create(ITile location, Player owner)
        {
            var unit = settlerFactory.Invoke();

            unit.Location = location;
            unit.Owner = owner;

            return unit;
        }

        IUnit IUnitFactory.Create(ITile location, Player owner) => Create(location, owner);
    }
}
