using System.Collections.Generic;
using Autofac;
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

namespace ExtenCiv.Composition.Autofac.Builders
{
    public sealed class AutofacUnitBuilder : IUnitBuilder
    {
        private readonly ContainerBuilder builder;

        private string fromKey;
        private string toKey;

        public AutofacUnitBuilder(ContainerBuilder builder) { this.builder = builder; }

        public IUnitBuilder WithMovability<TUnit>() where TUnit : IUnit<TUnit>
        {
            fromKey = fromKey ?? typeof (TUnit).Name;
            toKey = $"{fromKey}_WithMovability";

            // Using a local variable, the value of fromKey is preserved in the closure.
            var preservedFromKey = fromKey;

            builder.Register(
                c => new Movability<TUnit>(c.ResolveNamed<IUnit<TUnit>>(preservedFromKey)))
                   .Named<IUnit<TUnit>>(toKey)
                   .As<IUnit<TUnit>>();

            fromKey = toKey;
            return this;
        }

        public IUnitBuilder WithMoveCosts<TUnit>() where TUnit : IUnit<TUnit>
        {
            fromKey = fromKey ?? typeof (TUnit).Name;
            toKey = $"{fromKey}_WithMoveCosts";

            // Using a local variable, the value of fromKey is preserved in the closure.
            var preservedFromKey = fromKey;

            builder.Register(
                c => new MoveCosts<TUnit>(c.ResolveNamed<IUnit<TUnit>>(preservedFromKey)))
                   .Named<IUnit<TUnit>>(toKey)
                   .As<IUnit<TUnit>>();

            fromKey = toKey;
            return this;
        }

        public IUnitBuilder WithRestorationOfMoves<TUnit>() where TUnit : IUnit<TUnit>
        {
            fromKey = fromKey ?? typeof (TUnit).Name;
            toKey = $"{fromKey}_WithRestorationOfMoves";

            // Using a local variable, the value of fromKey is preserved in the closure.
            var preservedFromKey = fromKey;

            builder.Register(
                c => new RestorationOfMoves<TUnit>(c.ResolveNamed<IUnit<TUnit>>(preservedFromKey),
                                                   c.Resolve<INotifyBeginningNextRound>()))
                   .Named<IUnit<TUnit>>(toKey)
                   .As<IUnit<TUnit>>();

            fromKey = toKey;
            return this;
        }

        public IUnitBuilder WithCityConquest<TUnit>() where TUnit : IUnit<TUnit>
        {
            fromKey = fromKey ?? typeof (TUnit).Name;
            toKey = $"{fromKey}_WithCityConquest";

            // Using a local variable, the value of fromKey is preserved in the closure.
            var preservedFromKey = fromKey;

            builder.Register(
                c => new CityConquest<TUnit>(c.ResolveNamed<IUnit<TUnit>>(preservedFromKey),
                                             c.Resolve<ISet<ICity>>()))
                   .Named<IUnit<TUnit>>(toKey)
                   .As<IUnit<TUnit>>();

            fromKey = toKey;
            return this;
        }

        public IUnitBuilder WithOneToOneCombatEngagement<TUnit>() where TUnit : IUnit<TUnit>
        {
            fromKey = fromKey ?? typeof (TUnit).Name;
            toKey = $"{fromKey}_WithOneToOneCombatEngagement";

            // Using a local variable, the value of fromKey is preserved in the closure.
            var preservedFromKey = fromKey;

            builder.Register(
                c => new OneToOneCombatEngagement<TUnit>(c.ResolveNamed<IUnit<TUnit>>(preservedFromKey),
                                                         c.Resolve<ISet<IUnit>>(),
                                                         c.Resolve<IUnitCombat>()))
                   .Named<IUnit<TUnit>>(toKey)
                   .As<IUnit<TUnit>>();

            fromKey = toKey;
            return this;
        }

        public IUnitBuilder WithLimitedMoveRange<TUnit>() where TUnit : IUnit<TUnit>
        {
            fromKey = fromKey ?? typeof (TUnit).Name;
            toKey = $"{fromKey}_WithLimitedMoveRange";

            // Using a local variable, the value of fromKey is preserved in the closure.
            var preservedFromKey = fromKey;

            builder.Register(
                c => new LimitedMoveRange<TUnit>(c.ResolveNamed<IUnit<TUnit>>(preservedFromKey)))
                   .Named<IUnit<TUnit>>(toKey)
                   .As<IUnit<TUnit>>();

            fromKey = toKey;
            return this;
        }

        public IUnitBuilder WithNoFriendlyUnitStacking<TUnit>() where TUnit : IUnit<TUnit>
        {
            fromKey = fromKey ?? typeof (TUnit).Name;
            toKey = $"{fromKey}_WithNoFriendlyUnitStacking";

            // Using a local variable, the value of fromKey is preserved in the closure.
            var preservedFromKey = fromKey;

            builder.Register(
                c => new NoFriendlyUnitStacking<TUnit>(c.ResolveNamed<IUnit<TUnit>>(preservedFromKey),
                                                       c.Resolve<ISet<IUnit>>()))
                   .Named<IUnit<TUnit>>(toKey)
                   .As<IUnit<TUnit>>();

            fromKey = toKey;
            return this;
        }

        public IUnitBuilder WithNoEntranceToImpassableTerrain<TUnit>() where TUnit : IUnit<TUnit>
        {
            fromKey = fromKey ?? typeof (TUnit).Name;
            toKey = $"{fromKey}_WithNoEntranceToImpassableTerrain";

            // Using a local variable, the value of fromKey is preserved in the closure.
            var preservedFromKey = fromKey;

            builder.Register(
                c => new NoEntranceToImpassableTerrain<TUnit>(c.ResolveNamed<IUnit<TUnit>>(preservedFromKey),
                                                              c.Resolve<ISet<ITerrain>>()))
                   .Named<IUnit<TUnit>>(toKey)
                   .As<IUnit<TUnit>>();

            fromKey = toKey;
            return this;
        }

        public IUnitBuilder WithFortificationAction<TUnit>() where TUnit : IUnit<TUnit>
        {
            fromKey = fromKey ?? typeof (TUnit).Name;
            toKey = $"{fromKey}_WithFortificationAction";

            // Using a local variable, the value of fromKey is preserved in the closure.
            var preservedFromKey = fromKey;

            builder.Register(
                c => new FortificationAction<TUnit>(c.ResolveNamed<IUnit<TUnit>>(preservedFromKey)))
                   .Named<IUnit<TUnit>>(toKey)
                   .As<IUnit<TUnit>>();

            fromKey = toKey;
            return this;
        }

        public IUnitBuilder WithCityBuildingAction<TUnit>() where TUnit : IUnit<TUnit>
        {
            fromKey = fromKey ?? typeof (TUnit).Name;
            toKey = $"{fromKey}_WithCityBuildingAction";

            // Using a local variable, the value of fromKey is preserved in the closure.
            var preservedFromKey = fromKey;

            builder.Register(
                c => new CityBuildingAction<TUnit>(c.ResolveNamed<IUnit<TUnit>>(preservedFromKey),
                                                   c.Resolve<ISet<IUnit>>(),
                                                   c.Resolve<ISet<ICity>>(),
                                                   c.Resolve<ICityFactory<City>>()))
                   .Named<IUnit<TUnit>>(toKey)
                   .As<IUnit<TUnit>>();

            fromKey = toKey;
            return this;
        }

        public IUnitBuilder WithFriendlyUnitManagementOnly<TUnit>() where TUnit : IUnit<TUnit>
        {
            fromKey = fromKey ?? typeof (TUnit).Name;
            toKey = $"{fromKey}_WithFriendlyUnitManagementOnly";

            // Using a local variable, the value of fromKey is preserved in the closure.
            var preservedFromKey = fromKey;

            builder.Register(
                c => new FriendlyUnitManagementOnly<TUnit>(c.ResolveNamed<IUnit<TUnit>>(preservedFromKey),
                                                           c.Resolve<ITurnTaking>()))
                   .Named<IUnit<TUnit>>(toKey)
                   .As<IUnit<TUnit>>();

            fromKey = toKey;
            return this;
        }
    }
}
