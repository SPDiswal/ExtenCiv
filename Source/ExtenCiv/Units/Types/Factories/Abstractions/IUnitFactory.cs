using ExtenCiv.Players;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Units.Types.Factories.Abstractions
{
    /// <summary>
    ///     A unit factory creates units for the world map.
    /// </summary>
    public interface IUnitFactory
    {
        IUnit Create(ITile location, Player owner);
    }

    /// <summary>
    ///     A unit factory creates units for the world map.
    /// </summary>
    public interface IUnitFactory<TUnit> where TUnit : IUnit<TUnit>
    {
        IUnit<TUnit> Create(ITile location, Player owner);
    }
}
