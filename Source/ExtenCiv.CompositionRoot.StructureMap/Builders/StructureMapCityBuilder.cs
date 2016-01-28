using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Workforce;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using StructureMap;

namespace ExtenCiv.Composition.StructureMap.Builders
{
    public class StructureMapCityBuilder : ICityBuilder
    {
        private readonly IContainer container;

        public StructureMapCityBuilder(IContainer container) { this.container = container; }

        public ICityBuilder WithNoCityGrowth<TCity>() where TCity : ICity<TCity>
        {
            container.Configure(c => c.For(typeof (ICity<TCity>))
                                      .DecorateAllWith(typeof (NoCityGrowth<TCity>)));
            return this;
        }

        public ICityBuilder WithFixedGeneratedProduction<TCity>() where TCity : ICity<TCity>
        {
            container.Configure(c => c.For(typeof (ICity<TCity>))
                                      .DecorateAllWith(typeof (FixedGeneratedProduction<TCity>)));
            return this;
        }

        public ICityBuilder WithProductionAccumulation<TCity>() where TCity : ICity<TCity>
        {
            container.Configure(c => c.For(typeof (ICity<TCity>))
                                      .DecorateAllWith(typeof (ProductionAccumulation<TCity>)));
            return this;
        }

        public ICityBuilder WithFriendlyCityManagementOnly<TCity>() where TCity : ICity<TCity>
        {
            container.Configure(c => c.For(typeof (ICity<TCity>))
                                      .DecorateAllWith(typeof (FriendlyCityManagementOnly<TCity>)));
            return this;
        }
    }
}
