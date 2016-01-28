using System.Collections.Generic;
using ExtenCiv.CompositionRoot.Utilities;
using ExtenCiv.Terrains.Abstractions;
using ExtenCiv.Terrains.Types.Factories.Abstractions;
using ExtenCiv.Terrains.Utilities;
using ExtenCiv.WorldMaps;
using ExtenCiv.WorldMaps.Abstractions;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace ExtenCiv.Composition.Ninject.Modules.WorldMaps
{
    public sealed class TerrainsModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(s => s.FromAssemblyContaining(typeof (ITerrain<>))
                              .SelectAllClasses()
                              .Where(t => t.IsTerrain())
                              .BindAllInterfaces());

            Kernel.Bind(s => s.FromAssemblyContaining(typeof (ITerrainFactory<>))
                              .SelectAllClasses()
                              .Where(t => t.IsTerrainFactory())
                              .BindAllInterfaces()
                              .Configure(b => b.InSingletonScope()));

            Bind<ISet<ITerrain>>().ToMethod(_ => new HashSet<ITerrain>(new TerrainEqualityComparer()))
                                  .InSingletonScope();

            Bind<ITerrainLayer>().To<SimpleFixedTerrainLayer>()
                                 .InSingletonScope();
        }
    }
}
