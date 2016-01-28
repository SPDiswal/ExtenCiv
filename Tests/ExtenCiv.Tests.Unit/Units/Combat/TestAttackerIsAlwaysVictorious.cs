using ExtenCiv.Players;
using ExtenCiv.Tests.Utilities.Extensions;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Combat;
using ExtenCiv.Units.Combat.Enumerations;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.Units.Combat
{
    public sealed class TestAttackerIsAlwaysVictorious
    {
        /// <summary>
        ///     The attacking unit is always victorious in combat.
        /// </summary>
        [Theory]
        [MemberData(nameof(WhenTwoUnitsEngageInCombat))]
        public void CombatOutcome_ReturnsAttackerIsVictorious_BecauseTheAttackerIsAlwaysVictorious(IUnit attacker,
                                                                                                   IUnit defender)
        {
            // :::: ARRANGE ::::
            var attackerIsAlwaysVictorious = new AttackerIsAlwaysVictorious();

            // :::: ACT ::::
            var actualOutcome = attackerIsAlwaysVictorious.CombatOutcome(attacker, defender);

            // :::: ASSERT ::::
            actualOutcome.Should().Be(CombatOutcome.AttackerIsVictorious);
        }

        /// <summary>
        ///     When two units engage in combat, the attacking unit is victorious.
        /// </summary>
        public static TheoryData WhenTwoUnitsEngageInCombat => new TheoryData
            <IUnit, IUnit>
        {
            /* A Red Archer attacks and defeats a Blue Legion. */
            { Red.Archer(), Blue.Legion() },
            //
            /* A Blue Legion attacks and defeats a Red Archer.  */
            { Blue.Legion(), Red.Archer() },
        };

        #region HELPERS: Shortcuts

        private static Player Red => new Player("Red");
        private static Player Blue => new Player("Blue");

        #endregion
    }
}
