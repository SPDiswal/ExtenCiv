using ExtenCiv.Cities.Types;
using ExtenCiv.Cities.Types.Factories.Abstractions;
using ExtenCiv.Players;
using ExtenCiv.Terrains.Types;
using ExtenCiv.Terrains.Types.Factories.Abstractions;
using ExtenCiv.Units.Types;
using ExtenCiv.Units.Types.Factories.Abstractions;
using ExtenCiv.WorldMaps.Tiles.Abstractions;
using FakeItEasy;

namespace ExtenCiv.Tests.Utilities.Stubs
{
    public static class StubFactories
    {
        public static ICityFactory<City> SimpleCityFactory
        {
            get
            {
                var stubFactory = A.Fake<ICityFactory<City>>();

                A.CallTo(() => stubFactory.Create(A<ITile>._, A<Player>._))
                 .ReturnsLazily((ITile location, Player owner) => new City { Location = location, Owner = owner });

                return stubFactory;
            }
        }

        public static ITerrainFactory<Forests> SimpleForestsFactory
        {
            get
            {
                var stubFactory = A.Fake<ITerrainFactory<Forests>>();

                A.CallTo(() => stubFactory.Create(A<ITile>._))
                 .ReturnsLazily((ITile location) => new Forests { Location = location });

                return stubFactory;
            }
        }

        public static ITerrainFactory<Hills> SimpleHillsFactory
        {
            get
            {
                var stubFactory = A.Fake<ITerrainFactory<Hills>>();

                A.CallTo(() => stubFactory.Create(A<ITile>._))
                 .ReturnsLazily((ITile location) => new Hills { Location = location });

                return stubFactory;
            }
        }

        public static ITerrainFactory<Mountains> SimpleMountainsFactory
        {
            get
            {
                var stubFactory = A.Fake<ITerrainFactory<Mountains>>();

                A.CallTo(() => stubFactory.Create(A<ITile>._))
                 .ReturnsLazily((ITile location) => new Mountains { Location = location });

                return stubFactory;
            }
        }

        public static ITerrainFactory<Oceans> SimpleOceansFactory
        {
            get
            {
                var stubFactory = A.Fake<ITerrainFactory<Oceans>>();

                A.CallTo(() => stubFactory.Create(A<ITile>._))
                 .ReturnsLazily((ITile location) => new Oceans { Location = location });

                return stubFactory;
            }
        }

        public static ITerrainFactory<Plains> SimplePlainsFactory
        {
            get
            {
                var stubFactory = A.Fake<ITerrainFactory<Plains>>();

                A.CallTo(() => stubFactory.Create(A<ITile>._))
                 .ReturnsLazily((ITile location) => new Plains { Location = location });

                return stubFactory;
            }
        }

        public static IUnitFactory<Archer> SimpleArcherFactory
        {
            get
            {
                var stubFactory = A.Fake<IUnitFactory<Archer>>();

                A.CallTo(() => stubFactory.Create(A<ITile>._, A<Player>._))
                 .ReturnsLazily((ITile location, Player owner) => new Archer { Location = location, Owner = owner });

                return stubFactory;
            }
        }

        public static IUnitFactory<Legion> SimpleLegionFactory
        {
            get
            {
                var stubFactory = A.Fake<IUnitFactory<Legion>>();

                A.CallTo(() => stubFactory.Create(A<ITile>._, A<Player>._))
                 .ReturnsLazily((ITile location, Player owner) => new Legion { Location = location, Owner = owner });

                return stubFactory;
            }
        }

        public static IUnitFactory<Settler> SimpleSettlerFactory
        {
            get
            {
                var stubFactory = A.Fake<IUnitFactory<Settler>>();

                A.CallTo(() => stubFactory.Create(A<ITile>._, A<Player>._))
                 .ReturnsLazily((ITile location, Player owner) => new Settler { Location = location, Owner = owner });

                return stubFactory;
            }
        }
    }
}
