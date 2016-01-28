using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ExtenCiv.Composition.Windsor.Installers.Players;
using ExtenCiv.Composition.Windsor.Installers.WorldMaps;
using ExtenCiv.Games;
using ExtenCiv.Games.Abstractions;
using ExtenCiv.Units.Combat;
using ExtenCiv.Units.Combat.Abstractions;

namespace ExtenCiv.Composition.Windsor.Installers
{
    public sealed class CommonInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Install(new TwoPlayersInstaller(),
                              new CitiesInstaller(),
                              new TerrainsInstaller(),
                              new UnitsInstaller());

            container.Register(Component.For<IUnitCombat>().ImplementedBy<AttackerIsAlwaysVictorious>(),
                               Component.For<IGame>().ImplementedBy<ExtenCivGame>());
        }
    }
}
