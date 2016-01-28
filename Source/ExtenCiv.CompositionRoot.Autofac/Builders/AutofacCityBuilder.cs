using System.Collections.Generic;
using Autofac;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Workforce;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using ExtenCiv.Players.Abstractions;
using ExtenCiv.Players.Events;
using ExtenCiv.Units.Abstractions;

namespace ExtenCiv.Composition.Autofac.Builders
{
    public sealed class AutofacCityBuilder : ICityBuilder
    {
        private readonly ContainerBuilder builder;

        private string fromKey;
        private string toKey;

        public AutofacCityBuilder(ContainerBuilder builder) { this.builder = builder; }

        public ICityBuilder WithNoCityGrowth<TCity>() where TCity : ICity<TCity>
        {
            fromKey = fromKey ?? typeof (TCity).Name;
            toKey = $"{fromKey}_WithNoCityGrowth";

            // Using a local variable, the value of fromKey is preserved in the closure.
            var preservedFromKey = fromKey;

            builder.Register(
                c => new NoCityGrowth<TCity>(c.ResolveNamed<ICity<TCity>>(preservedFromKey)))
                   .Named<ICity<TCity>>(toKey)
                   .As<ICity<TCity>>();

            fromKey = toKey;
            return this;
        }

        public ICityBuilder WithFixedGeneratedProduction<TCity>() where TCity : ICity<TCity>
        {
            fromKey = fromKey ?? typeof (TCity).Name;
            toKey = $"{fromKey}_WithFixedGeneratedProduction";

            // Using a local variable, the value of fromKey is preserved in the closure.
            var preservedFromKey = fromKey;

            builder.Register(
                c => new FixedGeneratedProduction<TCity>(c.ResolveNamed<ICity<TCity>>(preservedFromKey)))
                   .Named<ICity<TCity>>(toKey)
                   .As<ICity<TCity>>();

            fromKey = toKey;
            return this;
        }

        public ICityBuilder WithProductionAccumulation<TCity>() where TCity : ICity<TCity>
        {
            fromKey = fromKey ?? typeof (TCity).Name;
            toKey = $"{fromKey}_WithProductionAccumulation";

            // Using a local variable, the value of fromKey is preserved in the closure.
            var preservedFromKey = fromKey;

            builder.Register(
                c => new ProductionAccumulation<TCity>(c.ResolveNamed<ICity<TCity>>(preservedFromKey),
                                                       c.Resolve<ISet<IUnit>>(),
                                                       c.Resolve<INotifyBeginningNextRound>()))
                   .Named<ICity<TCity>>(toKey)
                   .As<ICity<TCity>>();

            fromKey = toKey;
            return this;
        }

        public ICityBuilder WithFriendlyCityManagementOnly<TCity>() where TCity : ICity<TCity>
        {
            fromKey = fromKey ?? typeof (TCity).Name;
            toKey = $"{fromKey}_WithFriendlyCityManagementOnly";

            // Using a local variable, the value of fromKey is preserved in the closure.
            var preservedFromKey = fromKey;

            builder.Register(
                c => new FriendlyCityManagementOnly<TCity>(c.ResolveNamed<ICity<TCity>>(preservedFromKey),
                                                           c.Resolve<ITurnTaking>()))
                   .Named<ICity<TCity>>(toKey)
                   .As<ICity<TCity>>();

            fromKey = toKey;
            return this;
        }
    }
}
