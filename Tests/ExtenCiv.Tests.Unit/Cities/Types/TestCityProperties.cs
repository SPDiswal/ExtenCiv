using System;
using System.Linq.Expressions;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Types;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.Cities.Types
{
    public sealed class TestCityProperties
    {
        /// <summary>
        ///     Properties of cities return the values for their specific city types.
        /// </summary>
        /// <param name="city">The city with the properties being inspected.</param>
        /// <param name="property">A closure of the property to inspect.</param>
        /// <param name="expectedValue">The expected value of the property.</param>
        [Theory]
        [MemberData(nameof(WhenItIsACity))]
        public void Property_ReturnsTheValueForTheSpecificCityType(ICity city,
                                                                   Expression<Func<ICity, int>> property,
                                                                   int expectedValue)
        {
            // :::: ACT ::::
            var actualValue = property.Compile().Invoke(city);

            // :::: ASSERT ::::
            actualValue.Should().Be(expectedValue);
        }

        /// <summary>
        ///     Properties of Cities return the values for Cities.
        /// </summary>
        public static TheoryData WhenItIsACity => new TheoryData
            <ICity, Expression<Func<ICity, int>>, int>
        {
            /* Cities have a population size of 1 initially. */
            { City, _ => _.Population, 1 },
            //
            /* Cities have a food treasury of 0 initially. */
            { City, _ => _.FoodTreasury, 0 },
            //
            /* Cities have a production treasury of 0 initially. */
            { City, _ => _.ProductionTreasury, 0 },
        };

        #region HELPERS: Shortcuts

        private static ICity City => new City();

        #endregion
    }
}
