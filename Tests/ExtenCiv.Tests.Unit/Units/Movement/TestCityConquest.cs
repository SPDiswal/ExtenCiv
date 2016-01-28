using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Players;
using ExtenCiv.Tests.Utilities.Extensions;
using ExtenCiv.Tests.Utilities.Stubs;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Movement;
using ExtenCiv.Units.Types;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.Units.Movement
{
    public sealed class TestCityConquest
    {
        /// <summary>
        ///     Units conquer opponent cities when moving.
        /// </summary>
        /// <param name="unit">The unit to move.</param>
        /// <param name="city">The city to conquer.</param>
        [Theory]
        [MemberData(nameof(WhenMovingToATileWithAnOpponentCity))]
        public void MoveTo_ConquersOpponentCities(IUnit<Archer> unit, ICity city)
        {
            // :::: ARRANGE ::::
            var stubCities = StubWorld.Cities(new[] { city });
            var cityConquestUnit = new CityConquest<Archer>(unit, stubCities);

            // :::: ACT ::::
            var destination = city.Location;
            cityConquestUnit.MoveTo(destination);

            // :::: ASSERT ::::
            city.Owner.Should().Be(unit.Owner);
        }

        /// <summary>
        ///     When moving a unit to a tile with an opponent city, the unit conquers the city.
        /// </summary>
        public static TheoryData WhenMovingToATileWithAnOpponentCity => new TheoryData
            <IUnit<Archer>, ICity>
        {
            /* A Red Archer conquers a Blue City at (2, 0). */
            { Red.Archer(), Blue.City().At(2, 0) },
            //
            /* A Blue Archer conquers a Red City at (3, 2). */
            { Blue.Archer(), Red.City().At(3, 2) },
        };

        #region HELPERS: Shortcuts

        private static Player Red => new Player("Red");
        private static Player Blue => new Player("Blue");

        #endregion
    }
}
