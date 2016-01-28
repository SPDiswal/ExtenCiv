using ExtenCiv.Players;
using ExtenCiv.Players.Abstractions;
using ExtenCiv.Players.Events;
using Ninject.Modules;

namespace ExtenCiv.Composition.Ninject.Modules.Players
{
    public sealed class TwoPlayersModule : NinjectModule
    {
        public override void Load()
        {
            var players = new[] { new Player("Red"), new Player("Blue") };

            Bind<ITurnTaking, INotifyBeginningNextRound>().To<RoundRobinTurns>()
                                                          .InSingletonScope()
                                                          .WithConstructorArgument(typeof (Player[]), players);
        }
    }
}
