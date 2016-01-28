using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Players;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Cities.Types.Factories.Abstractions
{
    /// <summary>
    ///     A city factory creates cities for the world map.
    /// </summary>
    public interface ICityFactory<TCity> where TCity : ICity<TCity>
    {
        ICity<TCity> Create(ITile location, Player owner);
    }
}
