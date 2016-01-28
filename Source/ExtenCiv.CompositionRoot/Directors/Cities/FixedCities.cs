using System;
using ExtenCiv.Cities.Types;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using ExtenCiv.CompositionRoot.Directors.Abstractions;

namespace ExtenCiv.CompositionRoot.Directors.Cities
{
    public sealed class FixedCities : ICityDirector
    {
        public void SetUpCities(Func<ICityBuilder> builder) { Cities(builder.Invoke()); }

        private static void Cities(ICityBuilder builder)
        {
            builder.WithNoCityGrowth<City>()
                   .WithFixedGeneratedProduction<City>()
                   .WithProductionAccumulation<City>()
                   .WithFriendlyCityManagementOnly<City>();
        }
    }
}
