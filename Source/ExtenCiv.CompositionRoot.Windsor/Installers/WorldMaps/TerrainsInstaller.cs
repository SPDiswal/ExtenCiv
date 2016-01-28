using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ExtenCiv.CompositionRoot.Utilities;
using ExtenCiv.Terrains.Abstractions;
using ExtenCiv.Terrains.Types.Factories.Abstractions;
using ExtenCiv.Terrains.Utilities;
using ExtenCiv.WorldMaps;
using ExtenCiv.WorldMaps.Abstractions;

namespace ExtenCiv.Composition.Windsor.Installers.WorldMaps
{
    public sealed class TerrainsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining(typeof (ITerrain<>))
                                      .BasedOn(typeof (ITerrain<>))
                                      .WithService.FromInterface()
                                      .If(t => t.IsTerrain())
                                      .LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining(typeof (ITerrainFactory<>))
                                      .BasedOn(typeof (ITerrainFactory<>))
                                      .WithService.FromInterface()
                                      .If(t => t.IsTerrainFactory()));

            container.Register(Component.For<ISet<ITerrain>>()
                                        .UsingFactoryMethod(() => new HashSet<ITerrain>(new TerrainEqualityComparer())));

            container.Register(Component.For<ITerrainLayer>()
                                        .ImplementedBy<SimpleFixedTerrainLayer>());
        }
    }
}
