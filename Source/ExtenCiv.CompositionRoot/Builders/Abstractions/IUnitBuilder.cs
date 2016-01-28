using ExtenCiv.Units.Abstractions;

namespace ExtenCiv.CompositionRoot.Builders.Abstractions
{
    public interface IUnitBuilder
    {
        IUnitBuilder WithMovability<TUnit>() where TUnit : IUnit<TUnit>;

        IUnitBuilder WithMoveCosts<TUnit>() where TUnit : IUnit<TUnit>;

        IUnitBuilder WithRestorationOfMoves<TUnit>() where TUnit : IUnit<TUnit>;

        IUnitBuilder WithCityConquest<TUnit>() where TUnit : IUnit<TUnit>;

        IUnitBuilder WithOneToOneCombatEngagement<TUnit>() where TUnit : IUnit<TUnit>;

        IUnitBuilder WithLimitedMoveRange<TUnit>() where TUnit : IUnit<TUnit>;

        IUnitBuilder WithNoFriendlyUnitStacking<TUnit>() where TUnit : IUnit<TUnit>;

        IUnitBuilder WithNoEntranceToImpassableTerrain<TUnit>() where TUnit : IUnit<TUnit>;

        IUnitBuilder WithFortificationAction<TUnit>() where TUnit : IUnit<TUnit>;

        IUnitBuilder WithCityBuildingAction<TUnit>() where TUnit : IUnit<TUnit>;

        IUnitBuilder WithFriendlyUnitManagementOnly<TUnit>() where TUnit : IUnit<TUnit>;
    }
}
