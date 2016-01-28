using System.Collections.Generic;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.CompositionRoot.Utilities;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Movement;
using ExtenCiv.Units.Types.Factories.Abstractions;
using ExtenCiv.Units.Utilities;
using ExtenCiv.WorldMaps;
using ExtenCiv.WorldMaps.Abstractions;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace ExtenCiv.Composition.Ninject.Modules.WorldMaps
{
    public sealed class UnitsModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(s => s.FromAssemblyContaining(typeof (IUnit<>))
                              .SelectAllClasses()
                              .Where(t => t.IsUnit())
                              .BindAllInterfaces()

                              // Units are always decorated by Movability.
                              .Configure((b, t) => b.WhenInjectedInto(typeof(Movability<>).MakeGenericType(t))));

            Kernel.Bind(s => s.FromAssemblyContaining(typeof (IUnitFactory<>))
                              .SelectAllClasses()
                              .Where(t => t.IsUnitFactory())
                              .BindAllInterfaces()
                              .Configure(b => b.InSingletonScope()));

            Kernel.Bind(s => s.FromAssemblyContaining(typeof (IProductionProject))
                              .SelectAllClasses()
                              .Where(t => t.IsProductionProject())
                              .BindToSelf()
                              .Configure(b => b.InSingletonScope()));

            Bind<ISet<IUnit>>().ToMethod(_ => new HashSet<IUnit>(new UnitEqualityComparer()))
                               .InSingletonScope();

            Bind<IUnitLayer>().To<SimpleFixedUnitLayer>()
                              .InSingletonScope();
        }
    }
}
