using System;
using ExtenCiv.Cities.Types;
using ExtenCiv.CompositionRoot.Builders.Abstractions;
using ExtenCiv.CompositionRoot.Directors.Abstractions;

namespace ExtenCiv.CompositionRoot.Directors.Cities
{
    public sealed class ReversedFixedCities : ICityDirector
    {
        public void SetUpCities(Func<ICityBuilder> builder) { Cities(builder.Invoke()); }

        private static void Cities(ICityBuilder builder)
        {
            builder.WithFriendlyCityManagementOnly<City>()
                   .WithProductionAccumulation<City>()
                   .WithFixedGeneratedProduction<City>()
                   .WithNoCityGrowth<City>();
        }
    }
}
