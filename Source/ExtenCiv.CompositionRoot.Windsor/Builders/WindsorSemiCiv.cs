using Castle.Facilities.TypedFactory;
using Castle.Windsor;
using ExtenCiv.Composition.Windsor.Installers;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using ExtenCiv.CompositionRoot.Directors.Cities;
using ExtenCiv.CompositionRoot.Directors.Units;
using ExtenCiv.Games.Abstractions;

namespace ExtenCiv.Composition.Windsor.Builders
{
    public sealed class WindsorSemiCiv : IGameBuilder
    {
        public IGame BuildGame()
        {
            var container = new WindsorContainer();
            container.AddFacility<TypedFactoryFacility>();

            new ReversedFixedCities().SetUpCities(() => new WindsorCityBuilder(container));
            new ReversedFourUnitsWithActions().SetUpUnits(() => new WindsorUnitBuilder(container));

            container.Install(new SemiCivInstaller());

            var game = container.Resolve<IGame>();
            game.ContainerName = "Windsor/SemiCiv";

            return game;
        }
    }
}
