using ExtenCiv.Players;
using ExtenCiv.Players.Abstractions;
using ExtenCiv.Tests.Utilities.Extensions;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Movement;
using ExtenCiv.Units.Types;
using ExtenCiv.WorldMaps.Tiles.Abstractions;
using FakeItEasy;
using Xunit;

namespace ExtenCiv.Tests.Unit.Units.Movement
{
    public sealed class TestFriendlyUnitManagementOnly
    {
        /// <summary>
        ///     The player is allowed to move units that belong to him.
        /// </summary>
        /// <param name="turnTaking">The turn-taking that specifies the current player in turn.</param>
        /// <param name="owner">The unit owner.</param>
        [Theory]
        [MemberData(nameof(WhenTheUnitBelongsToThePlayerInTurn))]
        public void MoveTo_IsForwarded_BecauseTheUnitBelongsToThePlayerInTurn(ITurnTaking turnTaking, Player owner)
        {
            // :::: ARRANGE ::::
            var spyUnit = A.Fake<IUnit<Archer>>();
            var managedUnit = new FriendlyUnitManagementOnly<Archer>(spyUnit, turnTaking);

            A.CallTo(() => spyUnit.Owner).Returns(owner);

            // :::: ACT ::::
            managedUnit.MoveTo(DummyTile);

            // :::: ASSERT ::::
            A.CallTo(() => spyUnit.MoveTo(A<ITile>._)).MustHaveHappened();
        }

        /// <summary>
        ///     The player is allowed to perform the special actions of units that belong to him.
        /// </summary>
        /// <param name="turnTaking">The turn-taking that specifies the current player in turn.</param>
        /// <param name="owner">The unit owner.</param>
        [Theory]
        [MemberData(nameof(WhenTheUnitBelongsToThePlayerInTurn))]
        public void PerformAction_IsForwarded_BecauseTheUnitBelongsToThePlayerInTurn(ITurnTaking turnTaking,
                                                                                     Player owner)
        {
            // :::: ARRANGE ::::
            var spyUnit = A.Fake<IUnit<Archer>>();
            var managedUnit = new FriendlyUnitManagementOnly<Archer>(spyUnit, turnTaking);

            A.CallTo(() => spyUnit.Owner).Returns(owner);

            // :::: ACT ::::
            managedUnit.PerformAction();

            // :::: ASSERT ::::
            A.CallTo(() => spyUnit.PerformAction()).MustHaveHappened();
        }

        /// <summary>
        ///     When the unit belongs to the player in turn, it allows him to manage it.
        /// </summary>
        public static TheoryData WhenTheUnitBelongsToThePlayerInTurn => new TheoryData
            <ITurnTaking, Player>
        {
            /* Red manages a Red unit. */
            { Red.InTurn(), Red },
            //
            /* Blue manages a Blue unit. */
            { Blue.InTurn(), Blue },
        };

        /// <summary>
        ///     The player is allowed to move units that belong to him.
        /// </summary>
        /// <param name="turnTaking">The turn-taking that specifies the current player in turn.</param>
        /// <param name="owner">The unit owner.</param>
        [Theory]
        [MemberData(nameof(WhenTheUnitDoesNotBelongToThePlayerInTurn))]
        public void MoveTo_IsNotForwarded_BecauseTheUnitBelongsToAnOpponent(ITurnTaking turnTaking, Player owner)
        {
            // :::: ARRANGE ::::
            var spyUnit = A.Fake<IUnit<Archer>>();
            var managedUnit = new FriendlyUnitManagementOnly<Archer>(spyUnit, turnTaking);

            A.CallTo(() => spyUnit.Owner).Returns(owner);

            // :::: ACT ::::
            managedUnit.MoveTo(DummyTile);

            // :::: ASSERT ::::
            A.CallTo(() => spyUnit.MoveTo(A<ITile>._)).MustNotHaveHappened();
        }

        /// <summary>
        ///     The player is allowed to perform the special actions of units that belong to him.
        /// </summary>
        /// <param name="turnTaking">The turn-taking that specifies the current player in turn.</param>
        /// <param name="owner">The unit owner.</param>
        [Theory]
        [MemberData(nameof(WhenTheUnitDoesNotBelongToThePlayerInTurn))]
        public void PerformAction_IsNotForwarded_BecauseTheUnitBelongsToAnOpponent(ITurnTaking turnTaking, Player owner)
        {
            // :::: ARRANGE ::::
            var spyUnit = A.Fake<IUnit<Archer>>();
            var managedUnit = new FriendlyUnitManagementOnly<Archer>(spyUnit, turnTaking);

            A.CallTo(() => spyUnit.Owner).Returns(owner);

            // :::: ACT ::::
            managedUnit.PerformAction();

            // :::: ASSERT ::::
            A.CallTo(() => spyUnit.PerformAction()).MustNotHaveHappened();
        }

        /// <summary>
        ///     When the unit does not belong to the player in turn, it does not allow him to manage it.
        /// </summary>
        public static TheoryData WhenTheUnitDoesNotBelongToThePlayerInTurn => new TheoryData
            <ITurnTaking, Player>
        {
            /* Red manages a Blue unit. */
            { Red.InTurn(), Blue },
            //
            /* Blue manages a Red unit. */
            { Blue.InTurn(), Red },
        };

        #region HELPERS: Shortcuts

        private static Player Red => new Player("Red");
        private static Player Blue => new Player("Blue");

        #endregion

        #region HELPERS: Dummies

        private static ITile DummyTile => A.Fake<ITile>();

        #endregion
    }
}
