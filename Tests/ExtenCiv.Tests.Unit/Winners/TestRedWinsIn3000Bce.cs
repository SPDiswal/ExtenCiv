using ExtenCiv.Players;
using ExtenCiv.Winners;
using ExtenCiv.WorldAges.Abstractions;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.Winners
{
    public sealed class TestRedWinsIn3000Bce
    {
        /// <summary>
        ///     Red wins in 3000 BCE.
        /// </summary>
        /// <param name="fixedWorldAge">The world age.</param>
        [Theory]
        [MemberData(nameof(WhenWorldAgeIs3000BceOrLater))]
        public void Winner_IsRed_BecauseRedWinsIn3000Bce(int fixedWorldAge)
        {
            // :::: ARRANGE ::::
            var stubWorldAge = StubWorldAge(fixedWorldAge);
            var redWinsIn3000Bce = new RedWinsIn3000Bce(stubWorldAge);

            // :::: ACT ::::
            var actualWinner = redWinsIn3000Bce.Winner;

            // :::: ASSERT ::::
            actualWinner.Should().Be(Red);
        }

        /// <summary>
        ///     When the world age is 3000 BCE or later, the winner is Red.
        /// </summary>
        public static TheoryData WhenWorldAgeIs3000BceOrLater => new TheoryData
            <int>
        {
            /* The winner is Red in 3000 BCE. */
            -3000,
            //
            /* The winner is Red in 2900 BCE. */
            -2900,
        };

        /// <summary>
        ///     There is no winner before 3000 BCE.
        /// </summary>
        /// <param name="fixedWorldAge">The world age.</param>
        [Theory]
        [MemberData(nameof(WhenWorldAgeIsEarlierThan3000Bce))]
        public void Winner_IsNobody_BecauseRedIsYetToWin(int fixedWorldAge)
        {
            // :::: ARRANGE ::::
            var stubWorldAge = StubWorldAge(fixedWorldAge);
            var redWinsIn3000Bce = new RedWinsIn3000Bce(stubWorldAge);

            // :::: ACT ::::
            var actualWinner = redWinsIn3000Bce.Winner;

            // :::: ASSERT ::::
            actualWinner.Should().Be(Player.Nobody);
        }

        /// <summary>
        ///     When the world age is earlier than 3000 BCE, there is not winner yet.
        /// </summary>
        public static TheoryData WhenWorldAgeIsEarlierThan3000Bce => new TheoryData
            <int>
        {
            /* There is no winner in 3200 BCE. */
            -3200,
            //
            /* There is no winner in 3100 BCE. */
            -3100,
        };

        #region HELPERS: Shortcuts

        private static Player Red => new Player("Red");

        #endregion

        #region HELPERS: Stubs

        private static IWorldAge StubWorldAge(int fixedWorldAge)
        {
            var stubWorldAge = A.Fake<IWorldAge>();
            A.CallTo(() => stubWorldAge.CurrentWorldAge).Returns(fixedWorldAge);
            return stubWorldAge;
        }

        #endregion
    }
}
