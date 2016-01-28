using ExtenCiv.Cities.Abstractions;
using ExtenCiv.WorldMaps.Tiles;

namespace ExtenCiv.Tests.Utilities.Extensions
{
    public static class CityExtensions
    {
        public static ICity<TCity> At<TCity>(this ICity<TCity> city, int row, int column) where TCity : ICity<TCity>
        {
            city.Location = new SquareTile(row, column);
            return city;
        }

        public static ICity<TCity> OfSize<TCity>(this ICity<TCity> city, int population) where TCity : ICity<TCity>
        {
            city.Population = population;
            return city;
        }

        public static CityConfiguration<TCity> Generating<TCity>(this ICity<TCity> city, int amount)
            where TCity : ICity<TCity>
        {
            return new CityConfiguration<TCity>(city, amount);
        }

        public static ICity<TCity> Producing<TCity>(this ICity<TCity> city, IProductionProject productionProject)
            where TCity : ICity<TCity>
        {
            city.ProductionProject = productionProject;
            return city;
        }

        public class CityConfiguration<TCity> where TCity : ICity<TCity>
        {
            private readonly ICity<TCity> city;
            private readonly int value;

            public CityConfiguration(ICity<TCity> city, int value)
            {
                this.city = city;
                this.value = value;
            }

            public ICity<TCity> ProductionPerRound
            {
                get
                {
                    city.GeneratedProduction = value;
                    return city;
                }
            }
        }
    }
}
