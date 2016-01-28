using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.CompositionRoot.Utilities;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Types.Factories.Abstractions;
using ExtenCiv.Units.Utilities;
using ExtenCiv.WorldMaps;
using ExtenCiv.WorldMaps.Abstractions;

namespace ExtenCiv.Composition.Windsor.Installers.WorldMaps
{
    public sealed class UnitsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining(typeof (IUnit<>))
                                      .BasedOn(typeof (IUnit<>))
                                      .WithService.FromInterface()
                                      .If(t => t.IsUnit())
                                      .LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining(typeof (IUnitFactory<>))
                                      .BasedOn(typeof (IUnitFactory<>))
                                      .WithService.FromInterface()
                                      .If(t => t.IsUnitFactory()));

            container.Register(Classes.FromAssemblyContaining(typeof (IProductionProject))
                                      .Where(t => t.IsProductionProject()));

            container.Register(Component.For<ISet<IUnit>>()
                                        .UsingFactoryMethod(() => new HashSet<IUnit>(new UnitEqualityComparer())));

            container.Register(Component.For<IUnitLayer>()
                                        .ImplementedBy<SimpleFixedUnitLayer>());
        }
    }
}
