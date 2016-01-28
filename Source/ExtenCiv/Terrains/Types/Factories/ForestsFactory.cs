using System;
using ExtenCiv.Terrains.Abstractions;
using ExtenCiv.Terrains.Types.Factories.Abstractions;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Terrains.Types.Factories
{
    public sealed class ForestsFactory : ITerrainFactory<Forests>
    {
        private readonly Func<ITerrain<Forests>> forestsFactory;

        public ForestsFactory(Func<ITerrain<Forests>> forestsFactory) { this.forestsFactory = forestsFactory; }

        public ITerrain<Forests> Create(ITile location)
        {
            var terrain = forestsFactory.Invoke();

            terrain.Location = location;

            return terrain;
        }

        // TODO: Rewrite unit tests
    }
}
