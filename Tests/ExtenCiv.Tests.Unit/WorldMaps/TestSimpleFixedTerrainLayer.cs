using System;
using System.Linq;
using ExtenCiv.Players;
using ExtenCiv.Terrains.Types;
using ExtenCiv.Tests.Utilities.Stubs;
using ExtenCiv.WorldMaps;
using ExtenCiv.WorldMaps.Tiles;
using ExtenCiv.WorldMaps.Tiles.Abstractions;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.WorldMaps
{
    public sealed class TestSimpleFixedTerrainLayer
    {
        /// <summary>
        ///     There are exactly 256 terrains in the terrain layer.
        /// </summary>
        [Fact]
        public void TerrainLayer_ContainsExactly256Terrains()
        {
            // :::: ARRANGE and ACT ::::
            var simpleFixedTerrainLayer = new SimpleFixedTerrainLayer(StubWorld.NoTerrains,
                                                                      StubFactories.SimpleHillsFactory,
                                                                      StubFactories.SimpleMountainsFactory,
                                                                      StubFactories.SimpleOceansFactory,
                                                                      StubFactories.SimplePlainsFactory);

            // :::: ASSERT ::::
            simpleFixedTerrainLayer.Terrains.Should().HaveCount(256);
        }

        /// <summary>
        ///     There are three tiles with Oceans, Hills and Mountains, respectively.
        /// </summary>
        /// <param name="location">The terrain location.</param>
        /// <param name="expectedType">The expected terrain type.</param>
        [Theory]
        [MemberData(nameof(ForTileWithOceans))]
        [MemberData(nameof(ForTileWithHills))]
        [MemberData(nameof(ForTileWithMountains))]
        public void TerrainLayer_ContainsSingleTileWithParticularTerrain(ITile location, Type expectedType)
        {
            // :::: ARRANGE ::::
            var simpleFixedTerrainLayer = new SimpleFixedTerrainLayer(StubWorld.NoTerrains,
                                                                      StubFactories.SimpleHillsFactory,
                                                                      StubFactories.SimpleMountainsFactory,
                                                                      StubFactories.SimpleOceansFactory,
                                                                      StubFactories.SimplePlainsFactory);

            // :::: ACT ::::
            var actualTerrain = simpleFixedTerrainLayer.Terrains.Single(terrain => terrain.Location.Equals(location));

            // :::: ASSERT ::::
            actualTerrain.Should().BeOfType(expectedType);
        }

        /// <summary>
        ///     There are Oceans at (1, 0).
        /// </summary>
        public static TheoryData ForTileWithOceans => new TheoryData
            <ITile, Type>
        {
            /* There are Oceans at (1, 0). */
            { Location(1, 0), typeof (Oceans) },
        };

        /// <summary>
        ///     There are Hills at (0, 1).
        /// </summary>
        public static TheoryData ForTileWithHills => new TheoryData
            <ITile, Type>
        {
            /* There are Hills at (0, 1). */
            { Location(0, 1), typeof (Hills) },
        };

        /// <summary>
        ///     There are Mountains at (2, 2).
        /// </summary>
        public static TheoryData ForTileWithMountains => new TheoryData
            <ITile, Type>
        {
            /* There are Mountains at (2, 2). */
            { Location(2, 2), typeof (Mountains) },
        };

        /// <summary>
        ///     There are exactly 253 Plains in the terrain layer.
        /// </summary>
        [Fact]
        public void TerrainLayer_ContainsExactly253Plains()
        {
            // :::: ARRANGE and ACT ::::
            var simpleFixedTerrainLayer = new SimpleFixedTerrainLayer(StubWorld.NoTerrains,
                                                                      StubFactories.SimpleHillsFactory,
                                                                      StubFactories.SimpleMountainsFactory,
                                                                      StubFactories.SimpleOceansFactory,
                                                                      StubFactories.SimplePlainsFactory);

            // :::: ASSERT ::::
            simpleFixedTerrainLayer.Terrains.OfType<Plains>().Should().HaveCount(253);
        }

        #region HELPERS: Shortcuts

        private static Player Red => new Player("Red");
        private static Player Blue => new Player("Blue");

        private static ITile Location(int row, int column) => new SquareTile(row, column);

        #endregion
    }
}
