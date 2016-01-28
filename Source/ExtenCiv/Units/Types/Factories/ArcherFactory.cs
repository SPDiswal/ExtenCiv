using System;
using ExtenCiv.Players;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Types.Factories.Abstractions;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Units.Types.Factories
{
    /// <summary>
    ///     An archer factory.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Delegate factory of archers.
    /// </summary>
    public sealed class ArcherFactory : IUnitFactory<Archer>, IUnitFactory
    {
        private readonly Func<IUnit<Archer>> archerFactory;

        public ArcherFactory(Func<IUnit<Archer>> archerFactory) { this.archerFactory = archerFactory; }

        public IUnit<Archer> Create(ITile location, Player owner)
        {
            var unit = archerFactory.Invoke();

            unit.Location = location;
            unit.Owner = owner;

            return unit;
        }

        IUnit IUnitFactory.Create(ITile location, Player owner) => Create(location, owner);
    }
}
