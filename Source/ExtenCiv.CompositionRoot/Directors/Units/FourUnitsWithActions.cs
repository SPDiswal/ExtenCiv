using System;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using ExtenCiv.CompositionRoot.Directors.Abstractions;
using ExtenCiv.Units.Types;

namespace ExtenCiv.CompositionRoot.Directors.Units
{
    public sealed class FourUnitsWithActions : IUnitDirector
    {
        public void SetUpUnits(Func<IUnitBuilder> builder)
        {
            Archers(builder.Invoke());
            Chariots(builder.Invoke());
            Legions(builder.Invoke());
            Settlers(builder.Invoke());
        }

        private static void Archers(IUnitBuilder builder)
        {
            builder.WithMovability<Archer>()
                   .WithMoveCosts<Archer>()
                   .WithRestorationOfMoves<Archer>()
                   .WithCityConquest<Archer>()
                   .WithOneToOneCombatEngagement<Archer>()
                   .WithLimitedMoveRange<Archer>()
                   .WithNoFriendlyUnitStacking<Archer>()
                   .WithNoEntranceToImpassableTerrain<Archer>()
                   .WithFortificationAction<Archer>()
                   .WithFriendlyUnitManagementOnly<Archer>();
        }

        private static void Chariots(IUnitBuilder builder)
        {
            builder.WithMovability<Chariot>()
                   .WithMoveCosts<Chariot>()
                   .WithRestorationOfMoves<Chariot>()
                   .WithCityConquest<Chariot>()
                   .WithOneToOneCombatEngagement<Chariot>()
                   .WithLimitedMoveRange<Chariot>()
                   .WithNoFriendlyUnitStacking<Chariot>()
                   .WithNoEntranceToImpassableTerrain<Chariot>()
                   .WithFortificationAction<Chariot>()
                   .WithFriendlyUnitManagementOnly<Chariot>();
        }

        private static void Legions(IUnitBuilder builder)
        {
            builder.WithMovability<Legion>()
                   .WithMoveCosts<Legion>()
                   .WithRestorationOfMoves<Legion>()
                   .WithCityConquest<Legion>()
                   .WithOneToOneCombatEngagement<Legion>()
                   .WithLimitedMoveRange<Legion>()
                   .WithNoFriendlyUnitStacking<Legion>()
                   .WithNoEntranceToImpassableTerrain<Legion>()
                   .WithFriendlyUnitManagementOnly<Legion>();
        }

        private static void Settlers(IUnitBuilder builder)
        {
            builder.WithMovability<Settler>()
                   .WithMoveCosts<Settler>()
                   .WithRestorationOfMoves<Settler>()
                   .WithOneToOneCombatEngagement<Settler>()
                   .WithLimitedMoveRange<Settler>()
                   .WithNoFriendlyUnitStacking<Settler>()
                   .WithNoEntranceToImpassableTerrain<Settler>()
                   .WithCityBuildingAction<Settler>()
                   .WithFriendlyUnitManagementOnly<Settler>();
        }
    }
}
