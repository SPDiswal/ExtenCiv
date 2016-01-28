using System.Collections.Generic;
using System.Linq;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Utilities;
using ExtenCiv.Terrains.Abstractions;
using ExtenCiv.Terrains.Utilities;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Utilities;
using ExtenCiv.WorldMaps.Abstractions;
using FakeItEasy;

namespace ExtenCiv.Tests.Utilities.Stubs
{
    public static class StubWorld
    {
        public static ISet<ICity> NoCities => Cities(Enumerable.Empty<ICity>());

        public static ISet<ICity> Cities(IEnumerable<ICity> cities)
        {
            return new HashSet<ICity>(cities, new CityEqualityComparer());
        }

        public static ICityLayer EmptyCityLayer => CityLayer(Enumerable.Empty<ICity>());

        public static ICityLayer CityLayer(IEnumerable<ICity> cities)
        {
            var citySet = new HashSet<ICity>(cities, new CityEqualityComparer());

            var stubCityLayer = A.Fake<ICityLayer>();
            A.CallTo(() => stubCityLayer.Cities).Returns(citySet);
            return stubCityLayer;
        }

        public static ISet<ITerrain> NoTerrains => Terrains(Enumerable.Empty<ITerrain>());

        public static ISet<ITerrain> Terrains(IEnumerable<ITerrain> terrains)
        {
            return new HashSet<ITerrain>(terrains, new TerrainEqualityComparer());
        }

        public static ITerrainLayer EmptyTerrainLayer => TerrainLayer(Enumerable.Empty<ITerrain>());

        public static ITerrainLayer TerrainLayer(IEnumerable<ITerrain> terrains)
        {
            var terrainSet = new HashSet<ITerrain>(terrains, new TerrainEqualityComparer());

            var stubTerrainLayer = A.Fake<ITerrainLayer>();
            A.CallTo(() => stubTerrainLayer.Terrains).Returns(terrainSet);
            return stubTerrainLayer;
        }

        public static ISet<IUnit> NoUnits => Units(Enumerable.Empty<IUnit>());

        public static ISet<IUnit> Units(IEnumerable<IUnit> units)
        {
            return new HashSet<IUnit>(units, new UnitEqualityComparer());
        }

        public static IUnitLayer EmptyUnitLayer => UnitLayer(Enumerable.Empty<IUnit>());

        public static IUnitLayer UnitLayer(IEnumerable<IUnit> units)
        {
            var unitSet = new HashSet<IUnit>(units, new UnitEqualityComparer());

            var stubUnitLayer = A.Fake<IUnitLayer>();
            A.CallTo(() => stubUnitLayer.Units).Returns(unitSet);
            return stubUnitLayer;
        }
    }
}
