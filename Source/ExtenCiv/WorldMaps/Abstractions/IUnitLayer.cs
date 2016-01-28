using System.Collections.Generic;
using ExtenCiv.Units.Abstractions;

namespace ExtenCiv.WorldMaps.Abstractions
{
    /// <summary>
    ///     A unit layer contains all units on the world map.
    /// </summary>
    public interface IUnitLayer
    {
        /// <summary>
        ///     Returns the units on the world map.
        /// </summary>
        ISet<IUnit> Units { get; }
    }
}
