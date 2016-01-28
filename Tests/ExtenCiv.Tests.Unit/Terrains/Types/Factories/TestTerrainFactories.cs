namespace ExtenCiv.Tests.Unit.Terrains.Types.Factories
{
    public sealed class TestTerrainFactories
    {
        // TODO: Rewrite unit tests.

//        /// <summary>
//        ///     The factory sets the location of the newly created terrain.
//        /// </summary>
//        /// <param name="location">The location of the terrain.</param>
//        /// <param name="factory">The terrain factory.</param>
//        [Theory]
//        [MemberData(nameof(WhenCreatingTerrains))]
//        public void Create_ReturnsATerrainWithALocation(ITile location, ITerrainFactory factory)
//        {
//            // :::: ACT ::::
//            var terrain = factory.Create(location);
//
//            // :::: ASSERT ::::
//            terrain.Location.Should().Be(location);
//        }
//
//        /// <summary>
//        ///     When creating terrains, the factory sets the location of the terrains.
//        /// </summary>
//        public static TheoryData WhenCreatingTerrains => new TheoryData
//            <ITile, ITerrainFactory>
//        {
//            /* Creating Forests at (2, 0). */
//            { Location(2, 0), ForestsFactory },
//            //
//            /* Creating Oceans at (3, 2). */
//            { Location(3, 2), OceansFactory },
//        };
//
//        #region HELPERS: Shortcuts
//
//        private static ITile Location(int row, int column) => new SquareTile(row, column);
//
//        private static ITerrainFactory ForestsFactory => new TerrainFactory(() => new Forests());
//        private static ITerrainFactory OceansFactory => new TerrainFactory(() => new Oceans());
//
//        #endregion
    }
}
