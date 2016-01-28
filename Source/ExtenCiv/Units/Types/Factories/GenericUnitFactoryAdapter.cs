using ExtenCiv.Players;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Types.Factories.Abstractions;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Units.Types.Factories
{
    /// <summary>
    ///     An adapter for converting a generic unit factory into a non-generic one.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Generic unit factory.
    /// </summary>
    public sealed class GenericUnitFactoryAdapter<TUnit> : IUnitFactory where TUnit : IUnit<TUnit>
    {
        private readonly IUnitFactory<TUnit> unitFactory;

        public GenericUnitFactoryAdapter(IUnitFactory<TUnit> unitFactory) { this.unitFactory = unitFactory; }

        public IUnit Create(ITile location, Player owner) => unitFactory.Create(location, owner);
    }
}
