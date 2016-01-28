using System.Collections.Generic;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Units.Types.ProductionProjects;
using LightInject;

namespace ExtenCiv.Composition.LightInject.CompositionRoots.Units
{
    public sealed class FourProducibleUnitsCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IDictionary<string, IProductionProject>>(
                c => new Dictionary<string, IProductionProject>
                {
                    ["Archer"] = c.GetInstance<ArcherProject>(),
                    ["Chariot"] = c.GetInstance<ChariotProject>(),
                    ["Legion"] = c.GetInstance<LegionProject>(),
                    ["Settler"] = c.GetInstance<SettlerProject>(),
                }, new PerContainerLifetime());
        }
    }
}
