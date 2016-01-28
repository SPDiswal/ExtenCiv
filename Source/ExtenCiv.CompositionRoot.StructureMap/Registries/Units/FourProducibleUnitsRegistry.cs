using System;
using System.Collections.Generic;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Units.Types.ProductionProjects;
using StructureMap;

namespace ExtenCiv.Composition.StructureMap.Registries.Units
{
    public sealed class FourProducibleUnitsRegistry : Registry
    {
        public FourProducibleUnitsRegistry()
        {
            Func<IContext, Dictionary<string, IProductionProject>> projects =
                c => new Dictionary<string, IProductionProject>
                {
                    ["Archer"] = c.GetInstance<ArcherProject>(),
                    ["Chariot"] = c.GetInstance<ChariotProject>(),
                    ["Legion"] = c.GetInstance<LegionProject>(),
                    ["Settler"] = c.GetInstance<SettlerProject>(),
                };

            ForSingletonOf<IDictionary<string, IProductionProject>>().Use(c => projects.Invoke(c));
        }
    }
}
