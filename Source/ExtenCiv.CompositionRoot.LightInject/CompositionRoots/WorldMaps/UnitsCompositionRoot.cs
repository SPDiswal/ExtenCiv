using System.Collections.Generic;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.CompositionRoot.Utilities;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Types.Factories.Abstractions;
using ExtenCiv.Units.Utilities;
using ExtenCiv.WorldMaps;
using ExtenCiv.WorldMaps.Abstractions;
using LightInject;

namespace ExtenCiv.Composition.LightInject.CompositionRoots.WorldMaps
{
    public sealed class UnitsCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.RegisterAssembly(typeof (IUnit<>).Assembly,
                                             (_, t) => t.IsUnit());

            serviceRegistry.RegisterAssembly(typeof (IUnitFactory<>).Assembly,
                                             () => new PerContainerLifetime(),
                                             (_, t) => t.IsUnitFactory());

            serviceRegistry.RegisterAssembly(typeof(IProductionProject).Assembly,
                                             () => new PerContainerLifetime(),
                                             (_, t) => t.IsProductionProject());

            serviceRegistry.Register<ISet<IUnit>>(_ => new HashSet<IUnit>(new UnitEqualityComparer()),
                                                  new PerContainerLifetime());

            serviceRegistry.Register<IUnitLayer, SimpleFixedUnitLayer>(new PerContainerLifetime());
        }
    }
}
