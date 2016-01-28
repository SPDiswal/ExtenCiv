using System.Collections.Generic;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Types.Factories.Abstractions;
using ExtenCiv.Cities.Utilities;
using ExtenCiv.Cities.Workforce;
using ExtenCiv.CompositionRoot.Utilities;
using ExtenCiv.WorldMaps;
using ExtenCiv.WorldMaps.Abstractions;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace ExtenCiv.Composition.Ninject.Modules.WorldMaps
{
    public sealed class CitiesModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(s => s.FromAssemblyContaining(typeof (ICity<>))
                              .SelectAllClasses()
                              .Where(t => t.IsCity())
                              .BindAllInterfaces()

                              // Cities are always decorated by NoCityGrowth.
                              .Configure((b, t) => b.WhenInjectedInto(typeof (NoCityGrowth<>).MakeGenericType(t))));

            Kernel.Bind(s => s.FromAssemblyContaining(typeof (ICityFactory<>))
                              .SelectAllClasses()
                              .Where(t => t.IsCityFactory())
                              .BindAllInterfaces()
                              .Configure(b => b.InSingletonScope()));

            Bind<ISet<ICity>>().ToMethod(_ => new HashSet<ICity>(new CityEqualityComparer()))
                               .InSingletonScope();

            Bind<ICityLayer>().To<SimpleFixedCityLayer>()
                              .InSingletonScope();
        }
    }
}
