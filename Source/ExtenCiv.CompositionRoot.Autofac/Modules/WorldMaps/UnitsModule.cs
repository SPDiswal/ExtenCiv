using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.CompositionRoot.Utilities;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Types.Factories.Abstractions;
using ExtenCiv.Units.Utilities;
using ExtenCiv.WorldMaps;

namespace ExtenCiv.Composition.Autofac.Modules.WorldMaps
{
    public sealed class UnitsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof (IUnit<>).Assembly)
                   .Where(t => t.IsUnit())
                   .AsClosedTypesOf(typeof (IUnit<>))
                   .As(t => new KeyedService(t.Name, typeof (IUnit<>).MakeGenericType(t)));

            builder.RegisterAssemblyTypes(typeof (IUnitFactory<>).Assembly)
                   .Where(t => t.IsUnitFactory())
                   .AsClosedTypesOf(typeof (IUnitFactory<>))
                   .SingleInstance();

            builder.RegisterAssemblyTypes(typeof (IProductionProject).Assembly)
                   .Where(t => t.IsProductionProject())
                   .AsSelf()
                   .SingleInstance();

            builder.Register(_ => new HashSet<IUnit>(new UnitEqualityComparer()))
                   .As<ISet<IUnit>>()
                   .SingleInstance();

            builder.RegisterType<SimpleFixedUnitLayer>()
                   .AsImplementedInterfaces()
                   .SingleInstance();
        }
    }
}
