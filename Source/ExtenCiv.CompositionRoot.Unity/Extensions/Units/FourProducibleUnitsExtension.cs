using System.Collections.Generic;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Units.Types.ProductionProjects;
using Microsoft.Practices.Unity;

namespace ExtenCiv.Composition.Unity.Extensions.Units
{
    public sealed class FourProducibleUnitsExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IDictionary<string, IProductionProject>>(
                new ContainerControlledLifetimeManager(),
                new InjectionFactory(c => new Dictionary<string, IProductionProject>
                {
                    ["Archer"] = c.Resolve<ArcherProject>(),
                    ["Chariot"] = c.Resolve<ChariotProject>(),
                    ["Legion"] = c.Resolve<LegionProject>(),
                    ["Settler"] = c.Resolve<SettlerProject>(),
                }));
        }
    }
}
