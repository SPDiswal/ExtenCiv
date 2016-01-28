using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ExtenCiv.Players;
using ExtenCiv.Players.Abstractions;
using ExtenCiv.Players.Events;

namespace ExtenCiv.Composition.Windsor.Installers.Players
{
    public sealed class TwoPlayersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var players = new[] { new Player("Red"), new Player("Blue") };

            container.Register(Component.For<Player[]>().UsingFactoryMethod(() => players));
            container.Register(Component.For<ITurnTaking, INotifyBeginningNextRound>().ImplementedBy<RoundRobinTurns>());
        }
    }
}
