using System.Collections.Generic;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Units.Types.ProductionProjects;
using Ninject;
using Ninject.Modules;

namespace ExtenCiv.Composition.Ninject.Modules.Units
{
    public sealed class FourProducibleUnitsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDictionary<string, IProductionProject>>().ToMethod(c => new Dictionary<string, IProductionProject>
            {
                ["Archer"] = c.Kernel.Get<ArcherProject>(),
                ["Chariot"] = c.Kernel.Get<ChariotProject>(),
                ["Legion"] = c.Kernel.Get<LegionProject>(),
                ["Settler"] = c.Kernel.Get<SettlerProject>(),
            });
        }
    }
}
