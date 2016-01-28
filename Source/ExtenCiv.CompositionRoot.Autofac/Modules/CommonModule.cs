using Autofac;
using ExtenCiv.Composition.Autofac.Modules.Players;
using ExtenCiv.Composition.Autofac.Modules.WorldMaps;
using ExtenCiv.Games;
using ExtenCiv.Games.Abstractions;
using ExtenCiv.Units.Combat;
using ExtenCiv.Units.Combat.Abstractions;

namespace ExtenCiv.Composition.Autofac.Modules
{
    public sealed class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<TwoPlayersModule>();

            builder.RegisterModule<CitiesModule>();
            builder.RegisterModule<TerrainsModule>();
            builder.RegisterModule<UnitsModule>();

            builder.RegisterType<AttackerIsAlwaysVictorious>().As<IUnitCombat>().SingleInstance();
            builder.RegisterType<ExtenCivGame>().As<IGame>().SingleInstance();
        }
    }
}
