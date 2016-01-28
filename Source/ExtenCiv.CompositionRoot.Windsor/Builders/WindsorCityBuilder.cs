using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Workforce;
using ExtenCiv.CompositionRoot.Builders.Abstractions;

namespace ExtenCiv.Composition.Windsor.Builders
{
    public class WindsorCityBuilder : ICityBuilder
    {
        private readonly IWindsorContainer container;

        public WindsorCityBuilder(IWindsorContainer container) { this.container = container; }

        public ICityBuilder WithNoCityGrowth<TCity>() where TCity : ICity<TCity>
        {
            container.Register(Component.For<ICity<TCity>>()
                                        .ImplementedBy<NoCityGrowth<TCity>>()
                                        .LifestyleTransient());
            return this;
        }

        public ICityBuilder WithFixedGeneratedProduction<TCity>() where TCity : ICity<TCity>
        {
            container.Register(Component.For<ICity<TCity>>()
                                        .ImplementedBy<FixedGeneratedProduction<TCity>>()
                                        .LifestyleTransient());
            return this;
        }

        public ICityBuilder WithProductionAccumulation<TCity>() where TCity : ICity<TCity>
        {
            container.Register(Component.For<ICity<TCity>>()
                                        .ImplementedBy<ProductionAccumulation<TCity>>()
                                        .LifestyleTransient());
            return this;
        }

        public ICityBuilder WithFriendlyCityManagementOnly<TCity>() where TCity : ICity<TCity>
        {
            container.Register(Component.For<ICity<TCity>>()
                                        .ImplementedBy<FriendlyCityManagementOnly<TCity>>()
                                        .LifestyleTransient());
            return this;
        }
    }
}
