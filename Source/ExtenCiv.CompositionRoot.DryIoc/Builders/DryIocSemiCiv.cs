using DryIoc;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using ExtenCiv.CompositionRoot.Directors.Cities;
using ExtenCiv.CompositionRoot.Directors.Units;
using ExtenCiv.CompositionRoot.DryIoc.Packages;
using ExtenCiv.Games.Abstractions;

namespace ExtenCiv.CompositionRoot.DryIoc.Builders
{
    public sealed class DryIocSemiCiv : IGameBuilder
    {
        public IGame BuildGame()
        {
            var container = new Container();

            new SemiCivPackage().Load(container);

            new FixedCities().SetUpCities(() => new DryIocCityBuilder(container));
            new FourUnitsWithActions().SetUpUnits(() => new DryIocUnitBuilder(container));
            
            var game = container.Resolve<IGame>();
            game.ContainerName = "DryIoc/SemiCiv";

            return game;
        }
    }
}
