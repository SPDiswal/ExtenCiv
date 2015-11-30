using System.Collections.Generic;
using ExtenCiv.Cities;
using ExtenCiv.GameBoards;
using ExtenCiv.Players;
using ExtenCiv.UnitActions;
using ExtenCiv.Units;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.UnitActions
{
    public sealed class TestCityBuildingAction
    {
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        /* TODO A Red Unit at (1, 0) does not build a city when there already is a city at (1, 0). */
        /* TODO A Red Unit at (3, 3) does not build a city when there already is a city at (3, 3). */
        /* TODO A Blue Unit at (2, 1) does not build a city when there already is a city at (2, 1). */
        /* TODO A Blue Unit at (4, 4) does not build a city when there already is a city at (4, 4). */
        /* TODO A Red Unit at (1, 0) disbands upon building city. */
        /* TODO A Red Unit at (3, 3) disbands upon building city. */
        /* TODO A Blue Unit at (2, 1) disbands upon building city. */
        /* TODO A Blue Unit at (4, 4) disbands upon building city. */
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private static readonly Player Red = new Player("Red");
        private static readonly Player Blue = new Player("Blue");

        private static readonly IUnit RedUnit = StubUnit(Red);
        private static readonly IUnit BlueUnit = StubUnit(Blue);

        private static IUnit StubUnit(Player owner)
        {
            var stubUnit = A.Fake<IUnit>();
            A.CallTo(() => stubUnit.Owner).Returns(owner);
            A.CallTo(() => stubUnit.ToString()).Returns($"{owner} Unit");
            return stubUnit;
        }

        public static readonly TheoryData PerformActionBuildsFriendlyCityWhenPositionIsVacant = new TheoryData
            <IUnit, Position>
        {
            /* A Red Unit at (1, 0) builds a Red City at (1, 0) with population of 1 when there is no city at (1, 0). */
            { RedUnit, new Position(1, 0) },
            //
            /* A Red Unit at (3, 3) builds a Red City at (3, 3) with population of 1 when there is no city at (3, 3). */
            { RedUnit, new Position(3, 3) },
            //
            /* A Blue Unit at (2, 1) builds a Blue City at (2, 1) with population of 1 when there is no city at (2, 1). */
            { BlueUnit, new Position(2, 1) },
            //
            /* A Blue Unit at (4, 4) builds a Blue City at (4, 4) with population of 1 when there is no city at (4, 4). */
            { BlueUnit, new Position(4, 4) },
        };

        [Theory]
        [MemberData(nameof(PerformActionBuildsFriendlyCityWhenPositionIsVacant))]
        public void PerformAction_BuildsFriendlyCity_WhenPositionIsVacant(IUnit decoratedUnit, Position position)
        {
            // :::: ARRANGE ::::
            var stubGameBoardStrategy = A.Fake<IGameBoardStrategy>();
            var citybuildingUnit = new CityBuildingAction(decoratedUnit, stubGameBoardStrategy);

            var cities = new Dictionary<Position, ICity>();
            var units = new Dictionary<Position, IUnit> { [position] = citybuildingUnit };

            A.CallTo(() => stubGameBoardStrategy.Cities).Returns(cities);
            A.CallTo(() => stubGameBoardStrategy.Units).Returns(units);

            // :::: ACT ::::
            citybuildingUnit.PerformAction();

            // :::: ASSERT ::::
            var expectedCityOwner = decoratedUnit.Owner;
            const int expectedPopulation = 1;

            cities[position].Owner.Should().Be(expectedCityOwner);
            cities[position].Population.Should().Be(expectedPopulation);
        }
    }
}
