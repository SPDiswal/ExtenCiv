﻿using System;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using ExtenCiv.CompositionRoot.Directors.Abstractions;
using ExtenCiv.Units.Types;

namespace ExtenCiv.CompositionRoot.Directors.Units
{
    public sealed class ReversedFourUnitsWithActions : IUnitDirector
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
            builder.WithFriendlyUnitManagementOnly<Archer>()
                   .WithFortificationAction<Archer>()
                   .WithNoEntranceToImpassableTerrain<Archer>()
                   .WithNoFriendlyUnitStacking<Archer>()
                   .WithLimitedMoveRange<Archer>()
                   .WithOneToOneCombatEngagement<Archer>()
                   .WithCityConquest<Archer>()
                   .WithRestorationOfMoves<Archer>()
                   .WithMoveCosts<Archer>()
                   .WithMovability<Archer>();
        }

        private static void Chariots(IUnitBuilder builder)
        {
            builder.WithFriendlyUnitManagementOnly<Chariot>()
                   .WithFortificationAction<Chariot>()
                   .WithNoEntranceToImpassableTerrain<Chariot>()
                   .WithNoFriendlyUnitStacking<Chariot>()
                   .WithLimitedMoveRange<Chariot>()
                   .WithOneToOneCombatEngagement<Chariot>()
                   .WithCityConquest<Chariot>()
                   .WithRestorationOfMoves<Chariot>()
                   .WithMoveCosts<Chariot>()
                   .WithMovability<Chariot>();
        }

        private static void Legions(IUnitBuilder builder)
        {
            builder.WithFriendlyUnitManagementOnly<Legion>()
                   .WithNoEntranceToImpassableTerrain<Legion>()
                   .WithNoFriendlyUnitStacking<Legion>()
                   .WithLimitedMoveRange<Legion>()
                   .WithOneToOneCombatEngagement<Legion>()
                   .WithCityConquest<Legion>()
                   .WithRestorationOfMoves<Legion>()
                   .WithMoveCosts<Legion>()
                   .WithMovability<Legion>();
        }

        private static void Settlers(IUnitBuilder builder)
        {
            builder.WithFriendlyUnitManagementOnly<Settler>()
                   .WithCityBuildingAction<Settler>()
                   .WithNoEntranceToImpassableTerrain<Settler>()
                   .WithNoFriendlyUnitStacking<Settler>()
                   .WithLimitedMoveRange<Settler>()
                   .WithOneToOneCombatEngagement<Settler>()
                   .WithRestorationOfMoves<Settler>()
                   .WithMoveCosts<Settler>()
                   .WithMovability<Settler>();
        }
    }
}
