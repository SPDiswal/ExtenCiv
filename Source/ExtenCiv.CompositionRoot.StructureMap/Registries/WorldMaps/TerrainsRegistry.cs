using System.Collections.Generic;
using ExtenCiv.Composition.StructureMap.Conventions;
using ExtenCiv.CompositionRoot.Utilities;
using ExtenCiv.Terrains.Abstractions;
using ExtenCiv.Terrains.Types.Factories.Abstractions;
using ExtenCiv.Terrains.Utilities;
using ExtenCiv.WorldMaps;
using ExtenCiv.WorldMaps.Abstractions;
using StructureMap;

namespace ExtenCiv.Composition.StructureMap.Registries.WorldMaps
{
    public sealed class TerrainsRegistry : Registry
    {
        public TerrainsRegistry()
        {
            Scan(s =>
            {
                s.AssemblyContainingType(typeof (ITerrain<>));
                s.With(new AlwaysUniqueConvention(t => t.IsTerrain(), t => t.ToGenericTerrain()));
            });

            Scan(s =>
            {
                s.AssemblyContainingType(typeof (ITerrainFactory<>));
                s.With(new SingletonConvention(t => t.IsTerrainFactory(), t => t.ToGenericTerrainFactory()));
            });

            ForSingletonOf<ISet<ITerrain>>().Use(_ => new HashSet<ITerrain>(new TerrainEqualityComparer()));
            ForSingletonOf<ITerrainLayer>().Use<SimpleFixedTerrainLayer>();
        }
    }
}
