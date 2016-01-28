using ExtenCiv.Composition.Unity.Extensions.Units;
using ExtenCiv.Winners;
using ExtenCiv.Winners.Abstractions;
using ExtenCiv.WorldAges;
using ExtenCiv.WorldAges.Abstractions;
using Microsoft.Practices.Unity;

namespace ExtenCiv.Composition.Unity.Extensions
{
    public class AlphaCivExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.AddNewExtension<CommonExtension>();
            Container.AddNewExtension<ThreeProducibleUnitsExtension>();

            Container.RegisterType<IWorldAge, LinearWorldAge>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IWinnerStrategy, RedWinsIn3000Bce>(new ContainerControlledLifetimeManager());
        }
    }
}
