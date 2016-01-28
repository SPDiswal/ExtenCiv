using System.Collections.Generic;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Workforce;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using ExtenCiv.Players.Abstractions;
using ExtenCiv.Players.Events;
using ExtenCiv.Units.Abstractions;
using Microsoft.Practices.Unity;

namespace ExtenCiv.Composition.Unity.Builders
{
    public class UnityCityBuilder : ICityBuilder
    {
        private readonly IUnityContainer container;

        private string fromKey;
        private string toKey;

        public UnityCityBuilder(IUnityContainer container) { this.container = container; }

        public ICityBuilder WithNoCityGrowth<TCity>() where TCity : ICity<TCity>
        {
            fromKey = fromKey ?? typeof (TCity).Name;
            toKey = $"{fromKey}_WithNoCityGrowth";

            container.RegisterType(typeof (ICity<TCity>), typeof (NoCityGrowth<TCity>),
                                   toKey, new InjectionConstructor(new ResolvedParameter<ICity<TCity>>(fromKey)));

            fromKey = toKey;
            return this;
        }

        public ICityBuilder WithFixedGeneratedProduction<TCity>() where TCity : ICity<TCity>
        {
            fromKey = fromKey ?? typeof (TCity).Name;
            toKey = $"{fromKey}_WithFixedGeneratedProduction";

            container.RegisterType(typeof (ICity<TCity>), typeof (FixedGeneratedProduction<TCity>),
                                   toKey,
                                   new InjectionConstructor(new ResolvedParameter<ICity<TCity>>(fromKey)));

            fromKey = toKey;
            return this;
        }

        public ICityBuilder WithProductionAccumulation<TCity>() where TCity : ICity<TCity>
        {
            fromKey = fromKey ?? typeof (TCity).Name;
            toKey = $"{fromKey}_WithProductionAccumulation";

            container.RegisterType(typeof (ICity<TCity>), typeof (ProductionAccumulation<TCity>),
                                   toKey,
                                   new InjectionConstructor(new ResolvedParameter<ICity<TCity>>(fromKey),
                                                            new ResolvedParameter<ISet<IUnit>>(),
                                                            new ResolvedParameter<INotifyBeginningNextRound>()));

            fromKey = toKey;
            return this;
        }

        public ICityBuilder WithFriendlyCityManagementOnly<TCity>() where TCity : ICity<TCity>
        {
            fromKey = fromKey ?? typeof (TCity).Name;
            toKey = $"{fromKey}_WithFriendlyCityManagementOnly";

            container.RegisterType(typeof (ICity<TCity>), typeof (FriendlyCityManagementOnly<TCity>),
                                   toKey,
                                   new InjectionConstructor(new ResolvedParameter<ICity<TCity>>(fromKey),
                                                            new ResolvedParameter<ITurnTaking>()));

            // Using a local variable, the value of toKey is preserved in the closure.
            var preservedToKey = toKey;

            container.RegisterType<ICity<TCity>>(new InjectionFactory(c => c.Resolve<ICity<TCity>>(preservedToKey)));

            fromKey = toKey;
            return this;
        }
    }
}
