using System.Collections.Generic;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Types;
using ExtenCiv.Cities.Types.Factories.Abstractions;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using ExtenCiv.Players.Abstractions;
using ExtenCiv.Players.Events;
using ExtenCiv.Terrains.Abstractions;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Actions;
using ExtenCiv.Units.Combat.Abstractions;
using ExtenCiv.Units.Movement;
using Microsoft.Practices.Unity;

namespace ExtenCiv.Composition.Unity.Builders
{
    public class UnityUnitBuilder : IUnitBuilder
    {
        private readonly IUnityContainer container;

        private string fromKey;
        private string toKey;

        public UnityUnitBuilder(IUnityContainer container) { this.container = container; }

        public IUnitBuilder WithMovability<TUnit>() where TUnit : IUnit<TUnit>
        {
            fromKey = fromKey ?? typeof (TUnit).Name;
            toKey = $"{fromKey}_WithMovability";

            container.RegisterType(typeof (IUnit<TUnit>), typeof (Movability<TUnit>),
                                   toKey,
                                   new InjectionConstructor(new ResolvedParameter<IUnit<TUnit>>(fromKey)));

            fromKey = toKey;
            return this;
        }

        public IUnitBuilder WithMoveCosts<TUnit>() where TUnit : IUnit<TUnit>
        {
            fromKey = fromKey ?? typeof (TUnit).Name;
            toKey = $"{fromKey}_WithMoveCosts";

            container.RegisterType(typeof (IUnit<TUnit>), typeof (MoveCosts<TUnit>),
                                   toKey,
                                   new InjectionConstructor(new ResolvedParameter<IUnit<TUnit>>(fromKey)));

            fromKey = toKey;
            return this;
        }

        public IUnitBuilder WithRestorationOfMoves<TUnit>() where TUnit : IUnit<TUnit>
        {
            fromKey = fromKey ?? typeof (TUnit).Name;
            toKey = $"{fromKey}_WithRestorationOfMoves";

            container.RegisterType(typeof (IUnit<TUnit>), typeof (RestorationOfMoves<TUnit>),
                                   toKey,
                                   new InjectionConstructor(new ResolvedParameter<IUnit<TUnit>>(fromKey),
                                                            new ResolvedParameter<INotifyBeginningNextRound>()));

            fromKey = toKey;
            return this;
        }

        public IUnitBuilder WithCityConquest<TUnit>() where TUnit : IUnit<TUnit>
        {
            fromKey = fromKey ?? typeof (TUnit).Name;
            toKey = $"{fromKey}_WithCityConquest";

            container.RegisterType(typeof (IUnit<TUnit>), typeof (CityConquest<TUnit>),
                                   toKey,
                                   new InjectionConstructor(new ResolvedParameter<IUnit<TUnit>>(fromKey),
                                                            new ResolvedParameter<ISet<ICity>>()));

            fromKey = toKey;
            return this;
        }

        public IUnitBuilder WithOneToOneCombatEngagement<TUnit>() where TUnit : IUnit<TUnit>
        {
            fromKey = fromKey ?? typeof (TUnit).Name;
            toKey = $"{fromKey}_WithOneToOneCombatEngagement";

            container.RegisterType(typeof (IUnit<TUnit>), typeof (OneToOneCombatEngagement<TUnit>),
                                   toKey,
                                   new InjectionConstructor(new ResolvedParameter<IUnit<TUnit>>(fromKey),
                                                            new ResolvedParameter<ISet<IUnit>>(),
                                                            new ResolvedParameter<IUnitCombat>()));

            fromKey = toKey;
            return this;
        }

        public IUnitBuilder WithLimitedMoveRange<TUnit>() where TUnit : IUnit<TUnit>
        {
            fromKey = fromKey ?? typeof (TUnit).Name;
            toKey = $"{fromKey}_WithLimitedMoveRange";

            container.RegisterType(typeof (IUnit<TUnit>), typeof (LimitedMoveRange<TUnit>),
                                   toKey,
                                   new InjectionConstructor(new ResolvedParameter<IUnit<TUnit>>(fromKey)));

            fromKey = toKey;
            return this;
        }

        public IUnitBuilder WithNoFriendlyUnitStacking<TUnit>() where TUnit : IUnit<TUnit>
        {
            fromKey = fromKey ?? typeof (TUnit).Name;
            toKey = $"{fromKey}_WithNoFriendlyUnitStacking";

            container.RegisterType(typeof (IUnit<TUnit>), typeof (NoFriendlyUnitStacking<TUnit>),
                                   toKey,
                                   new InjectionConstructor(new ResolvedParameter<IUnit<TUnit>>(fromKey),
                                                            new ResolvedParameter<ISet<IUnit>>()));

            fromKey = toKey;
            return this;
        }

        public IUnitBuilder WithNoEntranceToImpassableTerrain<TUnit>() where TUnit : IUnit<TUnit>
        {
            fromKey = fromKey ?? typeof (TUnit).Name;
            toKey = $"{fromKey}_WithNoEntranceToImpassableTerrain";

            container.RegisterType(typeof (IUnit<TUnit>), typeof (NoEntranceToImpassableTerrain<TUnit>),
                                   toKey,
                                   new InjectionConstructor(new ResolvedParameter<IUnit<TUnit>>(fromKey),
                                                            new ResolvedParameter<ISet<ITerrain>>()));

            fromKey = toKey;
            return this;
        }

        public IUnitBuilder WithFortificationAction<TUnit>() where TUnit : IUnit<TUnit>
        {
            fromKey = fromKey ?? typeof (TUnit).Name;
            toKey = $"{fromKey}_WithFortificationAction";

            container.RegisterType(typeof (IUnit<TUnit>), typeof (FortificationAction<TUnit>),
                                   toKey,
                                   new InjectionConstructor(new ResolvedParameter<IUnit<TUnit>>(fromKey)));

            fromKey = toKey;
            return this;
        }

        public IUnitBuilder WithCityBuildingAction<TUnit>() where TUnit : IUnit<TUnit>
        {
            fromKey = fromKey ?? typeof (TUnit).Name;
            toKey = $"{fromKey}_WithCityBuildingAction";

            container.RegisterType(typeof (IUnit<TUnit>), typeof (CityBuildingAction<TUnit>),
                                   toKey,
                                   new InjectionConstructor(new ResolvedParameter<IUnit<TUnit>>(fromKey),
                                                            new ResolvedParameter<ISet<IUnit>>(),
                                                            new ResolvedParameter<ISet<ICity>>(),
                                                            new ResolvedParameter<ICityFactory<City>>()));

            fromKey = toKey;
            return this;
        }

        public IUnitBuilder WithFriendlyUnitManagementOnly<TUnit>() where TUnit : IUnit<TUnit>
        {
            fromKey = fromKey ?? typeof (TUnit).Name;
            toKey = $"{fromKey}_WithFriendlyUnitManagementOnly";

            container.RegisterType(typeof (IUnit<TUnit>), typeof (FriendlyUnitManagementOnly<TUnit>),
                                   toKey,
                                   new InjectionConstructor(new ResolvedParameter<IUnit<TUnit>>(fromKey),
                                                            new ResolvedParameter<ITurnTaking>()));

            // Using a local variable, the value of toKey is preserved in the closure.
            var preservedToKey = toKey;

            container.RegisterType<IUnit<TUnit>>(new InjectionFactory(c => c.Resolve<IUnit<TUnit>>(preservedToKey)));

            fromKey = toKey;
            return this;
        }
    }
}
