using ExtenCiv.CompositionRoot.Builders.Abstractions;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Actions;
using ExtenCiv.Units.Movement;
using LightInject;

namespace ExtenCiv.Composition.LightInject.Builders
{
    public class LightInjectUnitBuilder : IUnitBuilder
    {
        private readonly IServiceRegistry serviceRegistry;

        public LightInjectUnitBuilder(IServiceRegistry serviceRegistry) { this.serviceRegistry = serviceRegistry; }

        public IUnitBuilder WithMovability<TUnit>() where TUnit : IUnit<TUnit>
        {
            serviceRegistry.Decorate(typeof (IUnit<TUnit>), typeof (Movability<TUnit>));
            return this;
        }

        public IUnitBuilder WithMoveCosts<TUnit>() where TUnit : IUnit<TUnit>
        {
            serviceRegistry.Decorate(typeof (IUnit<TUnit>), typeof (MoveCosts<TUnit>));
            return this;
        }

        public IUnitBuilder WithRestorationOfMoves<TUnit>() where TUnit : IUnit<TUnit>
        {
            serviceRegistry.Decorate(typeof (IUnit<TUnit>), typeof (RestorationOfMoves<TUnit>));
            return this;
        }

        public IUnitBuilder WithCityConquest<TUnit>() where TUnit : IUnit<TUnit>
        {
            serviceRegistry.Decorate(typeof (IUnit<TUnit>), typeof (CityConquest<TUnit>));
            return this;
        }

        public IUnitBuilder WithOneToOneCombatEngagement<TUnit>() where TUnit : IUnit<TUnit>
        {
            serviceRegistry.Decorate(typeof (IUnit<TUnit>), typeof (OneToOneCombatEngagement<TUnit>));
            return this;
        }

        public IUnitBuilder WithLimitedMoveRange<TUnit>() where TUnit : IUnit<TUnit>
        {
            serviceRegistry.Decorate(typeof (IUnit<TUnit>), typeof (LimitedMoveRange<TUnit>));
            return this;
        }

        public IUnitBuilder WithNoFriendlyUnitStacking<TUnit>() where TUnit : IUnit<TUnit>
        {
            serviceRegistry.Decorate(typeof (IUnit<TUnit>), typeof (NoFriendlyUnitStacking<TUnit>));
            return this;
        }

        public IUnitBuilder WithNoEntranceToImpassableTerrain<TUnit>() where TUnit : IUnit<TUnit>
        {
            serviceRegistry.Decorate(typeof (IUnit<TUnit>), typeof (NoEntranceToImpassableTerrain<TUnit>));
            return this;
        }

        public IUnitBuilder WithFortificationAction<TUnit>() where TUnit : IUnit<TUnit>
        {
            serviceRegistry.Decorate(typeof (IUnit<TUnit>), typeof (FortificationAction<TUnit>));
            return this;
        }

        public IUnitBuilder WithCityBuildingAction<TUnit>() where TUnit : IUnit<TUnit>
        {
            serviceRegistry.Decorate(typeof (IUnit<TUnit>), typeof (CityBuildingAction<TUnit>));
            return this;
        }

        public IUnitBuilder WithFriendlyUnitManagementOnly<TUnit>() where TUnit : IUnit<TUnit>
        {
            serviceRegistry.Decorate(typeof (IUnit<TUnit>), typeof (FriendlyUnitManagementOnly<TUnit>));
            return this;
        }
    }
}
