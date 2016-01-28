using System;
using System.Collections.Generic;
using System.Linq;
using ExtenCiv.Players;
using ExtenCiv.Tests.Utilities.Stubs;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Types;
using ExtenCiv.Units.Utilities;
using ExtenCiv.WorldMaps;
using ExtenCiv.WorldMaps.Tiles;
using ExtenCiv.WorldMaps.Tiles.Abstractions;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.WorldMaps
{
    public sealed class TestSimpleFixedUnitLayer
    {
        /// <summary>
        ///     There are exactly three units in the unit layer.
        /// </summary>
        [Fact]
        public void UnitLayer_ContainsExactlyThreeUnits()
        {
            // :::: ARRANGE and ACT ::::
            var stubArcherFactory = StubFactories.SimpleArcherFactory;
            var stubLegionFactory = StubFactories.SimpleLegionFactory;
            var stubSettlerFactory = StubFactories.SimpleSettlerFactory;
            var simpleFixedUnitLayer = new SimpleFixedUnitLayer(new HashSet<IUnit>(new UnitEqualityComparer()),
                                                                stubArcherFactory, stubLegionFactory, stubSettlerFactory);

            // :::: ASSERT ::::
            simpleFixedUnitLayer.Units.Should().HaveCount(3);
        }

        /// <summary>
        ///     Initially, there is a Red Archer, a Blue Settler and a Red Settler.
        /// </summary>
        /// <param name="location">The unit location.</param>
        /// <param name="expectedOwner">The expected unit owner.</param>
        /// <param name="expectedType">The expected unit type.</param>
        [Theory]
        [MemberData(nameof(AtGameStart))]
        public void UnitLayer_ContainsARedArcherAndABlueLegionAndARedSettler(ITile location,
                                                                             Player expectedOwner,
                                                                             Type expectedType)
        {
            // :::: ARRANGE ::::
            var stubArcherFactory = StubFactories.SimpleArcherFactory;
            var stubLegionFactory = StubFactories.SimpleLegionFactory;
            var stubSettlerFactory = StubFactories.SimpleSettlerFactory;
            var simpleFixedUnitLayer = new SimpleFixedUnitLayer(new HashSet<IUnit>(new UnitEqualityComparer()),
                                                                stubArcherFactory, stubLegionFactory, stubSettlerFactory);

            // :::: ACT ::::
            var actualUnit = simpleFixedUnitLayer.Units.Single(unit => unit.Location.Equals(location));

            // :::: ASSERT ::::
            actualUnit.Should().BeOfType(expectedType);
            actualUnit.Owner.Should().Be(expectedOwner);
        }

        /// <summary>
        ///     Initially, there is a Red Archer at (2, 0), a Blue Legion at (3, 2) and a Red Settler at (4, 3).
        /// </summary>
        public static TheoryData AtGameStart => new TheoryData
            <ITile, Player, Type>
        {
            /* There is a Red Archer at (2, 0). */
            { Location(2, 0), Red, typeof (Archer) },
            //
            /* There is a Blue Legion at (3, 2). */
            { Location(3, 2), Blue, typeof (Legion) },
            //
            /* There is a Red Settler at (4, 3). */
            { Location(4, 3), Red, typeof (Settler) },
        };

        #region HELPERS: Shortcuts

        private static Player Red => new Player("Red");
        private static Player Blue => new Player("Blue");

        private static ITile Location(int row, int column) => new SquareTile(row, column);

        #endregion
    }
}
