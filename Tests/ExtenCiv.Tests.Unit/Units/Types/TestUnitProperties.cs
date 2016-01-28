using System;
using System.Linq.Expressions;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Types;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.Units.Types
{
    public sealed class TestUnitProperties
    {
        /// <summary>
        ///     Properties of units return the values for their specific unit types.
        /// </summary>
        /// <param name="unit">The unit with the properties being inspected.</param>
        /// <param name="property">A closure of the property to inspect.</param>
        /// <param name="expectedValue">The expected value of the property.</param>
        [Theory]
        [MemberData(nameof(WhenItIsAnArcher))]
        [MemberData(nameof(WhenItIsAChariot))]
        [MemberData(nameof(WhenItIsALegion))]
        [MemberData(nameof(WhenItIsASettler))]
        public void Property_ReturnsTheValueForTheSpecificUnitType(IUnit unit,
                                                                   Expression<Func<IUnit, int>> property,
                                                                   int expectedValue)
        {
            // :::: ACT ::::
            var actualValue = property.Compile().Invoke(unit);

            // :::: ASSERT ::::
            actualValue.Should().Be(expectedValue);
        }

        /// <summary>
        ///     Properties of Archers return the values for Archers.
        /// </summary>
        public static TheoryData WhenItIsAnArcher => new TheoryData
            <IUnit, Expression<Func<IUnit, int>>, int>
        {
            /* Archers have an attacking strength of 2. */
            { Archer, _ => _.Attack, 2 },
            //
            /* Archers have a defensive strength of 3. */
            { Archer, _ => _.Defence, 3 },
            //
            /* Archers have 1 move per round. */
            { Archer, _ => _.TotalMoves, 1 },
            //
            /* Archers have 1 remaining move initially. */
            { Archer, _ => _.RemainingMoves, 1 },
        };

        /// <summary>
        ///     Properties of Chariots return the values for Chariots.
        /// </summary>
        public static TheoryData WhenItIsAChariot => new TheoryData
            <IUnit, Expression<Func<IUnit, int>>, int>
        {
            /* Chariots have an attacking strength of 3. */
            { Chariot, _ => _.Attack, 3 },
            //
            /* Chariots have a defensive strength of 1. */
            { Chariot, _ => _.Defence, 1 },
            //
            /* Chariots have 1 move per round. */
            { Chariot, _ => _.TotalMoves, 1 },
            //
            /* Chariots have 1 remaining move initially. */
            { Chariot, _ => _.RemainingMoves, 1 },
        };

        /// <summary>
        ///     Properties of Legions return the values for Legions.
        /// </summary>
        public static TheoryData WhenItIsALegion => new TheoryData
            <IUnit, Expression<Func<IUnit, int>>, int>
        {
            /* Legions have an attacking strength of 4. */
            { Legion, _ => _.Attack, 4 },
            //
            /* Legions have a defensive strength of 2. */
            { Legion, _ => _.Defence, 2 },
            //
            /* Legions have 1 move per round. */
            { Legion, _ => _.TotalMoves, 1 },
            //
            /* Legions have 1 remaining move initially. */
            { Legion, _ => _.RemainingMoves, 1 },
        };

        /// <summary>
        ///     Properties of Settlers return the values for Settlers.
        /// </summary>
        public static TheoryData WhenItIsASettler => new TheoryData
            <IUnit, Expression<Func<IUnit, int>>, int>
        {
            /* Settlers have an attacking strength of 0. */
            { Settler, _ => _.Attack, 0 },
            //
            /* Settlers have a defensive strength of 3. */
            { Settler, _ => _.Defence, 3 },
            //
            /* Settlers have 1 move per round. */
            { Settler, _ => _.TotalMoves, 1 },
            //
            /* Settlers have 1 remaining move initially. */
            { Settler, _ => _.RemainingMoves, 1 },
        };

        #region HELPERS: Shortcuts

        private static IUnit Archer => new Archer();
        private static IUnit Legion => new Legion();
        private static IUnit Settler => new Settler();
        private static IUnit Chariot => new Chariot();

        #endregion
    }
}
