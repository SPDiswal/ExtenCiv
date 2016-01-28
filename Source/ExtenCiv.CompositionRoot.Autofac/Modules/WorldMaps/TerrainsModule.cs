using System.Collections.Generic;
using Autofac;
using ExtenCiv.CompositionRoot.Utilities;
using ExtenCiv.Terrains.Abstractions;
using ExtenCiv.Terrains.Types.Factories.Abstractions;
using ExtenCiv.Terrains.Utilities;
using ExtenCiv.WorldMaps;

namespace ExtenCiv.Composition.Autofac.Modules.WorldMaps
{
    public sealed class TerrainsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof (ITerrain<>).Assembly)
                   .Where(t => t.IsTerrain())
                   .AsClosedTypesOf(typeof (ITerrain<>));

            builder.RegisterAssemblyTypes(typeof (ITerrainFactory<>).Assembly)
                   .Where(t => t.IsTerrainFactory())
                   .AsClosedTypesOf(typeof (ITerrainFactory<>))
                   .SingleInstance();

            builder.Register(_ => new HashSet<ITerrain>(new TerrainEqualityComparer()))
                   .As<ISet<ITerrain>>()
                   .SingleInstance();

            builder.RegisterType<SimpleFixedTerrainLayer>()
                   .AsImplementedInterfaces()
                   .SingleInstance();
        }
    }
}
