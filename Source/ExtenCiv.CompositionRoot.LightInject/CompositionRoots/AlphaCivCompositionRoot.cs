using ExtenCiv.Composition.LightInject.CompositionRoots.Units;
using ExtenCiv.Winners;
using ExtenCiv.Winners.Abstractions;
using ExtenCiv.WorldAges;
using ExtenCiv.WorldAges.Abstractions;
using LightInject;

namespace ExtenCiv.Composition.LightInject.CompositionRoots
{
    public sealed class AlphaCivCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.RegisterFrom<CommonCompositionRoot>();
            serviceRegistry.RegisterFrom<ThreeProducibleUnitsCompositionRoot>();

            serviceRegistry.Register<IWorldAge, LinearWorldAge>(new PerContainerLifetime());
            serviceRegistry.Register<IWinnerStrategy, RedWinsIn3000Bce>(new PerContainerLifetime());
        }
    }
}
