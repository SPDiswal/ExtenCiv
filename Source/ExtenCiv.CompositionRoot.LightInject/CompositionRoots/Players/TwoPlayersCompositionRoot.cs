using ExtenCiv.Players;
using ExtenCiv.Players.Abstractions;
using ExtenCiv.Players.Events;
using LightInject;

namespace ExtenCiv.Composition.LightInject.CompositionRoots.Players
{
    public sealed class TwoPlayersCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            var players = new[] { new Player("Red"), new Player("Blue") };
            serviceRegistry.Register(_ => players, new PerContainerLifetime());

            serviceRegistry.Register<RoundRobinTurns>(new PerContainerLifetime());
            serviceRegistry.Register<ITurnTaking>(c => c.GetInstance<RoundRobinTurns>());
            serviceRegistry.Register<INotifyBeginningNextRound>(c => c.GetInstance<RoundRobinTurns>());
        }
    }
}
