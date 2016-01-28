using DryIoc;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Workforce;
using ExtenCiv.CompositionRoot.Builders.Abstractions;

namespace ExtenCiv.CompositionRoot.DryIoc.Builders
{
    public class DryIocCityBuilder : ICityBuilder
    {
        private readonly IRegistrator builder;

        public DryIocCityBuilder(IRegistrator builder) { this.builder = builder; }

        public ICityBuilder WithNoCityGrowth<TCity>() where TCity : ICity<TCity>
        {
            builder.Register<ICity<TCity>, NoCityGrowth<TCity>>(setup: Setup.Decorator);
            return this;
        }

        public ICityBuilder WithFixedGeneratedProduction<TCity>() where TCity : ICity<TCity>
        {
            builder.Register<ICity<TCity>, FixedGeneratedProduction<TCity>>(setup: Setup.Decorator);
            return this;
        }

        public ICityBuilder WithProductionAccumulation<TCity>() where TCity : ICity<TCity>
        {
            builder.Register<ICity<TCity>, ProductionAccumulation<TCity>>(setup: Setup.Decorator);
            return this;
        }

        public ICityBuilder WithFriendlyCityManagementOnly<TCity>() where TCity : ICity<TCity>
        {
            builder.Register<ICity<TCity>, FriendlyCityManagementOnly<TCity>>(setup: Setup.Decorator);
            return this;
        }
    }
}
