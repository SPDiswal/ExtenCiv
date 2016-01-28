using System.Collections.Generic;
using ExtenCiv.Terrains.Abstractions;

namespace ExtenCiv.Terrains.Utilities
{
    public sealed class TerrainEqualityComparer : IEqualityComparer<ITerrain>
    {
        public bool Equals(ITerrain first, ITerrain second) => ReferenceEquals(first, second)
                                                               || !ReferenceEquals(first, null)
                                                               && !ReferenceEquals(second, null)
                                                               && first.Id == second.Id;

        public int GetHashCode(ITerrain terrain) => terrain.Id.GetHashCode();
    }
}
