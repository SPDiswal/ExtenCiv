using DryIoc;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Actions;
using ExtenCiv.Units.Movement;

namespace ExtenCiv.CompositionRoot.DryIoc.Builders
{
    public class DryIocUnitBuilder : IUnitBuilder
    {
        private readonly IRegistrator builder;

        public DryIocUnitBuilder(IRegistrator builder) { this.builder = builder; }

        public IUnitBuilder WithMovability<TUnit>() where TUnit : IUnit<TUnit>
        {
            builder.Register<IUnit<TUnit>, Movability<TUnit>>(setup: Setup.Decorator);
            return this;
        }

        public IUnitBuilder WithMoveCosts<TUnit>() where TUnit : IUnit<TUnit>
        {
            builder.Register<IUnit<TUnit>, MoveCosts<TUnit>>(setup: Setup.Decorator);
            return this;
        }

        public IUnitBuilder WithRestorationOfMoves<TUnit>() where TUnit : IUnit<TUnit>
        {
            builder.Register<IUnit<TUnit>, RestorationOfMoves<TUnit>>(setup: Setup.Decorator);
            return this;
        }

        public IUnitBuilder WithCityConquest<TUnit>() where TUnit : IUnit<TUnit>
        {
            builder.Register<IUnit<TUnit>, CityConquest<TUnit>>(setup: Setup.Decorator);
            return this;
        }

        public IUnitBuilder WithOneToOneCombatEngagement<TUnit>() where TUnit : IUnit<TUnit>
        {
            builder.Register<IUnit<TUnit>, OneToOneCombatEngagement<TUnit>>(setup: Setup.Decorator);
            return this;
        }

        public IUnitBuilder WithLimitedMoveRange<TUnit>() where TUnit : IUnit<TUnit>
        {
            builder.Register<IUnit<TUnit>, LimitedMoveRange<TUnit>>(setup: Setup.Decorator);
            return this;
        }

        public IUnitBuilder WithNoFriendlyUnitStacking<TUnit>() where TUnit : IUnit<TUnit>
        {
            builder.Register<IUnit<TUnit>, NoFriendlyUnitStacking<TUnit>>(setup: Setup.Decorator);
            return this;
        }

        public IUnitBuilder WithNoEntranceToImpassableTerrain<TUnit>() where TUnit : IUnit<TUnit>
        {
            builder.Register<IUnit<TUnit>, NoEntranceToImpassableTerrain<TUnit>>(setup: Setup.Decorator);
            return this;
        }

        public IUnitBuilder WithFortificationAction<TUnit>() where TUnit : IUnit<TUnit>
        {
            builder.Register<IUnit<TUnit>, FortificationAction<TUnit>>(setup: Setup.Decorator);
            return this;
        }

        public IUnitBuilder WithCityBuildingAction<TUnit>() where TUnit : IUnit<TUnit>
        {
            builder.Register<IUnit<TUnit>, CityBuildingAction<TUnit>>(setup: Setup.Decorator);
            return this;
        }

        public IUnitBuilder WithFriendlyUnitManagementOnly<TUnit>() where TUnit : IUnit<TUnit>
        {
            builder.Register<IUnit<TUnit>, FriendlyUnitManagementOnly<TUnit>>(setup: Setup.Decorator);
            return this;
        }
    }
}
