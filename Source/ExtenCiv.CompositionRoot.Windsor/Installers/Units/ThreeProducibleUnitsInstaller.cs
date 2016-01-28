using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Units.Types.ProductionProjects;

namespace ExtenCiv.Composition.Windsor.Installers.Units
{
    public sealed class ThreeProducibleUnitsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IDictionary<string, IProductionProject>>()
                                        .UsingFactoryMethod(c => new Dictionary<string, IProductionProject>
                                        {
                                            ["Archer"] = c.Resolve<ArcherProject>(),
                                            ["Legion"] = c.Resolve<LegionProject>(),
                                            ["Settler"] = c.Resolve<SettlerProject>(),
                                        }));
        }
    }
}
