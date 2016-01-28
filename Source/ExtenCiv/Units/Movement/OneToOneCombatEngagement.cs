using System;
using System.Collections.Generic;
using System.Linq;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Combat.Abstractions;
using ExtenCiv.Units.Combat.Enumerations;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Units.Movement
{
    /// <summary>
    ///     The unit engages in one-to-one combat with another unit when entering its tile.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Decorated unit,
    ///     Set of units,
    ///     Unit combat.
    /// </summary>
    public sealed class OneToOneCombatEngagement<TUnit> : UnitDecorator<TUnit> where TUnit : IUnit<TUnit>
    {
        private readonly ISet<IUnit> units;
        private readonly IUnitCombat combat;

        public OneToOneCombatEngagement(IUnit<TUnit> unit, ISet<IUnit> units, IUnitCombat combat) : base(unit)
        {
            this.combat = combat;
            this.units = units;
        }

        /// <summary>
        ///     Moves this unit to the specified location.
        /// </summary>
        /// <param name="destination">The tile to move the unit to.</param>
        public override void MoveTo(ITile destination)
        {
            var defender = units.SingleOrDefault(unit => unit.Location.Equals(destination));

            if (defender != null)
            {
                var combatOutcome = combat.CombatOutcome(this, defender);

                switch (combatOutcome)
                {
                    case CombatOutcome.AttackerIsVictorious:
                        units.Remove(defender);
                        break;

                    case CombatOutcome.DefenderIsVictorious:
                        units.Remove(this);
                        return;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            base.MoveTo(destination);
        }
    }
}
