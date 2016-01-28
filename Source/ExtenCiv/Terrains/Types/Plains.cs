using System;
using ExtenCiv.Terrains.Abstractions;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Terrains.Types
{
    public sealed class Plains : ITerrain<Plains>
    {
        /// <summary>
        ///     The unique identifier of this terrain.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        ///     The type string identifying the type of this terrain.
        /// </summary>
        public string Type { get; set; } = "Plains";

        /// <summary>
        ///     The location of this terrain on the world map.
        /// </summary>
        public ITile Location { get; set; }

        public override string ToString() => $"{Type} at {Location}";
    }
}
