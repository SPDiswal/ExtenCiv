using ExtenCiv.Utilities.Extensions;
using ExtenCiv.WorldAges;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.WorldAges
{
    public sealed class TestDeceleratingWorldAge
    {
        public static readonly TheoryData WorldAgeIsDecelerating = new TheoryData
            <int, int>
        {
            /* World age is 4000 BCE from start. */
            { 0, -4000 },
            //
            /* World age is 3900 BCE after advancing one round. */
            { 1, -3900 },
            //
            /* World age is 3800 BCE after advancing two rounds. */
            { 2, -3800 },
            //
            /* World age is 100 BCE after advancing 39 rounds. */
            { 39, -100 },
            //
            /* World age is 1 BCE after advancing 40 rounds. */
            { 40, -1 },
            //
            /* World age is 1 CE after advancing 41 rounds. */
            { 41, 1 },
            //
            /* World age is 50 CE after advancing 42 rounds. */
            { 42, 50 },
            //
            /* World age is 100 CE after advancing 43 rounds. */
            { 43, 100 },
            //
            /* World age is 1750 CE after advancing 76 rounds. */
            { 76, 1750 },
            //
            /* World age is 1775 CE after advancing 77 rounds. */
            { 77, 1775 },
            //
            /* World age is 1900 CE after advancing 82 rounds. */
            { 82, 1900 },
            //
            /* World age is 1905 CE after advancing 83 rounds. */
            { 83, 1905 },
            //
            /* World age is 1970 CE after advancing 96 rounds. */
            { 96, 1970 },
            //
            /* World age is 1971 CE after advancing 97 rounds. */
            { 97, 1971 },
            //
            /* World age is 1972 CE after advancing 98 rounds. */
            { 98, 1972 },
        };

        [Theory]
        [MemberData(nameof(WorldAgeIsDecelerating))]
        public void WorldAge_IsDecelerating(int roundsToAdvance, int expectedWorldAge)
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
