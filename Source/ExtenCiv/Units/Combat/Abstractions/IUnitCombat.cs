using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Combat.Enumerations;

namespace ExtenCiv.Units.Combat.Abstractions
{
    /// <summary>
    ///     A unit combat determines the victor of combat engagement between attacking units and defending units.
    /// </summary>
    public interface IUnitCombat
    {
        /// <summary>
        ///     Determines the victor of a combat between two units.
        /// </summary>
        /// <param name="attacker">The attacking unit.</param>
        /// <param name="defender">The defending unit.</param>
        CombatOutcome CombatOutcome(IUnit attacker, IUnit defender);
    }
}
