using ExtenCiv.Tests.Utilities;
using ExtenCiv.WorldAges;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.WorldAges
{
    public sealed class TestDeceleratingWorldAge
    {
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
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
        /* DONE World age is 100 BCE after advancing 39 rounds. */
        [InlineData(39, -100)]
        //
        /* DONE World age is 1 BCE after advancing 40 rounds. */
        [InlineData(40, -1)]
        //
        /* DONE World age is 1 CE after advancing 41 rounds. */
        [InlineData(41, 1)]
        //
        /* DONE World age is 50 CE after advancing 42 rounds. */
        [InlineData(42, 50)]
        //
        /* DONE World age is 100 CE after advancing 43 rounds. */
        [InlineData(43, 100)]
        //
        /* DONE World age is 1750 CE after advancing 76 rounds. */
        [InlineData(76, 1750)]
        //
        /* DONE World age is 1775 CE after advancing 77 rounds. */
        [InlineData(77, 1775)]
        //
        /* DONE World age is 1900 CE after advancing 82 rounds. */
        [InlineData(82, 1900)]
        //
        /* DONE World age is 1905 CE after advancing 83 rounds. */
        [InlineData(83, 1905)]
        //
        /* DONE World age is 1970 CE after advancing 96 rounds. */
        [InlineData(96, 1970)]
        //
        /* DONE World age is 1971 CE after advancing 97 rounds. */
        [InlineData(97, 1971)]
        //
        /* DONE World age is 1972 CE after advancing 98 rounds. */
        [InlineData(98, 1972)]
        //
        public void WorldAge_AdvancesBy100Years(int roundsToAdvance, int expectedWorldAge)
        {
            // :::: ARRANGE ::::
            var decelerating = new DeceleratingWorldAge();
            roundsToAdvance.Times(() => decelerating.AdvanceWorldAge());

            // :::: ACT ::::
            var actualWorldAge = decelerating.WorldAge;

            // :::: ASSERT ::::
            actualWorldAge.Should().Be(expectedWorldAge);
        }
    }
}
