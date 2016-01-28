using Autofac;
using ExtenCiv.Composition.Autofac.Modules;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using ExtenCiv.CompositionRoot.Directors.Cities;
using ExtenCiv.CompositionRoot.Directors.Units;
using ExtenCiv.Games.Abstractions;

namespace ExtenCiv.Composition.Autofac.Builders
{
    public sealed class AutofacSemiCiv : IGameBuilder
    {
        public IGame BuildGame()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<SemiCivModule>();

            new FixedCities().SetUpCities(() => new AutofacCityBuilder(builder));
            new FourUnitsWithActions().SetUpUnits(() => new AutofacUnitBuilder(builder));

            var game = builder.Build().Resolve<IGame>();
            game.ContainerName = "Autofac/SemiCiv";

            return game;
        }
    }
}
