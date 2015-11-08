using Autofac.Extras.FakeItEasy;
using ExtenCiv.Players;
using ExtenCiv.Winners;
using ExtenCiv.WorldAges;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Autofac.Tests.Winners
{
    public sealed class TestRedWinsIn3000Bce
    {
        private const string Red = "Red";

        [Theory]
        //
        /* DONE Winner is Player.Nobody in 3100 BCE. */
        [InlineData(-3100, null)]
        //
        /* DONE Winner is Red in 3000 BCE. */
        [InlineData(-3000, Red)]
        //
        /* DONE Winner is Red in 2900 BCE. */
        [InlineData(-2900, Red)]
        //
        public void Winner_IsRed_WhenWorldAgeIs3000BceOrLater(int worldAge, string expectedNameOfWinner)
        {
            using (var fake = new AutoFake())
            {
                // :::: ARRANGE ::::
                A.CallTo(() => fake.Resolve<IWorldAgeStrategy>().WorldAge).Returns(worldAge);
                var redWinsIn3000Bce = fake.Resolve<RedWinsIn3000Bce>();

                // :::: ACT ::::
                var actualWinner = redWinsIn3000Bce.Winner;

                // :::: ASSERT ::::
                actualWinner.Should().Be(Player.For(expectedNameOfWinner));
            }
        }
    }
}
