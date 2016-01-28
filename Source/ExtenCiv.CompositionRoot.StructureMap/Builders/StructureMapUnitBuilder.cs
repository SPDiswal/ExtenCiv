using ExtenCiv.CompositionRoot.Builders.Abstractions;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Actions;
using ExtenCiv.Units.Movement;
using StructureMap;

namespace ExtenCiv.Composition.StructureMap.Builders
{
    public class StructureMapUnitBuilder : IUnitBuilder
    {
        private readonly IContainer container;

        public StructureMapUnitBuilder(IContainer container) { this.container = container; }

        public IUnitBuilder WithMovability<TUnit>() where TUnit : IUnit<TUnit>
        {
            container.Configure(c => c.For(typeof (IUnit<TUnit>))
                                      .DecorateAllWith(typeof (Movability<TUnit>)));
            return this;
        }

        public IUnitBuilder WithMoveCosts<TUnit>() where TUnit : IUnit<TUnit>
        {
            container.Configure(c => c.For(typeof (IUnit<TUnit>))
                                      .DecorateAllWith(typeof (MoveCosts<TUnit>)));
            return this;
        }

        public IUnitBuilder WithRestorationOfMoves<TUnit>() where TUnit : IUnit<TUnit>
        {
            container.Configure(c => c.For(typeof (IUnit<TUnit>))
                                      .DecorateAllWith(typeof (RestorationOfMoves<TUnit>)));
            return this;
        }

        public IUnitBuilder WithCityConquest<TUnit>() where TUnit : IUnit<TUnit>
        {
            container.Configure(c => c.For(typeof (IUnit<TUnit>))
                                      .DecorateAllWith(typeof (CityConquest<TUnit>)));
            return this;
        }

        public IUnitBuilder WithOneToOneCombatEngagement<TUnit>() where TUnit : IUnit<TUnit>
        {
            container.Configure(c => c.For(typeof (IUnit<TUnit>))
                                      .DecorateAllWith(typeof (OneToOneCombatEngagement<TUnit>)));
            return this;
        }

        public IUnitBuilder WithLimitedMoveRange<TUnit>() where TUnit : IUnit<TUnit>
        {
            container.Configure(c => c.For(typeof (IUnit<TUnit>))
                                      .DecorateAllWith(typeof (LimitedMoveRange<TUnit>)));
            return this;
        }

        public IUnitBuilder WithNoFriendlyUnitStacking<TUnit>() where TUnit : IUnit<TUnit>
        {
            container.Configure(c => c.For(typeof (IUnit<TUnit>))
                                      .DecorateAllWith(typeof (NoFriendlyUnitStacking<TUnit>)));
            return this;
        }

        public IUnitBuilder WithNoEntranceToImpassableTerrain<TUnit>() where TUnit : IUnit<TUnit>
        {
            container.Configure(c => c.For(typeof (IUnit<TUnit>))
                                      .DecorateAllWith(typeof (NoEntranceToImpassableTerrain<TUnit>)));
            return this;
        }

        public IUnitBuilder WithFortificationAction<TUnit>() where TUnit : IUnit<TUnit>
        {
            container.Configure(c => c.For(typeof (IUnit<TUnit>))
                                      .DecorateAllWith(typeof (FortificationAction<TUnit>)));
            return this;
        }

        public IUnitBuilder WithCityBuildingAction<TUnit>() where TUnit : IUnit<TUnit>
        {
            container.Configure(c => c.For(typeof (IUnit<TUnit>))
                                      .DecorateAllWith(typeof (CityBuildingAction<TUnit>)));
            return this;
        }

        public IUnitBuilder WithFriendlyUnitManagementOnly<TUnit>() where TUnit : IUnit<TUnit>
        {
            container.Configure(c => c.For(typeof (IUnit<TUnit>))
                                      .DecorateAllWith(typeof (FriendlyUnitManagementOnly<TUnit>)));
            return this;
        }
    }
}
