using System.Collections.Generic;
using ExtenCiv.CompositionRoot.Utilities;
using ExtenCiv.Terrains.Abstractions;
using ExtenCiv.Terrains.Types.Factories.Abstractions;
using ExtenCiv.Terrains.Utilities;
using ExtenCiv.WorldMaps;
using ExtenCiv.WorldMaps.Abstractions;
using LightInject;

namespace ExtenCiv.Composition.LightInject.CompositionRoots.WorldMaps
{
    public sealed class TerrainsCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.RegisterAssembly(typeof (ITerrain<>).Assembly,
                                             (_, t) => t.IsTerrain());

            serviceRegistry.RegisterAssembly(typeof (ITerrainFactory<>).Assembly,
                                             () => new PerContainerLifetime(),
                                             (_, t) => t.IsTerrainFactory());

            serviceRegistry.Register<ISet<ITerrain>>(_ => new HashSet<ITerrain>(new TerrainEqualityComparer()),
                                                     new PerContainerLifetime());

            serviceRegistry.Register<ITerrainLayer, SimpleFixedTerrainLayer>(new PerContainerLifetime());
        }
    }
}
