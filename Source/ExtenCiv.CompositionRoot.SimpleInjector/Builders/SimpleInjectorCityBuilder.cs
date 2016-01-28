using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Workforce;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using SimpleInjector;

namespace ExtenCiv.Composition.SimpleInjector.Builders
{
    public class SimpleInjectorCityBuilder : ICityBuilder
    {
        private readonly Container container;

        public SimpleInjectorCityBuilder(Container container) { this.container = container; }

        public ICityBuilder WithNoCityGrowth<TCity>() where TCity : ICity<TCity>
        {
            container.RegisterDecorator(typeof (ICity<TCity>), typeof (NoCityGrowth<TCity>));
            return this;
        }

        public ICityBuilder WithFixedGeneratedProduction<TCity>() where TCity : ICity<TCity>
        {
            container.RegisterDecorator(typeof (ICity<TCity>), typeof (FixedGeneratedProduction<TCity>));
            return this;
        }

        public ICityBuilder WithProductionAccumulation<TCity>() where TCity : ICity<TCity>
        {
            container.RegisterDecorator(typeof (ICity<TCity>), typeof (ProductionAccumulation<TCity>));
            return this;
        }

        public ICityBuilder WithFriendlyCityManagementOnly<TCity>() where TCity : ICity<TCity>
        {
            container.RegisterDecorator(typeof (ICity<TCity>), typeof (FriendlyCityManagementOnly<TCity>));
            return this;
        }
    }
}
