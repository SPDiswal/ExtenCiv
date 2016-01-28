using ExtenCiv.Composition.Ninject.Modules.Players;
using ExtenCiv.Composition.Ninject.Modules.WorldMaps;
using ExtenCiv.Games;
using ExtenCiv.Games.Abstractions;
using ExtenCiv.Units.Combat;
using ExtenCiv.Units.Combat.Abstractions;
using Ninject;
using Ninject.Modules;

namespace ExtenCiv.Composition.Ninject.Modules
{
    public sealed class CommonModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Load<TwoPlayersModule>();

            Kernel.Load<CitiesModule>();
            Kernel.Load<TerrainsModule>();
            Kernel.Load<UnitsModule>();

            Bind<IUnitCombat>().To<AttackerIsAlwaysVictorious>().InSingletonScope();
            Bind<IGame>().To<ExtenCivGame>().InSingletonScope();
        }
    }
}
