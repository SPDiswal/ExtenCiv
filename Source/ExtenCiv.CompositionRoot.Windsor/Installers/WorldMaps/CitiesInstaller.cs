using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Types.Factories.Abstractions;
using ExtenCiv.Cities.Utilities;
using ExtenCiv.CompositionRoot.Utilities;
using ExtenCiv.WorldMaps;
using ExtenCiv.WorldMaps.Abstractions;

namespace ExtenCiv.Composition.Windsor.Installers.WorldMaps
{
    public sealed class CitiesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining(typeof (ICity<>))
                                      .BasedOn(typeof (ICity<>))
                                      .WithService.FromInterface()
                                      .If(t => t.IsCity())
                                      .LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining(typeof (ICityFactory<>))
                                      .BasedOn(typeof (ICityFactory<>))
                                      .WithService.FromInterface()
                                      .If(t => t.IsCityFactory()));

            container.Register(Component.For<ISet<ICity>>()
                                        .UsingFactoryMethod(() => new HashSet<ICity>(new CityEqualityComparer())));

            container.Register(Component.For<ICityLayer>()
                                        .ImplementedBy<SimpleFixedCityLayer>());
        }
    }
}
