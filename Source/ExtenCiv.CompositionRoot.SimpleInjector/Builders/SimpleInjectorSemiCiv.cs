using ExtenCiv.Composition.SimpleInjector.Extensions;
using ExtenCiv.Composition.SimpleInjector.Packages;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using ExtenCiv.CompositionRoot.Directors.Cities;
using ExtenCiv.CompositionRoot.Directors.Units;
using ExtenCiv.Games.Abstractions;
using SimpleInjector;

namespace ExtenCiv.Composition.SimpleInjector.Builders
{
    public sealed class SimpleInjectorSemiCiv : IGameBuilder
    {
        public IGame BuildGame()
        {
            var container = new Container();
            container.Options.AllowResolvingFuncFactories();

            new SemiCivPackage().RegisterServices(container);

            new FixedCities().SetUpCities(() => new SimpleInjectorCityBuilder(container));
            new FourUnitsWithActions().SetUpUnits(() => new SimpleInjectorUnitBuilder(container));

            var game = container.GetInstance<IGame>();
            game.ContainerName = "SimpleInjector/SemiCiv";

            return game;
        }
    }
}
