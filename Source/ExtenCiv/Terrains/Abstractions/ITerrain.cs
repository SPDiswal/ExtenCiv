using System;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Terrains.Abstractions
{
    /// <summary>
    ///     A terrain represents the geographic features of a location on the world map.
    /// </summary>
    public interface ITerrain
    {
        /// <summary>
        ///     The unique identifier of this terrain.
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        ///     The type string identifying the type of this terrain.
        /// </summary>
        string Type { get; set; }

        /// <summary>
        ///     The location of this terrain on the world map.
        /// </summary>
        ITile Location { get; set; }
    }

    /// <summary>
    ///     A terrain represents the geographic features of a location on the world map.
    /// </summary>
    public interface ITerrain<TTerrain> : ITerrain where TTerrain : ITerrain<TTerrain>
    {
    }
}
