using ExtenCiv.Tests.Utilities;
using ExtenCiv.WorldAges;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.WorldAges
{
    public sealed class TestLinearWorldAge
    {
        [Theory]
        //
        /* DONE World age is 4000 BCE from start. */
        [InlineData(0, -4000)]
        //
        /* DONE World age is 3900 BCE after advancing one round. */
        [InlineData(1, -3900)]
        //
        /* DONE World age is 3800 BCE after advancing two rounds. */
        [InlineData(2, -3800)]
        //
        public void WorldAge_AdvancesBy100Years(int roundsToAdvance, int expectedWorldAge)
        {
            // :::: ARRANGE ::::
            var linear = new LinearWorldAge();
            roundsToAdvance.Times(() => linear.AdvanceWorldAge());

            // :::: ACT ::::
            var actualWorldAge = linear.WorldAge;

            // :::: ASSERT ::::
            actualWorldAge.Should().Be(expectedWorldAge);
        }
    }
}
