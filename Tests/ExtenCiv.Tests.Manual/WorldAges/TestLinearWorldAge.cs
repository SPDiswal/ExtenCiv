using ExtenCiv.Utilities.Extensions;
using ExtenCiv.WorldAges;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.WorldAges
{
    public sealed class TestLinearWorldAge
    {
        public static readonly TheoryData WorldAgeAdvancesLinearlyBy100Years = new TheoryData
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
        };

        [Theory]
        [MemberData(nameof(WorldAgeAdvancesLinearlyBy100Years))]
        public void WorldAge_AdvancesLinearlyBy100Years(int roundsToAdvance, int expectedWorldAge)
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
