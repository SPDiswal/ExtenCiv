using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Types.Factories.Abstractions;
using ExtenCiv.Cities.Utilities;
using ExtenCiv.CompositionRoot.Utilities;
using ExtenCiv.WorldMaps;

namespace ExtenCiv.Composition.Autofac.Modules.WorldMaps
{
    public sealed class CitiesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof (ICity<>).Assembly)
                   .Where(t => t.IsCity())
                   .AsClosedTypesOf(typeof(ICity<>))
                   .As(t => new KeyedService(t.Name, typeof(ICity<>).MakeGenericType(t)));

            builder.RegisterAssemblyTypes(typeof (ICityFactory<>).Assembly)
                   .Where(t => t.IsCityFactory())
                   .AsClosedTypesOf(typeof (ICityFactory<>))
                   .SingleInstance();

            builder.Register(_ => new HashSet<ICity>(new CityEqualityComparer()))
                   .As<ISet<ICity>>()
                   .SingleInstance();

            builder.RegisterType<SimpleFixedCityLayer>()
                   .AsImplementedInterfaces()
                   .SingleInstance();
        }
    }
}
