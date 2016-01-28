using ExtenCiv.Players;
using ExtenCiv.Tests.Utilities.Extensions;
using ExtenCiv.Tests.Utilities.Stubs;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Movement;
using ExtenCiv.Units.Types;
using ExtenCiv.WorldMaps.Tiles;
using ExtenCiv.WorldMaps.Tiles.Abstractions;
using FakeItEasy;
using Xunit;

namespace ExtenCiv.Tests.Unit.Units.Movement
{
    public sealed class TestNoFriendlyUnitStacking
    {
        /// <summary>
        ///     Moving to a tile that is not occupied by a friendly unit is allowed.
        /// </summary>
        /// <param name="owner">The owner of the unit to move.</param>
        /// <param name="destination">The destination tile.</param>
        /// <param name="unitsAtDestination">The units at the destination tile.</param>
        [Theory]
        [MemberData(nameof(WhenMovingToAnEmptyTile))]
        [MemberData(nameof(WhenMovingToATileWithAnOpponentUnit))]
        public void MoveTo_IsForwarded_BecauseTheTileIsNotOccupiedByAFriendlyUnit(Player owner,
                                                                                  ITile destination,
                                                                                  IUnit[] unitsAtDestination)
        {
            // :::: ARRANGE ::::
            var spyUnit = A.Fake<IUnit<Archer>>();
            var stubUnits = StubWorld.Units(unitsAtDestination);
            var unit = new NoFriendlyUnitStacking<Archer>(spyUnit, stubUnits);

            A.CallTo(() => spyUnit.Owner).Returns(owner);

            // :::: ACT ::::
            unit.MoveTo(destination);

            // :::: ASSERT ::::
            A.CallTo(() => spyUnit.MoveTo(destination)).MustHaveHappened();
        }

        /// <summary>
        ///     Moving to an empty tile is allowed.
        /// </summary>
        public static TheoryData WhenMovingToAnEmptyTile => new TheoryData
            <Player, ITile, IUnit[]>
        {
            /* A Red Archer can move to an empty tile at (3, 1). */
            { Red, To(3, 1), NoUnits },
            //
            /* A Blue Legion can move to an empty tile at (2, 1). */
            { Blue, To(2, 1), NoUnits },
        };

        /// <summary>
        ///     Moving to a tile that is occupied by an opponent unit is allowed.
        /// </summary>
        public static TheoryData WhenMovingToATileWithAnOpponentUnit => new TheoryData
            <Player, ITile, IUnit[]>
        {
            /* A Red Archer can move to a tile at (3, 1) that has a Blue Archer. */
            { Red, To(3, 1), new IUnit[] { Blue.Archer().At(3, 1) } },
            //
            /* A Blue Legion can move to a tile at (2, 1) that has a Red Legion. */
            { Blue, To(2, 1), new IUnit[] { Red.Legion().At(2, 1) } },
        };

        /// <summary>
        ///     Moving to a tile that is occupied by a friendly unit is not allowed.
        /// </summary>
        /// <param name="owner">The owner of the unit to move.</param>
        /// <param name="destination">The destination tile.</param>
        /// <param name="unitsAtDestination">The units at the destination tile.</param>
        [Theory]
        [MemberData(nameof(WhenMovingToATileWithAFriendlyUnit))]
        public void MoveTo_IsForwarded_BecauseTheTileIsOccupiedByAFriendlyUnit(Player owner,
                                                                               ITile destination,
                                                                               IUnit[] unitsAtDestination)
        {
            // :::: ARRANGE ::::
            var spyUnit = A.Fake<IUnit<Archer>>();
            var stubUnits = StubWorld.Units(unitsAtDestination);
            var unit = new NoFriendlyUnitStacking<Archer>(spyUnit, stubUnits);

            A.CallTo(() => spyUnit.Owner).Returns(owner);

            // :::: ACT ::::
            unit.MoveTo(destination);

            // :::: ASSERT ::::
            A.CallTo(() => spyUnit.MoveTo(destination)).MustNotHaveHappened();
        }

        /// <summary>
        ///     Moving to a tile that is occupied by a friendly unit is not allowed.
        /// </summary>
        public static TheoryData WhenMovingToATileWithAFriendlyUnit => new TheoryData
            <Player, ITile, IUnit[]>
        {
            /* A Red Archer cannot move to a tile at (3, 1) that has a Red Legion. */
            { Red, To(3, 1), new IUnit[] { Red.Legion().At(3, 1) } },
            //
            /* A Blue Legion cannot move to a tile at (2, 1) that has a Blue Archer. */
            { Blue, To(2, 1), new IUnit[] { Blue.Archer().At(2, 1) } },
        };

        #region HELPERS: Shortcuts

        private static Player Red => new Player("Red");
        private static Player Blue => new Player("Blue");

        private static IUnit[] NoUnits => new IUnit[] { };

        private static ITile To(int row, int column) => new SquareTile(row, column);

        #endregion
    }
}
