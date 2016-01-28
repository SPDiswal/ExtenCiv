using Autofac;
using ExtenCiv.Players;

namespace ExtenCiv.Composition.Autofac.Modules.Players
{
    public sealed class TwoPlayersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var players = new[] { new Player("Red"), new Player("Blue") };

            builder.Register(_ => players).As<Player[]>().SingleInstance();
            builder.RegisterType<RoundRobinTurns>().AsImplementedInterfaces().SingleInstance();
        }
    }
}
