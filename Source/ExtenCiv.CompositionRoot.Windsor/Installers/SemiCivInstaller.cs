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
    public sealed class SemiCivInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Install(new CommonInstaller(),
                              new FourProducibleUnitsInstaller());

            container.Register(Component.For<IWorldAge>().ImplementedBy<DeceleratingWorldAge>(),
                               Component.For<IWinnerStrategy>().ImplementedBy<CityConquerorWins>());
        }
    }
}
