using ExtenCiv.Tests.Utilities.Extensions;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Actions;
using ExtenCiv.Units.Types;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.Units.Actions
{
    public sealed class TestFortifiableAction
    {
        /// <summary>
        ///     Fortified units have double defensive strength.
        /// </summary>
        /// <param name="unit">The unit to fortify.</param>
        [Theory]
        [MemberData(nameof(WhenTheUnitCanBeFortified))]
        public void Defence_IsDoubled_WhenUnitIsFortified(IUnit<Archer> unit)
        {
            // :::: ARRANGE ::::
            var fortifiableUnit = new FortificationAction<Archer>(unit);
            fortifiableUnit.PerformAction();

            // :::: ACT ::::
            var actualDefence = fortifiableUnit.Defence;

            // :::: ASSERT ::::
            actualDefence.Should().Be(2 * unit.Defence);
        }

        /// <summary>
        ///     Unfortified units have normal defensive strength.
        /// </summary>
        /// <param name="unit">The unit to fortify.</param>
        [Theory]
        [MemberData(nameof(WhenTheUnitCanBeFortified))]
        public void Defence_IsNormal_WhenUnitIsUnfortified(IUnit<Archer> unit)
        {
            // :::: ARRANGE ::::
            var fortifiableUnit = new FortificationAction<Archer>(unit);

            // :::: ACT ::::
            var actualDefence = fortifiableUnit.Defence;

            // :::: ASSERT ::::
            actualDefence.Should().Be(unit.Defence);
        }

        /// <summary>
        ///     Units that have been fortified and then unfortified have normal defensive strength.
        /// </summary>
        /// <param name="unit">The unit to fortify.</param>
        [Theory]
        [MemberData(nameof(WhenTheUnitCanBeFortified))]
        public void Defence_IsNormal_WhenUnitIsUnfortifiedAfterBeingFortified(IUnit<Archer> unit)
        {
            // :::: ARRANGE ::::
            var fortifiableUnit = new FortificationAction<Archer>(unit);
            fortifiableUnit.PerformAction();
            fortifiableUnit.PerformAction();

            // :::: ACT ::::
            var actualDefence = fortifiableUnit.Defence;

            // :::: ASSERT ::::
            actualDefence.Should().Be(unit.Defence);
        }

        /// <summary>
        ///     Fortified units have no remaining moves.
        /// </summary>
        /// <param name="unit">The unit to fortify.</param>
        [Theory]
        [MemberData(nameof(WhenTheUnitCanBeFortified))]
        public void RemainingMoves_IsZero_WhenUnitIsFortified(IUnit<Archer> unit)
        {
            // :::: ARRANGE ::::
            var fortifiableUnit = new FortificationAction<Archer>(unit);
            fortifiableUnit.PerformAction();

            // :::: ACT ::::
            var actualRemainingMoves = fortifiableUnit.RemainingMoves;

            // :::: ASSERT ::::
            actualRemainingMoves.Should().Be(0);
        }

        /// <summary>
        ///     Unfortified units have normal remaining moves.
        /// </summary>
        /// <param name="unit">The unit to fortify.</param>
        [Theory]
        [MemberData(nameof(WhenTheUnitCanBeFortified))]
        public void RemainingMoves_IsNormal_WhenUnitIsUnfortified(IUnit<Archer> unit)
        {
            // :::: ARRANGE ::::
            var fortifiableUnit = new FortificationAction<Archer>(unit);

            // :::: ACT ::::
            var actualRemainingMovement = fortifiableUnit.RemainingMoves;

            // :::: ASSERT ::::
            actualRemainingMovement.Should().Be(unit.RemainingMoves);
        }

        /// <summary>
        ///     Units that have been fortified and then unfortified have normal remaining moves.
        /// </summary>
        /// <param name="unit">The unit to fortify.</param>
        [Theory]
        [MemberData(nameof(WhenTheUnitCanBeFortified))]
        public void RemainingMoves_IsNormal_WhenUnitIsUnfortifiedAfterBeingFortified(IUnit<Archer> unit)
        {
            // :::: ARRANGE ::::
            var fortifiableUnit = new FortificationAction<Archer>(unit);
            fortifiableUnit.PerformAction();
            fortifiableUnit.PerformAction();

            // :::: ACT ::::
            var actualRemainingMovement = fortifiableUnit.RemainingMoves;

            // :::: ASSERT ::::
            actualRemainingMovement.Should().Be(unit.RemainingMoves);
        }

        /// <summary>
        ///     When the unit is fortified, it has double defensive strength and no remaining moves.
        /// </summary>
        public static TheoryData WhenTheUnitCanBeFortified => new TheoryData
            <IUnit<Archer>>
        {
            /* An Archer has defensive strength of 2 and one remaining move. */
            Archer.WithDefenceOf(2).ThatCanMove(1),
            //
            /* An Archer has defensive strength of 5 and two remaining moves. */
            Archer.WithDefenceOf(5).ThatCanMove(2),
        };

        #region HELPERS: Shortcuts

        private static IUnit<Archer> Archer => new Archer();

        #endregion
    }
}
