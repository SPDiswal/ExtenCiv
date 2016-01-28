using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Workforce;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using LightInject;

namespace ExtenCiv.Composition.LightInject.Builders
{
    public class LightInjectCityBuilder : ICityBuilder
    {
        private readonly IServiceRegistry serviceRegistry;

        public LightInjectCityBuilder(IServiceRegistry serviceRegistry) { this.serviceRegistry = serviceRegistry; }

        public ICityBuilder WithNoCityGrowth<TCity>() where TCity : ICity<TCity>
        {
            serviceRegistry.Decorate(typeof (ICity<TCity>), typeof (NoCityGrowth<TCity>));
            return this;
        }

        public ICityBuilder WithFixedGeneratedProduction<TCity>() where TCity : ICity<TCity>
        {
            serviceRegistry.Decorate(typeof (ICity<TCity>), typeof (FixedGeneratedProduction<TCity>));
            return this;
        }

        public ICityBuilder WithProductionAccumulation<TCity>() where TCity : ICity<TCity>
        {
            serviceRegistry.Decorate(typeof (ICity<TCity>), typeof (ProductionAccumulation<TCity>));
            return this;
        }

        public ICityBuilder WithFriendlyCityManagementOnly<TCity>() where TCity : ICity<TCity>
        {
            serviceRegistry.Decorate(typeof (ICity<TCity>), typeof (FriendlyCityManagementOnly<TCity>));
            return this;
        }
    }
}
