using System.Collections.Generic;
using System.Linq;
using ExtenCiv.Terrains.Abstractions;
using ExtenCiv.Terrains.Types;
using ExtenCiv.Terrains.Types.Factories.Abstractions;
using ExtenCiv.Utilities.Extensions;
using ExtenCiv.WorldMaps.Abstractions;
using ExtenCiv.WorldMaps.Tiles;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.WorldMaps
{
    /// <summary>
    ///     All tiles are plains except three tiles of oceans, hills and mountains, respectively.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Set of terrains,
    ///     Hills factory,
    ///     Mountains factory,
    ///     Oceans factory,
    ///     Plains factory.
    /// </summary>
    public sealed class SimpleFixedTerrainLayer : ITerrainLayer
    {
        private const int WorldSize = 16;

        private static readonly ITile OceansTile = new SquareTile(1, 0);
        private static readonly ITile HillsTile = new SquareTile(0, 1);
        private static readonly ITile MountainsTile = new SquareTile(2, 2);

        private readonly ITerrainFactory<Plains> plainsFactory;

        public SimpleFixedTerrainLayer(ISet<ITerrain> terrains,
                                       ITerrainFactory<Hills> hillsFactory,
                                       ITerrainFactory<Mountains> mountainsFactory,
                                       ITerrainFactory<Oceans> oceansFactory,
                                       ITerrainFactory<Plains> plainsFactory)
        {
            Terrains = terrains;
            this.plainsFactory = plainsFactory;

            Terrains.Add(hillsFactory.Create(HillsTile));
            Terrains.Add(mountainsFactory.Create(MountainsTile));
            Terrains.Add(oceansFactory.Create(OceansTile));
            
            AddRemainingPlains();
        }

        private void AddRemainingPlains()
        {
            var allTiles = from row in 0.To(WorldSize - 1)
                           from column in 0.To(WorldSize - 1)
                           select new SquareTile(row, column);

            var plainsTiles = allTiles.Except(new[] { OceansTile, HillsTile, MountainsTile });

            foreach (var plainsTile in plainsTiles)
                Terrains.Add(plainsFactory.Create(plainsTile));
        }

        /// <summary>
        ///     Returns the terrains on the world map.
        /// </summary>
        public ISet<ITerrain> Terrains { get; }
    }
}
