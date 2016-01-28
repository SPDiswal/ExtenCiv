using System.Collections.Generic;
using ExtenCiv.Terrains.Abstractions;

namespace ExtenCiv.WorldMaps.Abstractions
{
    /// <summary>
    ///     A terrain layer contains all terrains on the world map.
    /// </summary>
    public interface ITerrainLayer
    {
        /// <summary>
        ///     Returns the terrains on the world map.
        /// </summary>
        ISet<ITerrain> Terrains { get; }
    }
}
