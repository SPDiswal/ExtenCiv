using System;
using ExtenCiv.Terrains.Abstractions;
using ExtenCiv.Terrains.Types.Factories.Abstractions;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Terrains.Types.Factories
{
    public sealed class PlainsFactory : ITerrainFactory<Plains>
    {
        private readonly Func<ITerrain<Plains>> plainsFactory;

        public PlainsFactory(Func<ITerrain<Plains>> plainsFactory) { this.plainsFactory = plainsFactory; }

        public ITerrain<Plains> Create(ITile location)
        {
            var terrain = plainsFactory.Invoke();

            terrain.Location = location;

            return terrain;
        }

        // TODO: Rewrite unit tests
    }
}
