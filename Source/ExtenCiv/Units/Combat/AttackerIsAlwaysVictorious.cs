using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Combat.Abstractions;
using ExtenCiv.Units.Combat.Enumerations;
using static ExtenCiv.Units.Combat.Enumerations.CombatOutcome;

namespace ExtenCiv.Units.Combat
{
    /// <summary>
    ///     The attacking unit is always victorious in combat.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     None.
    /// </summary>
    public sealed class AttackerIsAlwaysVictorious : IUnitCombat
    {
        /// <summary>
        ///     Determines the victor of a combat between two units,
        ///     returning <c>true</c> if and only if the attacking unit is victorious.
        /// </summary>
        /// <param name="attacker">The attacking unit.</param>
        /// <param name="defender">The defending unit.</param>
        public CombatOutcome CombatOutcome(IUnit attacker, IUnit defender) => AttackerIsVictorious;
    }
}
