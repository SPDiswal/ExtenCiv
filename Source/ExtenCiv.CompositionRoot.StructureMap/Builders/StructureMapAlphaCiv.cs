using ExtenCiv.Composition.StructureMap.Registries;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using ExtenCiv.CompositionRoot.Directors.Cities;
using ExtenCiv.CompositionRoot.Directors.Units;
using ExtenCiv.Games.Abstractions;
using StructureMap;

namespace ExtenCiv.Composition.StructureMap.Builders
{
    public sealed class StructureMapAlphaCiv : IGameBuilder
    {
        public IGame BuildGame()
        {
            var container = new Container();

            new FixedCities().SetUpCities(() => new StructureMapCityBuilder(container));
            new ThreeUnitsWithoutActions().SetUpUnits(() => new StructureMapUnitBuilder(container));

            container.Configure(c => c.AddRegistry<AlphaCivRegistry>());

            var game = container.GetInstance<IGame>();
            game.ContainerName = "StructureMap/AlphaCiv";

            return game;
        }
    }
}
