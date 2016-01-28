using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Players;
using ExtenCiv.Tests.Utilities.Extensions;
using ExtenCiv.Tests.Utilities.Stubs;
using ExtenCiv.Winners;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.Winners
{
    public sealed class TestCityConquerorWins
    {
        /// <summary>
        ///     The winner is the player that owns all cities.
        /// </summary>
        /// <param name="cities">The cities.</param>
        [Theory]
        [MemberData(nameof(WhenASingleOwnsBothCities))]
        [MemberData(nameof(WhenASinglePlayerOwnsAllThreeCities))]
        public void Winner_IsThePlayerWhoOwnsAllCities(ICity[] cities)
        {
            // :::: ARRANGE ::::
            var stubCities = StubWorld.Cities(cities);
            var cityConquerorWins = new CityConquerorWins(stubCities);

            // :::: ACT ::::
            var actualWinner = cityConquerorWins.Winner;

            // :::: ASSERT ::::
            var expectedWinner = cities[0].Owner;
            actualWinner.Should().Be(expectedWinner);
        }

        /// <summary>
        ///     When a single player owns both cities, he has won the game.
        /// </summary>
        public static TheoryData WhenASingleOwnsBothCities => new TheoryData
            <ICity[]>
        {
            /* Red owns two cities. */
            new[] { Red.City(), Red.City() },
            //
            /* Blue owns two cities. */
            new[] { Blue.City(), Blue.City() },
        };

        /// <summary>
        ///     When a single player owns all three cities, he has won the game.
        /// </summary>
        public static TheoryData WhenASinglePlayerOwnsAllThreeCities => new TheoryData
            <ICity[]>
        {
            /* Red owns three cities. */
            new[] { Red.City(), Red.City(), Red.City() },
            //
            /* Blue owns three cities. */
            new[] { Blue.City(), Blue.City(), Blue.City() },
        };

        /// <summary>
        ///     There is no winner as long as multiple players own at least one city each.
        /// </summary>
        /// <param name="cities">The cities.</param>
        [Theory]
        [MemberData(nameof(WhenBothPlayersOwnOneCityEach))]
        [MemberData(nameof(WhenOnePlayerOwnsTwoCitiesAndAnotherPlayerOwnsOneCity))]
        public void Winner_IsNobody(ICity[] cities)
        {
            // :::: ARRANGE ::::
            var stubCities = StubWorld.Cities(cities);
            var cityConquerorWins = new CityConquerorWins(stubCities);

            // :::: ACT ::::
            var actualWinner = cityConquerorWins.Winner;

            // :::: ASSERT ::::
            actualWinner.Should().Be(Player.Nobody);
        }

        /// <summary>
        ///     When both players each own a city, there is no winner yet.
        /// </summary>
        public static TheoryData WhenBothPlayersOwnOneCityEach => new TheoryData
            <ICity[]>
        {
            /* Red owns one city and Blue owns one city. */
            new[] { Red.City(), Blue.City() },
        };

        /// <summary>
        ///     When one player owns two cities and another player owns one city, there is no winner yet.
        /// </summary>
        public static TheoryData WhenOnePlayerOwnsTwoCitiesAndAnotherPlayerOwnsOneCity => new TheoryData
            <ICity[]>
        {
            /* Red owns two cities and Blue owns one city. */
            new[] { Red.City(), Red.City(), Blue.City() },
            //
            /* Red owns one city and Blue owns two cities. */
            new[] { Red.City(), Blue.City(), Blue.City() },
        };

        #region HELPERS: Shortcuts

        private static Player Red => new Player("Red");
        private static Player Blue => new Player("Blue");

        #endregion
    }
}
