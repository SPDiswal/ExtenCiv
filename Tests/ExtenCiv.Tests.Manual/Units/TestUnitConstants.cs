using ExtenCiv.Units;
using FluentAssertions;
using Xunit;
using static ExtenCiv.Players.Player;

namespace ExtenCiv.Tests.Units
{
    public sealed class TestUnitConstants
    {
        #region Attacking strengths

        public static readonly TheoryData AttackReturnsAttackingStrengthOfUnit = new TheoryData
            <IUnit, int>
        {
            /* Archers have an attacking strength of 2. */
            { new Archer(Nobody), 2 },
            //
            /* Legions have an attacking strength of 4. */
            { new Legion(Nobody), 4 },
            //
            /* Settlers have an attacking strength of 0. */
            { new Settler(Nobody), 0 },
        };

        [Theory]
        [MemberData(nameof(AttackReturnsAttackingStrengthOfUnit))]
        public void Attack_ReturnsAttackingStrengthOfUnit(IUnit unit, int expectedAttackingStrength)
        {
            // :::: ACT ::::
            var actualAttackingStrength = unit.Attack;

            // :::: ASSERT ::::
            actualAttackingStrength.Should().Be(expectedAttackingStrength);
        }

        #endregion

        #region Defensive strengths

        public static readonly TheoryData DefenceReturnsDefensiveStrengthOfUnit = new TheoryData
            <IUnit, int>
        {
            /* Archers have a defensive strength of 3. */
            { new Archer(Nobody), 3 },
            //
            /* Legions have a defensive strength of 2. */
            { new Legion(Nobody), 2 },
            //
            /* Settlers have a defensive strength of 3. */
            { new Settler(Nobody), 3 },
        };

        [Theory]
        [MemberData(nameof(DefenceReturnsDefensiveStrengthOfUnit))]
        public void Defence_ReturnsDefensiveStrengthOfUnit(IUnit unit, int expectedDefensiveStrength)
        {
            // :::: ACT ::::
            var actualDefensiveStrength = unit.Defence;

            // :::: ASSERT ::::
            actualDefensiveStrength.Should().Be(expectedDefensiveStrength);
        }

        #endregion

        #region Total movement

        public static readonly TheoryData TotalMovementReturnsTotalMovementOfUnit = new TheoryData
            <IUnit, int>
        {
            /* Archers have a total movement of 1. */
            { new Archer(Nobody), 1 },
            //
            /* Legions have a total movement of 1. */
            { new Legion(Nobody), 1 },
            //
            /* Settlers have a total movement of 1. */
            { new Settler(Nobody), 1 },
        };

        [Theory]
        [MemberData(nameof(TotalMovementReturnsTotalMovementOfUnit))]
        public void TotalMovement_ReturnsTotalMovementOfUnit(IUnit unit, int expectedTotalMovement)
        {
            // :::: ACT ::::
            var actualDefensiveStrength = unit.TotalMovement;

            // :::: ASSERT ::::
            actualDefensiveStrength.Should().Be(expectedTotalMovement);
        }

        #endregion

        #region Production costs

        public static readonly TheoryData ProductionCostReturnsProductionCostOfUnit = new TheoryData
            <IUnit, int>
        {
            /* Archers cost 10 production. */
            { new Archer(Nobody), 10 },
            //
            /* Legions cost 15 production. */
            { new Legion(Nobody), 15 },
            //
            /* Settlers cost 30 production. */
            { new Settler(Nobody), 30 },
        };

        [Theory]
        [MemberData(nameof(ProductionCostReturnsProductionCostOfUnit))]
        public void ProductionCost_ReturnsProductionCostOfUnit(IUnit unit, int expectedProductionCost)
        {
            // :::: ACT ::::
            var actualProductionCost = unit.ProductionCost;

            // :::: ASSERT ::::
            actualProductionCost.Should().Be(expectedProductionCost);
        }

        #endregion
    }
}
