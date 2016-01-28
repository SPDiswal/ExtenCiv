using System.Linq;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Types;
using ExtenCiv.Players;
using ExtenCiv.Tests.Utilities.Extensions;
using ExtenCiv.Tests.Utilities.Stubs;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Actions;
using ExtenCiv.Units.Types;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.Units.Actions
{
    public sealed class TestCityBuildingAction
    {
        /// <summary>
        ///     A city-building action builds cities on empty tiles.
        /// </summary>
        /// <param name="unit">The unit to build a city.</param>
        [Theory]
        [MemberData(nameof(WhenThereIsNoCityOnTheTile))]
        public void PerformAction_BuildsAFriendlyCity_BecauseTheTileIsVacant(IUnit<Settler> unit)
        {
            // :::: ARRANGE ::::
            var stubCities = StubWorld.NoCities;
            var stubUnits = StubWorld.Units(new[] { unit });
            var stubCityFactory = StubFactories.SimpleCityFactory;
            var cityBuildingUnit = new CityBuildingAction<Settler>(unit, stubUnits, stubCities, stubCityFactory);

            // :::: ACT ::::
            cityBuildingUnit.PerformAction();

            // :::: ASSERT ::::
            var newlyBuiltCity = stubCities.Single();

            newlyBuiltCity.Location.Should().Be(unit.Location);
            newlyBuiltCity.Owner.Should().Be(unit.Owner);
        }

        /// <summary>
        ///     When there is no city on the tile, a unit can build a city there.
        /// </summary>
        public static TheoryData WhenThereIsNoCityOnTheTile => new TheoryData
            <IUnit<Settler>>
        {
            /* A Red Settler builds a Red City at (2, 1). */
            Red.Settler().At(2, 1),
            //
            /* A Blue Settler builds a Blue City at (3, 2). */
            Blue.Settler().At(3, 2),
        };

        /// <summary>
        ///     A city-building action does not build cities on tiles that already have cities.
        /// </summary>
        /// <param name="city">The existing city.</param>
        /// <param name="unit">The unit to build a city.</param>
        [Theory]
        [MemberData(nameof(WhenThereIsAlreadyACityOnTheTile))]
        public void PerformAction_DoesNotBuildACity_BecauseTheTileIsNotVacant(ICity<City> city, IUnit<Settler> unit)
        {
            // :::: ARRANGE ::::
            var stubCities = StubWorld.Cities(new[] { city });
            var stubUnits = StubWorld.Units(new[] { unit });
            var stubCityFactory = StubFactories.SimpleCityFactory;
            var cityBuildingUnit = new CityBuildingAction<Settler>(unit, stubUnits, stubCities, stubCityFactory);

            // :::: ACT ::::
            cityBuildingUnit.PerformAction();

            // :::: ASSERT ::::
            var existingCity = stubCities.Single();
            existingCity.Should().BeSameAs(city);
        }

        /// <summary>
        ///     When there is already a city on the tile, a unit cannot build a city there.
        /// </summary>
        public static TheoryData WhenThereIsAlreadyACityOnTheTile => new TheoryData
            <ICity, IUnit<Settler>>
        {
            /* A Red Settler cannot build a Red City at (2, 1). */
            { Red.City().At(2, 1), Red.Settler().At(2, 1) },
            //
            /* A Blue Settler cannot build a Blue City at (3, 2). */
            { Blue.City().At(3, 2), Blue.Settler().At(3, 2) },
        };

        /// <summary>
        ///     A city-building action removes the city-building unit on empty tiles.
        /// </summary>
        /// <param name="unit">The unit to build a city.</param>
        /// <param name="otherUnits">The other units in the world.</param>
        [Theory]
        [MemberData(nameof(WhenThereAreOtherUnitsInTheWorldAndNoCityOnTheTile))]
        public void PerformAction_RemovesTheCityBuildingUnit_BecauseTheTileIsVacant(IUnit<Settler> unit,
                                                                                    IUnit[] otherUnits)
        {
            // :::: ARRANGE ::::
            var stubCities = StubWorld.NoCities;
            var stubUnits = StubWorld.Units(new[] { unit }.Concat(otherUnits));
            var stubCityFactory = StubFactories.SimpleCityFactory;
            var cityBuildingUnit = new CityBuildingAction<Settler>(unit, stubUnits, stubCities, stubCityFactory);

            // :::: ACT ::::
            cityBuildingUnit.PerformAction();

            // :::: ASSERT ::::
            stubUnits.Should().NotContain(unit).And.Contain(otherUnits);
        }

        /// <summary>
        ///     When there are other units in the world and no city on the tile,
        ///     a unit can perform a city-building action there.
        /// </summary>
        public static TheoryData WhenThereAreOtherUnitsInTheWorldAndNoCityOnTheTile => new TheoryData
            <IUnit<Settler>, IUnit[]>
        {
            /* A Red Settler performs a city-building action at (2, 1). */
            { Red.Settler().At(2, 1), new IUnit[] { Red.Archer().At(4, 3), Blue.Legion().At(3, 2) } },
            //
            /* A Blue Settler performs a city-building action at (3, 2). */
            { Blue.Settler().At(3, 2), new IUnit[] { Red.Archer().At(4, 3), Blue.Settler().At(2, 0) } },
        };

        /// <summary>
        ///     A city-building action does not remove the city-building unit on tiles that already have cities.
        /// </summary>
        /// <param name="city">The existing city.</param>
        /// <param name="unit">The unit to build a city.</param>
        /// <param name="otherUnits">The other units in the world.</param>
        [Theory]
        [MemberData(nameof(WhenThereAreOtherUnitsInTheWorldAndAlreadyACityOnTheTile))]
        public void PerformAction_DoesNotRemoveTheCityBuildingUnit_BecauseTheTileIsNotVacant(ICity city,
                                                                                             IUnit<Settler> unit,
                                                                                             IUnit[] otherUnits)
        {
            // :::: ARRANGE ::::
            var stubCities = StubWorld.Cities(new[] { city });
            var stubUnits = StubWorld.Units(new[] { unit }.Concat(otherUnits));
            var stubCityFactory = StubFactories.SimpleCityFactory;
            var cityBuildingUnit = new CityBuildingAction<Settler>(unit, stubUnits, stubCities, stubCityFactory);

            // :::: ACT ::::
            cityBuildingUnit.PerformAction();

            // :::: ASSERT ::::
            stubUnits.Should().Contain(unit).And.Contain(otherUnits);
        }

        /// <summary>
        ///     When there are other units in the world and already a city on the tile,
        ///     a unit cannot perform a city-building action there.
        /// </summary>
        public static TheoryData WhenThereAreOtherUnitsInTheWorldAndAlreadyACityOnTheTile => new TheoryData
            <ICity<City>, IUnit<Settler>, IUnit[]>
        {
            /* A Red Settler cannot perform a city-building action at (2, 1). */
            {
                Red.City().At(2, 1), Red.Settler().At(2, 1),
                new IUnit[] { Red.Archer().At(4, 3), Blue.Legion().At(3, 2) }
            },
            //
            /* A Blue Settler cannot perform a city-building action at (3, 2). */
            {
                Blue.City().At(3, 2), Blue.Settler().At(3, 2),
                new IUnit[] { Red.Archer().At(4, 3), Blue.Settler().At(2, 0) }
            },
        };

        #region HELPERS: Shortcuts

        private static Player Red => new Player("Red");
        private static Player Blue => new Player("Blue");

        #endregion
    }
}
