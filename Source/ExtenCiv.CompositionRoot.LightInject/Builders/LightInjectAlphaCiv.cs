using ExtenCiv.Composition.LightInject.CompositionRoots;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using ExtenCiv.CompositionRoot.Directors.Cities;
using ExtenCiv.CompositionRoot.Directors.Units;
using ExtenCiv.Games.Abstractions;
using LightInject;

namespace ExtenCiv.Composition.LightInject.Builders
{
    public sealed class LightInjectAlphaCiv : IGameBuilder
    {
        public IGame BuildGame()
        {
            var container = new ServiceContainer();

            container.RegisterFrom<AlphaCivCompositionRoot>();

            new FixedCities().SetUpCities(() => new LightInjectCityBuilder(container));
            new ThreeUnitsWithoutActions().SetUpUnits(() => new LightInjectUnitBuilder(container));

            var game = container.GetInstance<IGame>();
            game.ContainerName = "LightInject/AlphaCiv";

            return game;
        }
    }
}
