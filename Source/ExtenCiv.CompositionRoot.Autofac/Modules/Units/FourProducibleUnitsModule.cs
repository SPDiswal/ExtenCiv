﻿using System.Collections.Generic;
using Autofac;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Units.Types.ProductionProjects;

namespace ExtenCiv.Composition.Autofac.Modules.Units
{
    public sealed class FourProducibleUnitsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new Dictionary<string, IProductionProject>
            {
                ["Archer"] = c.Resolve<ArcherProject>(),
                ["Chariot"] = c.Resolve<ChariotProject>(),
                ["Legion"] = c.Resolve<LegionProject>(),
                ["Settler"] = c.Resolve<SettlerProject>(),
            }).As<IDictionary<string, IProductionProject>>().SingleInstance();
        }
    }
}
