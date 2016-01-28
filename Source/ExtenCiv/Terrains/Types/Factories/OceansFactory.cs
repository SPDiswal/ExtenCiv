using System;
using ExtenCiv.Terrains.Abstractions;
using ExtenCiv.Terrains.Types.Factories.Abstractions;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Terrains.Types.Factories
{
    public sealed class OceansFactory : ITerrainFactory<Oceans>
    {
        private readonly Func<ITerrain<Oceans>> oceansFactory;

        public OceansFactory(Func<ITerrain<Oceans>> oceansFactory) { this.oceansFactory = oceansFactory; }

        public ITerrain<Oceans> Create(ITile location)
        {
            var terrain = oceansFactory.Invoke();

            terrain.Location = location;

            return terrain;
        }

        // TODO: Rewrite unit tests
    }
}
