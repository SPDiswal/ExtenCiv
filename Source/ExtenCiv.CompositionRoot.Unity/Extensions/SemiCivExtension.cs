using ExtenCiv.Composition.Unity.Extensions.Units;
using ExtenCiv.Winners;
using ExtenCiv.Winners.Abstractions;
using ExtenCiv.WorldAges;
using ExtenCiv.WorldAges.Abstractions;
using Microsoft.Practices.Unity;

namespace ExtenCiv.Composition.Unity.Extensions
{
    public sealed class SemiCivExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.AddNewExtension<CommonExtension>();
            Container.AddNewExtension<FourProducibleUnitsExtension>();

            Container.RegisterType<IWorldAge, DeceleratingWorldAge>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IWinnerStrategy, CityConquerorWins>(new ContainerControlledLifetimeManager());
        }
    }
}
