using ExtenCiv.Composition.Unity.Extensions;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using ExtenCiv.CompositionRoot.Directors.Cities;
using ExtenCiv.CompositionRoot.Directors.Units;
using ExtenCiv.Games.Abstractions;
using Microsoft.Practices.Unity;

namespace ExtenCiv.Composition.Unity.Builders
{
    public sealed class UnitySemiCiv : IGameBuilder
    {
        public IGame BuildGame()
        {
            var container = new UnityContainer();

            new FixedCities().SetUpCities(() => new UnityCityBuilder(container));
            new FourUnitsWithActions().SetUpUnits(() => new UnityUnitBuilder(container));

            container.AddNewExtension<SemiCivExtension>();

            var game = container.Resolve<IGame>();
            game.ContainerName = "Unity/SemiCiv";

            return game;
        }
    }
}
