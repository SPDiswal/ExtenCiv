using ExtenCiv.Composition.LightInject.CompositionRoots.Units;
using ExtenCiv.Winners;
using ExtenCiv.Winners.Abstractions;
using ExtenCiv.WorldAges;
using ExtenCiv.WorldAges.Abstractions;
using LightInject;

namespace ExtenCiv.Composition.LightInject.CompositionRoots
{
    public sealed class SemiCivCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.RegisterFrom<CommonCompositionRoot>();
            serviceRegistry.RegisterFrom<FourProducibleUnitsCompositionRoot>();

            serviceRegistry.Register<IWorldAge, DeceleratingWorldAge>(new PerContainerLifetime());
            serviceRegistry.Register<IWinnerStrategy, CityConquerorWins>(new PerContainerLifetime());
        }
    }
}
