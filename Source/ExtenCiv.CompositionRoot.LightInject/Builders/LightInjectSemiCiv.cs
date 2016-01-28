using ExtenCiv.Composition.LightInject.CompositionRoots;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using ExtenCiv.CompositionRoot.Directors.Cities;
using ExtenCiv.CompositionRoot.Directors.Units;
using ExtenCiv.Games.Abstractions;
using LightInject;

namespace ExtenCiv.Composition.LightInject.Builders
{
    public sealed class LightInjectSemiCiv : IGameBuilder
    {
        public IGame BuildGame()
        {
            var container = new ServiceContainer();

            container.RegisterFrom<SemiCivCompositionRoot>();

            new FixedCities().SetUpCities(() => new LightInjectCityBuilder(container));
            new FourUnitsWithActions().SetUpUnits(() => new LightInjectUnitBuilder(container));

            var game = container.GetInstance<IGame>();
            game.ContainerName = "LightInject/SemiCiv";

            return game;
        }
    }
}
