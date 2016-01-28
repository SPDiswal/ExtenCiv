using System;
using ExtenCiv.Terrains.Abstractions;
using ExtenCiv.Terrains.Types.Factories.Abstractions;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Terrains.Types.Factories
{
    public sealed class MountainsFactory : ITerrainFactory<Mountains>
    {
        private readonly Func<ITerrain<Mountains>> mountainsFactory;

        public MountainsFactory(Func<ITerrain<Mountains>> mountainsFactory)
        {
            this.mountainsFactory = mountainsFactory;
        }

        public ITerrain<Mountains> Create(ITile location)
        {
            var terrain = mountainsFactory.Invoke();

            terrain.Location = location;

            return terrain;
        }

        // TODO: Rewrite unit tests
    }
}
