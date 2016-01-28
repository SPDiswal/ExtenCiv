using ExtenCiv.Composition.Ninject.Modules;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using ExtenCiv.CompositionRoot.Directors.Cities;
using ExtenCiv.CompositionRoot.Directors.Units;
using ExtenCiv.Games.Abstractions;
using Ninject;

namespace ExtenCiv.Composition.Ninject.Builders
{
    public sealed class NinjectSemiCiv : IGameBuilder
    {
        public IGame BuildGame()
        {
            var kernel = new StandardKernel();

            kernel.Load<SemiCivModule>();

            new ReversedFixedCities().SetUpCities(() => new NinjectCityBuilder(kernel));
            new ReversedFourUnitsWithActions().SetUpUnits(() => new NinjectUnitBuilder(kernel));

            var game = kernel.Get<IGame>();
            game.ContainerName = "Ninject/SemiCiv";

            return game;
        }
    }
}
