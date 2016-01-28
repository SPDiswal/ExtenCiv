using System.Collections.Generic;
using ExtenCiv.CompositionRoot.Utilities;
using ExtenCiv.Terrains.Abstractions;
using ExtenCiv.Terrains.Utilities;
using ExtenCiv.WorldMaps;
using ExtenCiv.WorldMaps.Abstractions;
using Microsoft.Practices.Unity;

namespace ExtenCiv.Composition.Unity.Extensions.WorldMaps
{
    public sealed class TerrainsExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterTypes(TypeConstraints.Terrains,
                                    t => new[] { t.ToGenericTerrain() });

            Container.RegisterTypes(TypeConstraints.TerrainFactories,
                                    t => new[] { t.ToGenericTerrainFactory() },
                                    getLifetimeManager: WithLifetime.ContainerControlled);

            Container.RegisterType<ISet<ITerrain>>(
                new ContainerControlledLifetimeManager(),
                new InjectionFactory(_ => new HashSet<ITerrain>(new TerrainEqualityComparer())));

            Container.RegisterType<ITerrainLayer, SimpleFixedTerrainLayer>(new ContainerControlledLifetimeManager());
        }
    }
}
