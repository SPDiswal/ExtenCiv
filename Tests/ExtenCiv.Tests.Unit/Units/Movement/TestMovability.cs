using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Movement;
using ExtenCiv.Units.Types;
using ExtenCiv.WorldMaps.Tiles;
using ExtenCiv.WorldMaps.Tiles.Abstractions;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.Units.Movement
{
    public sealed class TestMovability
    {
        /// <summary>
        ///     The location of a unit is updated after it has moved to its destination.
        /// </summary>
        /// <param name="unit">The unit to move.</param>
        /// <param name="destination">The destination tile.</param>
        [Theory]
        [MemberData(nameof(WhenAUnitMovesToADestination))]
        public void Move_UpdatesTheLocationOfTheUnitAccordingly(IUnit<Archer> unit, ITile destination)
        {
            // :::: ARRANGE ::::
            var movableUnit = new Movability<Archer>(unit);

            // :::: ACT ::::
            movableUnit.MoveTo(destination);

            // :::: ASSERT ::::
            unit.Location.Should().Be(destination);
        }

        /// <summary>
        ///     When a unit moves to a destination, its location is updated accordingly.
        /// </summary>
        public static TheoryData WhenAUnitMovesToADestination => new TheoryData
            <IUnit<Archer>, ITile>
        {
            /* An Archer moves to (3, 1). */
            { Archer, To(3, 1) },
            //
            /* An Archer moves to (2, 1). */
            { Archer, To(2, 1) },
        };

        #region HELPERS: Shortcuts

        private static IUnit<Archer> Archer => new Archer();

        private static ITile To(int row, int column) => new SquareTile(row, column);

        #endregion
    }
}
