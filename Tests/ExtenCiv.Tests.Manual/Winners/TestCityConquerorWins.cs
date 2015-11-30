using System.Collections.Generic;
using ExtenCiv.Cities;
using ExtenCiv.GameBoards;
using ExtenCiv.Players;
using ExtenCiv.Winners;
using FakeItEasy;
using FluentAssertions;
using Xunit;
using static ExtenCiv.Players.Player;

namespace ExtenCiv.Tests.Winners
{
    public sealed class TestCityConquerorWins
    {
        private static readonly Player Red = new Player("Red");
        private static readonly Player Blue = new Player("Blue");

        private static ICity RedCity => StubCity(Red);
        private static ICity BlueCity => StubCity(Blue);

        private static ICity StubCity(Player owner)
        {
            var stubCity = A.Fake<ICity>();
            A.CallTo(() => stubCity.Owner).Returns(owner);
            A.CallTo(() => stubCity.ToString()).Returns($"{owner} City");
            return stubCity;
        }

        public static readonly TheoryData WinnerIsPlayerWhoOwnsAllCities = new TheoryData
            <ICity, ICity, ICity, Player>
        {
            /* Winner is Red when Red owns three cities and Blue owns no cities. */
            { RedCity, RedCity, RedCity, Red },
            //
            /* Winner is Nobody when Red owns two cities and Blue owns one city. */
            { RedCity, RedCity, BlueCity, Nobody },
            //
            /* Winner is Nobody when Red owns one city and Blue owns two cities. */
            { RedCity, BlueCity, BlueCity, Nobody },
            //
            /* Winner is Blue when Red owns no cities and Blue owns three cities. */
            { BlueCity, BlueCity, BlueCity, Blue },
        };

        [Theory]
        [MemberData(nameof(WinnerIsPlayerWhoOwnsAllCities))]
        public void Winner_IsPlayerWhoOwnsAllCities(ICity firstCity, ICity secondCity, ICity thirdCity,
                                                    Player expectedWinner)
        {
            // :::: ARRANGE ::::
            var cities = new Dictionary<Position, ICity>
            {
                [new Position(0, 0)] = firstCity,
                [new Position(1, 1)] = secondCity,
                [new Position(2, 2)] = thirdCity,
            };

            var stubGameBoardStrategy = A.Fake<IGameBoardStrategy>();
            A.CallTo(() => stubGameBoardStrategy.Cities).Returns(cities);

            var cityConquerorWins = new CityConquerorWins(stubGameBoardStrategy);

            // :::: ACT ::::
            var actualWinner = cityConquerorWins.Winner;

            // :::: ASSERT ::::
            actualWinner.Should().Be(expectedWinner);
        }
    }
}
