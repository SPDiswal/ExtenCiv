using ExtenCiv.UnitActions;
using ExtenCiv.Units;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.UnitActions
{
    public sealed class TestFortifiableAction
    {
        private static IUnit DefensiveUnit(int defence)
        {
            var stubUnit = A.Fake<IUnit>();
            A.CallTo(() => stubUnit.Defence).Returns(defence);
            A.CallTo(() => stubUnit.ToString()).Returns($"Unit with defence {defence}");
            return stubUnit;
        }

        private static IUnit MovableUnit(int remainingMovement)
        {
            var stubUnit = A.Fake<IUnit>();
            A.CallTo(() => stubUnit.RemainingMovement).Returns(remainingMovement);
            A.CallTo(() => stubUnit.ToString()).Returns($"Unit with remaining movement {remainingMovement}");
            return stubUnit;
        }

        #region Fortified units have double defensive strength.

        public static readonly TheoryData DefenceIsDoubledWhenUnitIsFortified = new TheoryData
            <IUnit>
        {
            /* A fortified unit has defensive strength of 10, when it normally has defensive strength of 5. */
            DefensiveUnit(5),
            //
            /* A fortified unit has defensive strength of 12, when it normally has defensive strength of 6. */
            DefensiveUnit(6),
        };

        [Theory]
        [MemberData(nameof(DefenceIsDoubledWhenUnitIsFortified))]
        public void Defence_IsDoubled_WhenUnitIsFortified(IUnit decoratedUnit)
        {
            // :::: ARRANGE ::::
            var fortifiableUnit = new FortificationAction(decoratedUnit);
            fortifiableUnit.PerformAction();

            // :::: ACT ::::
            var actualDefence = fortifiableUnit.Defence;

            // :::: ASSERT ::::
            var expectedDefence = 2 * decoratedUnit.Defence;
            actualDefence.Should().Be(expectedDefence);
        }

        #endregion

        #region Unfortified units have normal defensive strength.

        public static readonly TheoryData DefenceIsNormalWhenUnitIsUnfortified = new TheoryData
            <IUnit>
        {
            /* An unfortified unit has defensive strength of 3, when it normally has defensive strength of 3. */
            DefensiveUnit(3),
            //
            /* An unfortified unit has defensive strength of 4, when it normally has defensive strength of 4. */
            DefensiveUnit(4),
        };

        [Theory]
        [MemberData(nameof(DefenceIsNormalWhenUnitIsUnfortified))]
        public void Defence_IsNormal_WhenUnitIsUnfortified(IUnit decoratedUnit)
        {
            // :::: ARRANGE ::::
            var fortifiableUnit = new FortificationAction(decoratedUnit);

            // :::: ACT ::::
            var actualDefence = fortifiableUnit.Defence;

            // :::: ASSERT ::::
            var expectedDefence = decoratedUnit.Defence;
            actualDefence.Should().Be(expectedDefence);
        }

        #endregion

        #region Re-unfortified units have normal defensive strength.

        public static readonly TheoryData DefenceIsNormalWhenUnitIsReUnfortified = new TheoryData
            <IUnit>
        {
            /* A re-unfortified unit has defensive strength of 1, when it normally has defensive strength of 1. */
            DefensiveUnit(1),
            //
            /* A re-unfortified unit has defensive strength of 2, when it normally has defensive strength of 2. */
            DefensiveUnit(2),
        };

        [Theory]
        [MemberData(nameof(DefenceIsNormalWhenUnitIsReUnfortified))]
        public void Defence_IsNormal_WhenUnitIsReUnfortified(IUnit decoratedUnit)
        {
            // :::: ARRANGE ::::
            var fortifiableUnit = new FortificationAction(decoratedUnit);
            fortifiableUnit.PerformAction();
            fortifiableUnit.PerformAction();

            // :::: ACT ::::
            var actualDefence = fortifiableUnit.Defence;

            // :::: ASSERT ::::
            var expectedDefence = decoratedUnit.Defence;
            actualDefence.Should().Be(expectedDefence);
        }

        #endregion

        #region Fortified units have no remaining movement.

        public static readonly TheoryData RemainingMovementIsZeroWhenUnitIsFortified = new TheoryData
            <IUnit>
        {
            /* A fortified unit has no remaining movement, when it normally has remaining movement of 2. */
            MovableUnit(2),
            //
            /* A fortified unit has no remaining movement, when it normally has remaining movement of 3. */
            MovableUnit(3),
        };

        [Theory]
        [MemberData(nameof(RemainingMovementIsZeroWhenUnitIsFortified))]
        public void RemainingMovement_IsZero_WhenUnitIsFortified(IUnit decoratedUnit)
        {
            // :::: ARRANGE ::::
            var fortifiableUnit = new FortificationAction(decoratedUnit);
            fortifiableUnit.PerformAction();

            // :::: ACT ::::
            var actualRemainingMovement = fortifiableUnit.RemainingMovement;

            // :::: ASSERT ::::
            const int expectedRemainingMovement = 0;
            actualRemainingMovement.Should().Be(expectedRemainingMovement);
        }

        #endregion

        #region Unfortified units have normal remaining movement.

        public static readonly TheoryData RemainingMovementIsNormalWhenUnitIsUnfortified = new TheoryData
            <IUnit>
        {
            /* An unfortified unit has remaining movement of 7, when it normally has remaining movement of 7. */
            MovableUnit(7),
            //
            /* An unfortified unit has remaining movement of 8, when it normally has remaining movement of 8. */
            MovableUnit(8),
        };

        [Theory]
        [MemberData(nameof(RemainingMovementIsNormalWhenUnitIsUnfortified))]
        public void RemainingMovement_IsNormal_WhenUnitIsUnfortified(IUnit decoratedUnit)
        {
            // :::: ARRANGE ::::
            var fortifiableUnit = new FortificationAction(decoratedUnit);

            // :::: ACT ::::
            var actualRemainingMovement = fortifiableUnit.RemainingMovement;

            // :::: ASSERT ::::
            var expectedRemainingMovement = decoratedUnit.RemainingMovement;
            actualRemainingMovement.Should().Be(expectedRemainingMovement);
        }

        #endregion

        #region Re-unfortified units have normal remaining movement.

        public static readonly TheoryData RemainingMovementIsNormalWhenUnitIsReUnfortified = new TheoryData
            <IUnit>
        {
            /* A re-unfortified unit has remaining movement of 4, when it normally has remaining movement of 4. */
            MovableUnit(4),
            //
            /* A re-unfortified unit has remaining movement of 5, when it normally has remaining movement of 5. */
            MovableUnit(5),

        };

        [Theory]
        [MemberData(nameof(RemainingMovementIsNormalWhenUnitIsReUnfortified))]
        public void RemainingMovement_IsNormal_WhenUnitIsReUnfortified(IUnit decoratedUnit)
        {
            // :::: ARRANGE ::::
            var fortifiableUnit = new FortificationAction(decoratedUnit);
            fortifiableUnit.PerformAction();
            fortifiableUnit.PerformAction();

            // :::: ACT ::::
            var actualRemainingMovement = fortifiableUnit.RemainingMovement;

            // :::: ASSERT ::::
            var expectedRemainingMovement = decoratedUnit.RemainingMovement;
            actualRemainingMovement.Should().Be(expectedRemainingMovement);
        }

        #endregion
    }
}
