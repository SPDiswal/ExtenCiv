using ExtenCiv.Terrains.Abstractions;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Terrains.Types.Factories.Abstractions
{
    /// <summary>
    ///     A terrain factory creates terrain elements for the world map.
    /// </summary>
    public interface ITerrainFactory<TTerrain> where TTerrain : ITerrain<TTerrain>
    {
        ITerrain<TTerrain> Create(ITile location);
    }
}
