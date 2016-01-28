using ExtenCiv.Composition.LightInject.CompositionRoots.Players;
using ExtenCiv.Composition.LightInject.CompositionRoots.WorldMaps;
using ExtenCiv.Games;
using ExtenCiv.Games.Abstractions;
using ExtenCiv.Units.Combat;
using ExtenCiv.Units.Combat.Abstractions;
using LightInject;

namespace ExtenCiv.Composition.LightInject.CompositionRoots
{
    public sealed class CommonCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.RegisterFrom<TwoPlayersCompositionRoot>();

            serviceRegistry.RegisterFrom<CitiesCompositionRoot>();
            serviceRegistry.RegisterFrom<TerrainsCompositionRoot>();
            serviceRegistry.RegisterFrom<UnitsCompositionRoot>();

            serviceRegistry.Register<IUnitCombat, AttackerIsAlwaysVictorious>(new PerContainerLifetime());
            serviceRegistry.Register<IGame, ExtenCivGame>(new PerContainerLifetime());
        }
    }
}
