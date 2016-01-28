using ExtenCiv.Terrains.Abstractions;
using ExtenCiv.WorldMaps.Tiles;

namespace ExtenCiv.Tests.Utilities.Extensions
{
    public static class TerrainExtensions
    {
        public static ITerrain At(this ITerrain terrain, int row, int column)
        {
            terrain.Location = new SquareTile(row, column);
            return terrain;
        }
    }
}
