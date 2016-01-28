namespace ExtenCiv.Tests.Unit.Units.Types.Factories
{
    public sealed class TestUnitFactories
    {
        // TODO: Rewrite unit tests.

//        /// <summary>
//        ///     The factory sets the location and owner of the newly created unit.
//        /// </summary>
//        /// <param name="location">The location of the unit.</param>
//        /// <param name="owner">The owner of the unit.</param>
//        /// <param name="factory">The unit factory.</param>
//        [Theory]
//        [MemberData(nameof(WhenCreatingAnArcher))]
//        [MemberData(nameof(WhenCreatingALegion))]
//        [MemberData(nameof(WhenCreatingASettler))]
//        [MemberData(nameof(WhenCreatingAChariot))]
//        public void Create_ReturnsAUnitWithALocationAndAnOwner(ITile location, Player owner, IUnitFactory factory)
//        {
//            // :::: ACT ::::
//            var unit = factory.Create(location, owner);
//
//            // :::: ASSERT ::::
//            unit.Location.Should().Be(location);
//            unit.Owner.Should().Be(owner);
//        }
//
//        /// <summary>
//        ///     When creating an archer, the factory sets the owner and location of the archer.
//        /// </summary>
//        public static TheoryData WhenCreatingAnArcher => new TheoryData
//            <ITile, Player, IUnitFactory<Archer>>
//        {
//            /* Creating a Red Archer at (2, 0). */
//            { Location(2, 0), Red, ArcherFactory },
//            //
//            /* Creating a Blue Archer at (3, 2). */
//            { Location(3, 2), Blue, ArcherFactory },
//        };
//
//        /// <summary>
//        ///     When creating a legion, the factory sets the owner and location of the legion.
//        /// </summary>
//        public static TheoryData WhenCreatingALegion => new TheoryData
//            <ITile, Player, IUnitFactory<Legion>>
//        {
//            /* Creating a Red Legion at (2, 0). */
//            { Location(2, 0), Red, LegionFactory },
//            //
//            /* Creating a Blue Legion at (3, 2). */
//            { Location(3, 2), Blue, LegionFactory },
//        };
//
//        /// <summary>
//        ///     When creating a settler, the factory sets the owner and location of the settler.
//        /// </summary>
//        public static TheoryData WhenCreatingASettler => new TheoryData
//            <ITile, Player, IUnitFactory<Settler>>
//        {
//            /* Creating a Red Settler at (2, 0). */
//            { Location(2, 0), Red, SettlerFactory },
//            //
//            /* Creating a Blue Settler at (3, 2). */
//            { Location(3, 2), Blue, SettlerFactory },
//        };
//
//        /// <summary>
//        ///     When creating a chariot, the factory sets the owner and location of the chariot.
//        /// </summary>
//        public static TheoryData WhenCreatingAChariot => new TheoryData
//            <ITile, Player, IUnitFactory<Chariot>>
//        {
//            /* Creating a Red Chariot at (2, 0). */
//            { Location(2, 0), Red, ChariotFactory },
//            //
//            /* Creating a Blue Chariot at (3, 2). */
//            { Location(3, 2), Blue, ChariotFactory },
//        };
//
//        #region HELPERS: Shortcuts
//
//        private static Player Red => new Player("Red");
//        private static Player Blue => new Player("Blue");
//
//        private static ITile Location(int row, int column) => new SquareTile(row, column);
//
//        private static IUnitFactory<Archer> ArcherFactory => new ArcherFactory(() => new Archer());
//        private static IUnitFactory<Legion> LegionFactory => new LegionFactory(() => new Legion());
//        private static IUnitFactory<Settler> SettlerFactory => new SettlerFactory(() => new Settler());
//        private static IUnitFactory<Chariot> ChariotFactory => new ChariotFactory(() => new Chariot());
//
//        #endregion
    }
}
