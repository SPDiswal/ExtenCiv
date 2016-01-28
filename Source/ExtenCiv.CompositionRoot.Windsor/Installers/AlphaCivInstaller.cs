using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ExtenCiv.Composition.Windsor.Installers.Units;
using ExtenCiv.Winners;
using ExtenCiv.Winners.Abstractions;
using ExtenCiv.WorldAges;
using ExtenCiv.WorldAges.Abstractions;

namespace ExtenCiv.Composition.Windsor.Installers
{
    public sealed class AlphaCivInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Install(new CommonInstaller(),
                              new ThreeProducibleUnitsInstaller());

            container.Register(Component.For<IWorldAge>().ImplementedBy<LinearWorldAge>(),
                               Component.For<IWinnerStrategy>().ImplementedBy<RedWinsIn3000Bce>());
        }
    }
}
