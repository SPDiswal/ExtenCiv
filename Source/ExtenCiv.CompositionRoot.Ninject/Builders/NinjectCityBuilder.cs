using System;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Workforce;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using Ninject;

namespace ExtenCiv.Composition.Ninject.Builders
{
    public class NinjectCityBuilder : ICityBuilder
    {
        private readonly IKernel kernel;

        private Type currentDecorator;

        public NinjectCityBuilder(IKernel kernel) { this.kernel = kernel; }

        public ICityBuilder WithNoCityGrowth<TCity>() where TCity : ICity<TCity>
        {
            var binding = kernel.Bind<ICity<TCity>>()
                                .To<NoCityGrowth<TCity>>();

            if (currentDecorator != null) binding.WhenInjectedInto(currentDecorator);

            currentDecorator = typeof (NoCityGrowth<TCity>);
            return this;
        }

        public ICityBuilder WithFixedGeneratedProduction<TCity>() where TCity : ICity<TCity>
        {
            var binding = kernel.Bind<ICity<TCity>>()
                                .To<FixedGeneratedProduction<TCity>>();

            if (currentDecorator != null) binding.WhenInjectedInto(currentDecorator);

            currentDecorator = typeof (FixedGeneratedProduction<TCity>);
            return this;
        }

        public ICityBuilder WithProductionAccumulation<TCity>() where TCity : ICity<TCity>
        {
            var binding = kernel.Bind<ICity<TCity>>()
                  .To<ProductionAccumulation<TCity>>();

            if (currentDecorator != null) binding.WhenInjectedInto(currentDecorator);

            currentDecorator = typeof (ProductionAccumulation<TCity>);
            return this;
        }

        public ICityBuilder WithFriendlyCityManagementOnly<TCity>() where TCity : ICity<TCity>
        {
            var binding = kernel.Bind<ICity<TCity>>()
                                .To<FriendlyCityManagementOnly<TCity>>();

            if (currentDecorator != null) binding.WhenInjectedInto(currentDecorator);

            currentDecorator = typeof (FriendlyCityManagementOnly<TCity>);
            return this;
        }
    }
}
