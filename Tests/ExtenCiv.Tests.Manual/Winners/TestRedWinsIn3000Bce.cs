using ExtenCiv.Players;
using ExtenCiv.Winners;
using ExtenCiv.WorldAges;
using FakeItEasy;
using FluentAssertions;
using Xunit;
using static ExtenCiv.Players.Player;

namespace ExtenCiv.Tests.Winners
{
    public sealed class TestRedWinsIn3000Bce
    {
        private static readonly Player Red = new Player("Red");

        public static readonly TheoryData WinnerIsRedWhenWorldAgeIs3000BceOrLater = new TheoryData
            <int, Player>
        {
            /* Winner is Nobody in 3100 BCE. */
            { -3100, Nobody },
            //
            /* Winner is Red in 3000 BCE. */
            { -3000, Red },
            //
            /* Winner is Red in 2900 BCE. */
            { -2900, Red },
        };

        [Theory]
        [MemberData(nameof(WinnerIsRedWhenWorldAgeIs3000BceOrLater))]
        public void Winner_IsRed_WhenWorldAgeIs3000BceOrLater(int fixedWorldAge, Player expectedWinner)
        {
            // :::: ARRANGE ::::
            var stubWorldAgeStrategy = A.Fake<IWorldAgeStrategy>();
            A.CallTo(() => stubWorldAgeStrategy.WorldAge).Returns(fixedWorldAge);

            var redWinsIn3000Bce = new RedWinsIn3000Bce(stubWorldAgeStrategy);

            // :::: ACT ::::
            var actualWinner = redWinsIn3000Bce.Winner;

            // :::: ASSERT ::::
            actualWinner.Should().Be(expectedWinner);
        }
    }
}
