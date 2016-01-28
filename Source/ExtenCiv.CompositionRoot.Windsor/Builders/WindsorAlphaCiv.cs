using Castle.Windsor;
using Castle.Facilities.TypedFactory;
using ExtenCiv.Composition.Windsor.Installers;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using ExtenCiv.CompositionRoot.Directors.Cities;
using ExtenCiv.CompositionRoot.Directors.Units;
using ExtenCiv.Games.Abstractions;

namespace ExtenCiv.Composition.Windsor.Builders
{
    public sealed class WindsorAlphaCiv : IGameBuilder
    {
        public IGame BuildGame()
        {
            var container = new WindsorContainer();
            container.AddFacility<TypedFactoryFacility>();

            new ReversedFixedCities().SetUpCities(() => new WindsorCityBuilder(container));
            new ReversedThreeUnitsWithoutActions().SetUpUnits(() => new WindsorUnitBuilder(container));

            container.Install(new AlphaCivInstaller());

            var game = container.Resolve<IGame>();
            game.ContainerName = "Windsor/AlphaCiv";

            return game;
        }
    }
}
