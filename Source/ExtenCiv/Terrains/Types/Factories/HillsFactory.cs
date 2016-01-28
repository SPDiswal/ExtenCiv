using System;
using ExtenCiv.Terrains.Abstractions;
using ExtenCiv.Terrains.Types.Factories.Abstractions;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Terrains.Types.Factories
{
    public sealed class HillsFactory : ITerrainFactory<Hills>
    {
        private readonly Func<ITerrain<Hills>> hillsFactory;

        public HillsFactory(Func<ITerrain<Hills>> hillsFactory) { this.hillsFactory = hillsFactory; }

        public ITerrain<Hills> Create(ITile location)
        {
            var terrain = hillsFactory.Invoke();

            terrain.Location = location;

            return terrain;
        }

        // TODO: Rewrite unit tests
    }
}
