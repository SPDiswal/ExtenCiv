using System.Collections.Generic;
using ExtenCiv.CompositionRoot.Utilities;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Utilities;
using ExtenCiv.WorldMaps;
using ExtenCiv.WorldMaps.Abstractions;
using Microsoft.Practices.Unity;

namespace ExtenCiv.Composition.Unity.Extensions.WorldMaps
{
    public sealed class UnitsExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterTypes(TypeConstraints.Units,
                                    t => new[] { t.ToGenericUnit() },
                                    t => t.Name);

            Container.RegisterTypes(TypeConstraints.UnitFactories,
                                    t => new[] { t.ToGenericUnitFactory() },
                                    getLifetimeManager: WithLifetime.ContainerControlled);

            Container.RegisterTypes(TypeConstraints.ProductionProjects,
                                    t => new[] { t },
                                    getLifetimeManager: WithLifetime.ContainerControlled);

            Container.RegisterType<ISet<IUnit>>(new ContainerControlledLifetimeManager(),
                                                new InjectionFactory(_ => new HashSet<IUnit>(
                                                                              new UnitEqualityComparer())));

            Container.RegisterType<IUnitLayer, SimpleFixedUnitLayer>(new ContainerControlledLifetimeManager());
        }
    }
}
