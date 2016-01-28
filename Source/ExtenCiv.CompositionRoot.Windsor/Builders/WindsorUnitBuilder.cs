using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Actions;
using ExtenCiv.Units.Movement;

namespace ExtenCiv.Composition.Windsor.Builders
{
    public class WindsorUnitBuilder : IUnitBuilder
    {
        private readonly IWindsorContainer container;

        public WindsorUnitBuilder(IWindsorContainer container) { this.container = container; }

        public IUnitBuilder WithMovability<TUnit>() where TUnit : IUnit<TUnit>
        {
            container.Register(Component.For<IUnit<TUnit>>()
                                        .ImplementedBy<Movability<TUnit>>()
                                        .LifestyleTransient());
            return this;
        }

        public IUnitBuilder WithMoveCosts<TUnit>() where TUnit : IUnit<TUnit>
        {
            container.Register(Component.For<IUnit<TUnit>>()
                                        .ImplementedBy<MoveCosts<TUnit>>()
                                        .LifestyleTransient());
            return this;
        }

        public IUnitBuilder WithRestorationOfMoves<TUnit>() where TUnit : IUnit<TUnit>
        {
            container.Register(Component.For<IUnit<TUnit>>()
                                        .ImplementedBy<RestorationOfMoves<TUnit>>()
                                        .LifestyleTransient());
            return this;
        }

        public IUnitBuilder WithCityConquest<TUnit>() where TUnit : IUnit<TUnit>
        {
            container.Register(Component.For<IUnit<TUnit>>()
                                        .ImplementedBy<CityConquest<TUnit>>()
                                        .LifestyleTransient());
            return this;
        }

        public IUnitBuilder WithOneToOneCombatEngagement<TUnit>() where TUnit : IUnit<TUnit>
        {
            container.Register(Component.For<IUnit<TUnit>>()
                                        .ImplementedBy<OneToOneCombatEngagement<TUnit>>()
                                        .LifestyleTransient());
            return this;
        }

        public IUnitBuilder WithLimitedMoveRange<TUnit>() where TUnit : IUnit<TUnit>
        {
            container.Register(Component.For<IUnit<TUnit>>()
                                        .ImplementedBy<LimitedMoveRange<TUnit>>()
                                        .LifestyleTransient());
            return this;
        }

        public IUnitBuilder WithNoFriendlyUnitStacking<TUnit>() where TUnit : IUnit<TUnit>
        {
            container.Register(Component.For<IUnit<TUnit>>()
                                        .ImplementedBy<NoFriendlyUnitStacking<TUnit>>()
                                        .LifestyleTransient());
            return this;
        }

        public IUnitBuilder WithNoEntranceToImpassableTerrain<TUnit>() where TUnit : IUnit<TUnit>
        {
            container.Register(Component.For<IUnit<TUnit>>()
                                        .ImplementedBy<NoEntranceToImpassableTerrain<TUnit>>()
                                        .LifestyleTransient());
            return this;
        }

        public IUnitBuilder WithFortificationAction<TUnit>() where TUnit : IUnit<TUnit>
        {
            container.Register(Component.For<IUnit<TUnit>>()
                                        .ImplementedBy<FortificationAction<TUnit>>()
                                        .LifestyleTransient());
            return this;
        }

        public IUnitBuilder WithCityBuildingAction<TUnit>() where TUnit : IUnit<TUnit>
        {
            container.Register(Component.For<IUnit<TUnit>>()
                                        .ImplementedBy<CityBuildingAction<TUnit>>()
                                        .LifestyleTransient());
            return this;
        }

        public IUnitBuilder WithFriendlyUnitManagementOnly<TUnit>() where TUnit : IUnit<TUnit>
        {
            container.Register(Component.For<IUnit<TUnit>>()
                                        .ImplementedBy<FriendlyUnitManagementOnly<TUnit>>()
                                        .LifestyleTransient());
            return this;
        }
    }
}
