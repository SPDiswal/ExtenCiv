using System.Collections.Generic;
using ExtenCiv.Common.Utilities.Theories;
using ExtenCiv.Players;
using ExtenCiv.Resolvers;
using ExtenCiv.Winners;
using ExtenCiv.WorldAges;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Winners
{
    public sealed class TestRedWinsIn3000Bce
    {
        private const string Red = "Red";

        public static readonly IEnumerable<object> WinnerIsRedWhenWorldAgeIs3000BceOrLater = new ExtenCivTheory
        {
            /* DONE Winner is Player.Nobody in 3100 BCE. */
            { -3100, Player.Nobody },
            //
            /* DONE Winner is Red in 3000 BCE. */
            { -3000, Player.For(Red) },
            //
            /* DONE Winner is Red in 2900 BCE. */
            { -2900, Player.For(Red) }
        };

        [Theory]
        [MemberData(nameof(WinnerIsRedWhenWorldAgeIs3000BceOrLater))]
        public void Winner_IsRed_WhenWorldAgeIs3000BceOrLater(IResolver resolver,
                                                              int fixedWorldAge,
                                                              Player expectedWinner)
        {
            // :::: ARRANGE ::::
            var stubWorldAgeStrategy = A.Fake<IWorldAgeStrategy>();
            A.CallTo(() => stubWorldAgeStrategy.WorldAge).Returns(fixedWorldAge);

            resolver.Inject(stubWorldAgeStrategy);
            var redWinsIn3000Bce = resolver.Resolve<RedWinsIn3000Bce>();

            // :::: ACT ::::
            var actualWinner = redWinsIn3000Bce.Winner;

            // :::: ASSERT ::::
            actualWinner.Should().Be(expectedWinner);
        }
    }
}
