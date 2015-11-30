using System;
using System.Collections.Generic;
using ExtenCiv.GameBoards;
using ExtenCiv.Players;
using ExtenCiv.Terrains;
using ExtenCiv.Units;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.GameBoards
{
    public sealed class TestSimpleFixedGameBoard
    {
        private static readonly Player Red = new Player("Red");
        private static readonly Player Blue = new Player("Blue");

        #region Terrains

        public static readonly TheoryData TilesReturnsTerrains = new TheoryData
            <Position, Type>
        {
            /* There are Oceans at (1, 0). */
            { new Position(1, 0), typeof (Oceans) },
            //
            /* There are Hills at (0, 1). */
            { new Position(0, 1), typeof (Hills) },
            //
            /* There are Mountains at (2, 2). */
            { new Position(2, 2), typeof (Mountains) },
            //
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // There are Plains everywhere else:
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //
            /* There are Plains at (1, 1). */
            { new Position(1, 1), typeof (Plains) },
            //
            /* There are Plains at (6, 7). */
            { new Position(6, 7), typeof (Plains) },
            //
            /* There are Plains at (12, 5). */
            { new Position(12, 5), typeof (Plains) },
        };

        [Theory]
        [MemberData(nameof(TilesReturnsTerrains))]
        public void Tiles_ReturnsTerrains(Position position, Type expectedTerrainType)
        {
            // :::: ARRANGE ::::
            var simpleFixedGameBoard = new SimpleFixedGameBoard();

            // :::: ACT ::::
            var actualTerrain = simpleFixedGameBoard.Terrains[position];

            // :::: ASSERT ::::
            actualTerrain.Should().BeOfType(expectedTerrainType);
        }

        #endregion

        #region Cities

        public static readonly TheoryData CitiesReturnsExistingCities = new TheoryData
            <Position, Player>
        {
            /* There is a Red City at (1, 1). */
            { new Position(1, 1), Red },
            //
            /* There is a Blue City at (4, 1). */
            { new Position(4, 1), Blue },
        };

        [Theory]
        [MemberData(nameof(CitiesReturnsExistingCities))]
        public void Cities_ReturnsExistingCities(Position position, Player expectedOwner)
        {
            // :::: ARRANGE ::::
            var simpleFixedGameBoard = new SimpleFixedGameBoard();

            // :::: ACT ::::
            var actualCity = simpleFixedGameBoard.Cities[position];

            // :::: ASSERT ::::
            const int expectedPopulation = 1;

            actualCity.Owner.Should().Be(expectedOwner);
            actualCity.Population.Should().Be(expectedPopulation);
        }

        public static readonly TheoryData CitiesThrowsExceptionForNonExistingCities = new TheoryData
            <Position>
        {
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // There are no Cities anywhere else:
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //
            /* There is no City at (3, 2). */
            new Position(3, 2),
            //
            /* There is no City at (6, 7). */
            new Position(6, 7),
        };

        [Theory]
        [MemberData(nameof(CitiesThrowsExceptionForNonExistingCities))]
        public void Cities_ThrowsException_ForNonExistingCities(Position position)
        {
            // :::: ARRANGE ::::
            var simpleFixedGameBoard = new SimpleFixedGameBoard();

            // :::: ACT ::::
            Action action = () => { var _ = simpleFixedGameBoard.Cities[position]; };

            // :::: ASSERT ::::
            action.ShouldThrow<KeyNotFoundException>();
        }

        #endregion

        #region Units

        public static readonly TheoryData UnitsReturnsExistingUnits = new TheoryData
            <Position, Player, Type>
        {
            /* There is a Red Archer at (2, 0). */
            { new Position(2, 0), Red, typeof (Archer) },
            //
            /* There is a Blue Legion at (3, 2). */
            { new Position(3, 2), Blue, typeof (Legion) },
            //
            /* There is a Red Settler at (4, 3). */
            { new Position(4, 3), Red, typeof (Settler) },
        };

        [Theory]
        [MemberData(nameof(UnitsReturnsExistingUnits))]
        public void Units_ReturnsExistingUnits(Position position, Player expectedOwner, Type expectedUnitType)
        {
            // :::: ARRANGE ::::
            var simpleFixedGameBoard = new SimpleFixedGameBoard();

            // :::: ACT ::::
            var actualUnit = simpleFixedGameBoard.Units[position];

            // :::: ASSERT ::::
            actualUnit.Owner.Should().Be(expectedOwner);
            actualUnit.Should().BeOfType(expectedUnitType);
        }

        public static readonly TheoryData UnitsThrowsExceptionForNonExistingUnits = new TheoryData
            <Position>
        {
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // There are no Units anywhere else:
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //
            /* There is no Unit at (5, 4). */
            new Position(5, 4),
            //
            /* There is no Unit at (6, 7). */
            new Position(6, 7),
        };

        [Theory]
        [MemberData(nameof(UnitsThrowsExceptionForNonExistingUnits))]
        public void Units_ThrowsException_ForNonExistingUnits(Position position)
        {
            // :::: ARRANGE ::::
            var simpleFixedGameBoard = new SimpleFixedGameBoard();

            // :::: ACT ::::
            Action action = () => { var _ = simpleFixedGameBoard.Units[position]; };

            // :::: ASSERT ::::
            action.ShouldThrow<KeyNotFoundException>();
        }

        #endregion
    }
}
