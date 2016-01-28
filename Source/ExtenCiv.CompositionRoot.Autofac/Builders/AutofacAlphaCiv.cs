using Autofac;
using ExtenCiv.Composition.Autofac.Modules;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using ExtenCiv.CompositionRoot.Directors.Cities;
using ExtenCiv.CompositionRoot.Directors.Units;
using ExtenCiv.Games.Abstractions;

namespace ExtenCiv.Composition.Autofac.Builders
{
    public sealed class AutofacAlphaCiv : IGameBuilder
    {
        public IGame BuildGame()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<AlphaCivModule>();

            new FixedCities().SetUpCities(() => new AutofacCityBuilder(builder));
            new ThreeUnitsWithoutActions().SetUpUnits(() => new AutofacUnitBuilder(builder));

            var game = builder.Build().Resolve<IGame>();
            game.ContainerName = "Autofac/AlphaCiv";

            return game;
        }
    }
}
