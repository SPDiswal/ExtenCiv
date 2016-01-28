using ExtenCiv.Players;
using ExtenCiv.Players.Abstractions;
using ExtenCiv.Players.Events;
using Microsoft.Practices.Unity;

namespace ExtenCiv.Composition.Unity.Extensions.Players
{
    public sealed class TwoPlayersExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            var players = new[] { new Player("Red"), new Player("Blue") };

            Container.RegisterType<RoundRobinTurns>(new ContainerControlledLifetimeManager(),
                new InjectionConstructor(new InjectionParameter<Player[]>(players)));
            Container.RegisterType<ITurnTaking, RoundRobinTurns>();
            Container.RegisterType<INotifyBeginningNextRound, RoundRobinTurns>();
        }
    }
}
