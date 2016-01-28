using System.Collections.Generic;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Utilities;
using ExtenCiv.CompositionRoot.Utilities;
using ExtenCiv.WorldMaps;
using ExtenCiv.WorldMaps.Abstractions;
using Microsoft.Practices.Unity;

namespace ExtenCiv.Composition.Unity.Extensions.WorldMaps
{
    public sealed class CitiesExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterTypes(TypeConstraints.Cities,
                                    t => new[] { t.ToGenericCity() },
                                    t => t.Name);

            Container.RegisterTypes(TypeConstraints.CityFactories,
                                    t => new[] { t.ToGenericCityFactory() },
                                    getLifetimeManager: WithLifetime.ContainerControlled);

            Container.RegisterType<ISet<ICity>>(
                new ContainerControlledLifetimeManager(),
                new InjectionFactory(_ => new HashSet<ICity>(new CityEqualityComparer())));

            Container.RegisterType<ICityLayer, SimpleFixedCityLayer>(new ContainerControlledLifetimeManager());
        }
    }
}
