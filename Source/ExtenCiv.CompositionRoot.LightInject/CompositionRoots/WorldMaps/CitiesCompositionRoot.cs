using System.Collections.Generic;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Types.Factories.Abstractions;
using ExtenCiv.Cities.Utilities;
using ExtenCiv.CompositionRoot.Utilities;
using ExtenCiv.WorldMaps;
using ExtenCiv.WorldMaps.Abstractions;
using LightInject;

namespace ExtenCiv.Composition.LightInject.CompositionRoots.WorldMaps
{
    public sealed class CitiesCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.RegisterAssembly(typeof (ICity<>).Assembly,
                                             (_, t) => t.IsCity());

            serviceRegistry.RegisterAssembly(typeof (ICityFactory<>).Assembly,
                                             () => new PerContainerLifetime(),
                                             (_, t) => t.IsCityFactory());

            serviceRegistry.Register<ISet<ICity>>(_ => new HashSet<ICity>(new CityEqualityComparer()),
                                                  new PerContainerLifetime());

            serviceRegistry.Register<ICityLayer, SimpleFixedCityLayer>(new PerContainerLifetime());
        }
    }
}
