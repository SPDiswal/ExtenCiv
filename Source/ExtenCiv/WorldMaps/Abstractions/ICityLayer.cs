using System.Collections.Generic;
using ExtenCiv.Cities.Abstractions;

namespace ExtenCiv.WorldMaps.Abstractions
{
    /// <summary>
    ///     A city layer contains all cities on the world map.
    /// </summary>
    public interface ICityLayer
    {
        /// <summary>
        ///     Returns the cities on the world map.
        /// </summary>
        ISet<ICity> Cities { get; }
    }
}
