using ExtenCiv.Players;
using ExtenCiv.Tests.Utilities.Extensions;
using ExtenCiv.Tests.Utilities.Stubs;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Combat.Abstractions;
using ExtenCiv.Units.Combat.Enumerations;
using ExtenCiv.Units.Movement;
using ExtenCiv.Units.Types;
using ExtenCiv.WorldMaps.Tiles;
using ExtenCiv.WorldMaps.Tiles.Abstractions;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.Units.Movement
{
    public sealed class TestOneToOneCombatEngagement
    {
        /// <summary>
        ///     Units engage in combat when moving and the attacking unit defeats the defending unit.
        /// </summary>
        /// <param name="attacker">The unit to move (the attacking unit).</param>
        /// <param name="defender">The unit at the destination (the defending unit).</param>
        [Theory]
        [MemberData(nameof(WhenMovingToATileWithAnotherUnit))]
        public void MoveTo_DefeatsTheDefender_BecauseTheAttackerIsVictorious(IUnit<Archer> attacker,
                                                                                    IUnit defender)
        {
            // :::: ARRANGE ::::
            var stubUnits = StubWorld.Units(new[] { attacker, defender });
            var stubCombat = StubCombat(attacker, defender, CombatOutcome.AttackerIsVictorious);
            var combatEngagingUnit = new OneToOneCombatEngagement<Archer>(attacker, stubUnits, stubCombat);

            // :::: ACT ::::
            var destination = defender.Location;
            combatEngagingUnit.MoveTo(destination);

            // :::: ASSERT ::::
            stubUnits.Should().Equal(attacker);
        }

        /// <summary>
        ///     Units engage in combat when moving and the attacking unit is defeated by the defending unit.
        /// </summary>
        /// <param name="attacker">The unit to move (the attacking unit).</param>
        /// <param name="defender">The unit at the destination (the defending unit).</param>
        [Theory]
        [MemberData(nameof(WhenMovingToATileWithAnotherUnit))]
        public void MoveTo_DefeatsTheAttacker_BecauseTheDefenderIsVictorious(IUnit<Archer> attacker,
                                                                                    IUnit defender)
        {
            // :::: ARRANGE ::::
            var stubUnits = StubWorld.Units(new[] { attacker, defender });
            var stubCombat = StubCombat(attacker, defender, CombatOutcome.DefenderIsVictorious);
            var combatEngagingUnit = new OneToOneCombatEngagement<Archer>(attacker, stubUnits, stubCombat);

            // :::: ACT ::::
            var destination = defender.Location;
            combatEngagingUnit.MoveTo(destination);

            // :::: ASSERT ::::
            stubUnits.Should().Equal(defender);
        }

        /// <summary>
        ///     When moving to a tile with another unit, the units engage in combat.
        /// </summary>
        public static TheoryData WhenMovingToATileWithAnotherUnit => new TheoryData
            <IUnit<Archer>, IUnit>
        {
            /* A Red Archer moves to (3, 1) and engages in combat with a Blue Legion. */
            { Red.Archer().At(3, 0), Blue.Legion().At(3, 1) },
            //
            /* A Blue Archer moves to (4, 3) and engages in combat with a Red Legion. */
            { Blue.Archer().At(4, 2), Red.Legion().At(4, 3) },
        };

        /// <summary>
        ///     <c>MoveTo</c> is forwarded after the attacking unit defeats the defending unit.
        /// </summary>
        [Fact]
        public void MoveTo_IsForwardedAfterTheAttackingUnitDefeatsTheDefendingUnit()
        {
            // :::: ARRANGE ::::
            var spyUnit = A.Fake<IUnit<Archer>>();
            var stubUnits = StubWorld.Units(new[] { spyUnit, Red.Archer().At(0, 0) });
            var stubCombat = A.Fake<IUnitCombat>();
            var combatEngagingUnit = new OneToOneCombatEngagement<Archer>(spyUnit, stubUnits, stubCombat);

            A.CallTo(() => stubCombat.CombatOutcome(A<IUnit>._, A<IUnit>._)).Returns(CombatOutcome.AttackerIsVictorious);

            // :::: ACT ::::
            combatEngagingUnit.MoveTo(DummyPosition);

            // :::: ASSERT ::::
            A.CallTo(() => spyUnit.MoveTo(DummyPosition)).MustHaveHappened();
        }

        /// <summary>
        ///     <c>MoveTo</c> is not forwarded after the attacking unit is defeated by the defending unit.
        /// </summary>
        [Fact]
        public void MoveTo_IsNotForwardedAfterTheAttackingUnitIsDefeatedByTheDefendingUnit()
        {
            // :::: ARRANGE ::::
            var spyUnit = A.Fake<IUnit<Archer>>();
            var stubUnits = StubWorld.Units(new[] { spyUnit, Red.Archer().At(0, 0) });
            var stubCombat = A.Fake<IUnitCombat>();
            var combatEngagingUnit = new OneToOneCombatEngagement<Archer>(spyUnit, stubUnits, stubCombat);

            A.CallTo(() => stubCombat.CombatOutcome(A<IUnit>._, A<IUnit>._)).Returns(CombatOutcome.DefenderIsVictorious);

            // :::: ACT ::::
            combatEngagingUnit.MoveTo(DummyPosition);

            // :::: ASSERT ::::
            A.CallTo(() => spyUnit.MoveTo(A<ITile>._)).MustNotHaveHappened();
        }

        #region HELPERS: Shortcuts

        private static Player Red => new Player("Red");
        private static Player Blue => new Player("Blue");

        #endregion

        #region HELPERS: Stubs

        private static IUnitCombat StubCombat(IUnit attacker, IUnit defender, CombatOutcome fixedOutcome)
        {
            var stubCombat = A.Fake<IUnitCombat>();

            A.CallTo(() => stubCombat.CombatOutcome(A<IUnit>.That.Matches(unit => unit.Id == attacker.Id),
                                                    A<IUnit>.That.Matches(unit => unit.Id == defender.Id)))
             .Returns(fixedOutcome);

            return stubCombat;
        }

        #endregion

        #region HELPERS: Dummies

        private static ITile DummyPosition => new SquareTile(0, 0);

        #endregion
    }
}
