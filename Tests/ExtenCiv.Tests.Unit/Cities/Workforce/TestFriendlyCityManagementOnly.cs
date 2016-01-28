using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Types;
using ExtenCiv.Cities.Workforce;
using ExtenCiv.Players;
using ExtenCiv.Players.Abstractions;
using ExtenCiv.Tests.Utilities.Extensions;
using FakeItEasy;
using Xunit;

namespace ExtenCiv.Tests.Unit.Cities.Workforce
{
    public sealed class TestFriendlyCityManagementOnly
    {
        /// <summary>
        ///     The player is allowed to set the production project in cities that belong to him.
        /// </summary>
        /// <param name="turnTaking">The turn-taking that specifies the current player in turn.</param>
        /// <param name="owner">The city owner.</param>
        [Theory]
        [MemberData(nameof(WhenTheCityBelongsToThePlayerInTurn))]
        public void SetProductionProject_IsForwarded_BecauseTheCityBelongsToThePlayerInTurn(ITurnTaking turnTaking,
                                                                                            Player owner)
        {
            // :::: ARRANGE ::::
            var spyCity = A.Fake<ICity<City>>();
            var managedCity = new FriendlyCityManagementOnly<City>(spyCity, turnTaking);

            A.CallTo(() => spyCity.Owner).Returns(owner);

            // :::: ACT ::::
            managedCity.ProductionProject = DummyProject;

            // :::: ASSERT ::::
            // The setter of ProductionProject has been invoked.
            A.CallTo(spyCity)
             .Where(x => x.Method.Name == $"set_{nameof(spyCity.ProductionProject)}").MustHaveHappened();
        }

        /// <summary>
        ///     When the city belongs to the player in turn, it allows him to manage it.
        /// </summary>
        public static TheoryData WhenTheCityBelongsToThePlayerInTurn => new TheoryData
            <ITurnTaking, Player>
        {
            /* Red manages a Red city. */
            { Red.InTurn(), Red },
            //
            /* Blue manages a Blue city. */
            { Blue.InTurn(), Blue },
        };

        /// <summary>
        ///     The player is not allowed to set the production project in cities that does not belong to him.
        /// </summary>
        /// <param name="turnTaking">The turn-taking that specifies the current player in turn.</param>
        /// <param name="owner">The city owner.</param>
        [Theory]
        [MemberData(nameof(WhenTheCityDoesNotBelongToThePlayerInTurn))]
        public void SetProductionProject_IsNotForwarded_BecauseTheCityBelongsToAnOpponent(ITurnTaking turnTaking,
                                                                                          Player owner)
        {
            // :::: ARRANGE ::::
            var spyCity = A.Fake<ICity<City>>();
            var managedCity = new FriendlyCityManagementOnly<City>(spyCity, turnTaking);

            A.CallTo(() => spyCity.Owner).Returns(owner);

            // :::: ACT ::::
            managedCity.ProductionProject = DummyProject;

            // :::: ASSERT ::::
            // The setter of ProductionProject has not been invoked.
            A.CallTo(spyCity)
             .Where(x => x.Method.Name == $"set_{nameof(spyCity.ProductionProject)}").MustNotHaveHappened();
        }

        /// <summary>
        ///     When the city does not belong to the player in turn, it does not allow him to manage it.
        /// </summary>
        public static TheoryData WhenTheCityDoesNotBelongToThePlayerInTurn => new TheoryData
            <ITurnTaking, Player>
        {
            /* Red manages a Blue city. */
            { Red.InTurn(), Blue },
            //
            /* Blue manages a Red city. */
            { Blue.InTurn(), Red },
        };

        #region HELPERS: Shortcuts

        private static Player Red => new Player("Red");
        private static Player Blue => new Player("Blue");

        #endregion

        #region HELPERS: Dummies

        private static IProductionProject DummyProject => A.Fake<IProductionProject>();

        #endregion
    }
}
