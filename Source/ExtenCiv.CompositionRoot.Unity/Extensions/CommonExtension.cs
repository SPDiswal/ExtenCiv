using ExtenCiv.Composition.Unity.Extensions.Players;
using ExtenCiv.Composition.Unity.Extensions.WorldMaps;
using ExtenCiv.Games;
using ExtenCiv.Games.Abstractions;
using ExtenCiv.Units.Combat;
using ExtenCiv.Units.Combat.Abstractions;
using Microsoft.Practices.Unity;

namespace ExtenCiv.Composition.Unity.Extensions
{
    public sealed class CommonExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.AddNewExtension<TwoPlayersExtension>();

            Container.AddNewExtension<CitiesExtension>();
            Container.AddNewExtension<TerrainsExtension>();
            Container.AddNewExtension<UnitsExtension>();

            Container.RegisterType<IUnitCombat, AttackerIsAlwaysVictorious>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IGame, ExtenCivGame>(new ContainerControlledLifetimeManager());
        }
    }
}
