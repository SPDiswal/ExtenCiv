using System;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Actions;
using ExtenCiv.Units.Movement;
using Ninject;

namespace ExtenCiv.Composition.Ninject.Builders
{
    public class NinjectUnitBuilder : IUnitBuilder
    {
        private readonly IKernel kernel;

        private Type currentDecorator;

        public NinjectUnitBuilder(IKernel kernel) { this.kernel = kernel; }

        public IUnitBuilder WithMovability<TUnit>() where TUnit : IUnit<TUnit>
        {
            var binding = kernel.Bind<IUnit<TUnit>>()
                                .To<Movability<TUnit>>();

            if (currentDecorator != null) binding.WhenInjectedInto(currentDecorator);

            currentDecorator = typeof (Movability<TUnit>);
            return this;
        }

        public IUnitBuilder WithMoveCosts<TUnit>() where TUnit : IUnit<TUnit>
        {
            var binding = kernel.Bind<IUnit<TUnit>>()
                                .To<MoveCosts<TUnit>>();

            if (currentDecorator != null) binding.WhenInjectedInto(currentDecorator);

            currentDecorator = typeof (MoveCosts<TUnit>);
            return this;
        }

        public IUnitBuilder WithRestorationOfMoves<TUnit>() where TUnit : IUnit<TUnit>
        {
            var binding = kernel.Bind<IUnit<TUnit>>()
                                .To<RestorationOfMoves<TUnit>>();

            if (currentDecorator != null) binding.WhenInjectedInto(currentDecorator);

            currentDecorator = typeof (RestorationOfMoves<TUnit>);
            return this;
        }

        public IUnitBuilder WithCityConquest<TUnit>() where TUnit : IUnit<TUnit>
        {
            var binding = kernel.Bind<IUnit<TUnit>>()
                                .To<CityConquest<TUnit>>();

            if (currentDecorator != null) binding.WhenInjectedInto(currentDecorator);

            currentDecorator = typeof (CityConquest<TUnit>);
            return this;
        }

        public IUnitBuilder WithOneToOneCombatEngagement<TUnit>() where TUnit : IUnit<TUnit>
        {
            var binding = kernel.Bind<IUnit<TUnit>>()
                                .To<OneToOneCombatEngagement<TUnit>>();

            if (currentDecorator != null) binding.WhenInjectedInto(currentDecorator);

            currentDecorator = typeof (OneToOneCombatEngagement<TUnit>);
            return this;
        }

        public IUnitBuilder WithLimitedMoveRange<TUnit>() where TUnit : IUnit<TUnit>
        {
            var binding = kernel.Bind<IUnit<TUnit>>()
                                .To<LimitedMoveRange<TUnit>>();

            if (currentDecorator != null) binding.WhenInjectedInto(currentDecorator);

            currentDecorator = typeof (LimitedMoveRange<TUnit>);
            return this;
        }

        public IUnitBuilder WithNoFriendlyUnitStacking<TUnit>() where TUnit : IUnit<TUnit>
        {
            var binding = kernel.Bind<IUnit<TUnit>>()
                                .To<NoFriendlyUnitStacking<TUnit>>();

            if (currentDecorator != null) binding.WhenInjectedInto(currentDecorator);

            currentDecorator = typeof (NoFriendlyUnitStacking<TUnit>);
            return this;
        }

        public IUnitBuilder WithNoEntranceToImpassableTerrain<TUnit>() where TUnit : IUnit<TUnit>
        {
            var binding = kernel.Bind<IUnit<TUnit>>()
                                .To<NoEntranceToImpassableTerrain<TUnit>>();

            if (currentDecorator != null) binding.WhenInjectedInto(currentDecorator);

            currentDecorator = typeof (NoEntranceToImpassableTerrain<TUnit>);
            return this;
        }

        public IUnitBuilder WithFortificationAction<TUnit>() where TUnit : IUnit<TUnit>
        {
            var binding = kernel.Bind<IUnit<TUnit>>()
                                .To<FortificationAction<TUnit>>();

            if (currentDecorator != null) binding.WhenInjectedInto(currentDecorator);

            currentDecorator = typeof (FortificationAction<TUnit>);
            return this;
        }

        public IUnitBuilder WithCityBuildingAction<TUnit>() where TUnit : IUnit<TUnit>
        {
            var binding = kernel.Bind<IUnit<TUnit>>()
                                .To<CityBuildingAction<TUnit>>();

            if (currentDecorator != null) binding.WhenInjectedInto(currentDecorator);

            currentDecorator = typeof (CityBuildingAction<TUnit>);
            return this;
        }

        public IUnitBuilder WithFriendlyUnitManagementOnly<TUnit>() where TUnit : IUnit<TUnit>
        {
            var binding = kernel.Bind<IUnit<TUnit>>()
                                .To<FriendlyUnitManagementOnly<TUnit>>();

            if (currentDecorator != null) binding.WhenInjectedInto(currentDecorator);

            currentDecorator = typeof (FriendlyUnitManagementOnly<TUnit>);
            return this;
        }
    }
}
