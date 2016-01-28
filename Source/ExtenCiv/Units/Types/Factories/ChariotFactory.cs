using System;
using ExtenCiv.Players;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Types.Factories.Abstractions;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Units.Types.Factories
{
    /// <summary>
    ///     A chariot factory.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Delegate factory of chariots.
    /// </summary>
    public sealed class ChariotFactory : IUnitFactory<Chariot>, IUnitFactory
    {
        private readonly Func<IUnit<Chariot>> chariotFactory;

        public ChariotFactory(Func<IUnit<Chariot>> chariotFactory) { this.chariotFactory = chariotFactory; }

        public IUnit<Chariot> Create(ITile location, Player owner)
        {
            var unit = chariotFactory.Invoke();

            unit.Location = location;
            unit.Owner = owner;

            return unit;
        }

        IUnit IUnitFactory.Create(ITile location, Player owner) => Create(location, owner);
    }
}
