using ExtenCiv.Terrains.Abstractions;
using ExtenCiv.Terrains.Types;
using ExtenCiv.Tests.Utilities.Extensions;
using ExtenCiv.Tests.Utilities.Stubs;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Movement;
using ExtenCiv.Units.Types;
using FakeItEasy;
using Xunit;

namespace ExtenCiv.Tests.Unit.Units.Movement
{
    public sealed class TestNoEntranceToImpassableTerrain
    {
        /// <summary>
        ///     Moving to passable terrain is allowed.
        /// </summary>
        /// <param name="terrain">The terrain at the destination tile.</param>
        [Theory]
        [MemberData(nameof(WhenMovingToForests))]
        [MemberData(nameof(WhenMovingToHills))]
        [MemberData(nameof(WhenMovingToPlains))]
        public void MoveTo_IsForwarded_BecauseTheTerrainIsPassable(ITerrain terrain)
        {
            // :::: ARRANGE ::::
            var spyUnit = A.Fake<IUnit<Archer>>();
            var stubTerrains = StubWorld.Terrains(new[] { terrain });
            var unit = new NoEntranceToImpassableTerrain<Archer>(spyUnit, stubTerrains);

            // :::: ACT ::::
            var destination = terrain.Location;
            unit.MoveTo(destination);

            // :::: ASSERT ::::
            A.CallTo(() => spyUnit.MoveTo(destination)).MustHaveHappened();
        }

        /// <summary>
        ///     Moving to tiles with Forests is allowed.
        /// </summary>
        public static TheoryData WhenMovingToForests => new TheoryData
            <ITerrain>
        {
            /* A unit can move to Forests at (3, 1). */
            Forests.At(3, 1),
            //
            /* A unit can move to Forests at (2, 1). */
            Forests.At(2, 1),
        };

        /// <summary>
        ///     Moving to tiles with Hills is allowed.
        /// </summary>
        public static TheoryData WhenMovingToHills => new TheoryData
            <ITerrain>
        {
            /* A unit can move to Hills at (2, 2). */
            Hills.At(2, 2),
            //
            /* A unit can move to Hills at (3, 4). */
            Hills.At(3, 4),
        };

        /// <summary>
        ///     Moving to tiles with Plains is allowed.
        /// </summary>
        public static TheoryData WhenMovingToPlains => new TheoryData
            <ITerrain>
        {
            /* A unit can move to Plains at (1, 0). */
            Plains.At(1, 0),
            //
            /* A unit can move to Plains at (3, 2). */
            Plains.At(3, 2),
        };

        /// <summary>
        ///     Moving to impassable terrain is not allowed.
        /// </summary>
        /// <param name="terrain">The terrain at the destination tile.</param>
        [Theory]
        [MemberData(nameof(WhenMovingToMountains))]
        [MemberData(nameof(WhenMovingToOceans))]
        public void MoveTo_IsForwarded_BecauseTheTerrainIsImpassable(ITerrain terrain)
        {
            // :::: ARRANGE ::::
            var spyUnit = A.Fake<IUnit<Archer>>();
            var stubTerrains = StubWorld.Terrains(new[] { terrain });
            var unit = new NoEntranceToImpassableTerrain<Archer>(spyUnit, stubTerrains);

            // :::: ACT ::::
            var destination = terrain.Location;
            unit.MoveTo(destination);

            // :::: ASSERT ::::
            A.CallTo(() => spyUnit.MoveTo(destination)).MustNotHaveHappened();
        }

        /// <summary>
        ///     Moving to tiles with Mountains is not allowed.
        /// </summary>
        public static TheoryData WhenMovingToMountains => new TheoryData
            <ITerrain>
        {
            /* A unit cannot move to Mountains at (3, 3). */
            Mountains.At(3, 3),
            //
            /* A unit cannot move to Mountains at (1, 2). */
            Mountains.At(1, 2),
        };

        /// <summary>
        ///     Moving to tiles with Oceans is not allowed.
        /// </summary>
        public static TheoryData WhenMovingToOceans => new TheoryData
            <ITerrain>
        {
            /* A unit cannot move to Oceans at (2, 3). */
            Oceans.At(2, 3),
            //
            /* A unit cannot move to Oceans at (0, 1). */
            Oceans.At(0, 1),
        };

        #region HELPERS: Shortcuts

        private static ITerrain Forests => new Forests();
        private static ITerrain Hills => new Hills();
        private static ITerrain Mountains => new Mountains();
        private static ITerrain Oceans => new Oceans();
        private static ITerrain Plains => new Plains();

        #endregion
    }
}
