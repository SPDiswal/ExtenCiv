using System;
using System.Linq;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Types;
using ExtenCiv.Cities.Workforce;
using ExtenCiv.Players;
using ExtenCiv.Players.Events;
using ExtenCiv.Tests.Utilities.Extensions;
using ExtenCiv.Tests.Utilities.Stubs;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Types;
using ExtenCiv.Units.Types.Factories;
using ExtenCiv.Units.Types.Factories.Abstractions;
using ExtenCiv.Utilities.Extensions;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.Cities.Workforce
{
    public sealed class TestProductionAccumulation
    {
        /// <summary>
        ///     Production is accumulated in every round, making the production treasury grow.
        /// </summary>
        /// <param name="city">The city that generates production points every round.</param>
        /// <param name="rounds">The number of rounds to advance.</param>
        [Theory]
        [MemberData(nameof(WhenTheNextRoundBegins))]
        public void TheProductionTreasury_AccumulatesTheGeneratedProduction(ICity<City> city, int rounds)
        {
            // :::: ARRANGE ::::
            var stubUnits = StubWorld.NoUnits;
            var stubNotifier = A.Fake<INotifyBeginningNextRound>();
            var accumulatingCity = new ProductionAccumulation<City>(city, stubUnits, stubNotifier);

            // :::: ACT ::::
            rounds.Times(() => stubNotifier.BeginningNextRound += Raise.With(DummyEventArgs));

            // :::: ASSERT ::::
            var expectedTreasury = rounds * city.GeneratedProduction;
            accumulatingCity.ProductionTreasury.Should().Be(expectedTreasury);
        }

        /// <summary>
        ///     When the next round begins, a city accumulates the production points it generates.
        /// </summary>
        public static TheoryData WhenTheNextRoundBegins => new TheoryData
            <ICity<City>, int>
        {
            /* A Red City generating 12 points for one round has accumulated 1 * 12 = 12 points. */
            { Red.City().Generating(12).ProductionPerRound.Producing(Nothing), 1 },
            //
            /* A Blue City generating 15 points for three rounds has accumulated 3 * 15 = 45 points. */
            { Blue.City().Generating(15).ProductionPerRound.Producing(Nothing), 3 },
        };

        /// <summary>
        ///     The cost of newly produced units is deducted from the production treasury.
        /// </summary>
        /// <param name="city">The city that generates production points every round and has a production project.</param>
        /// <param name="rounds">The number of rounds to advance.</param>
        [Theory]
        [MemberData(nameof(WhenThereAreEnoughPointsToProduceAUnit))]
        public void TheCostOfTheUnit_IsDeductedFromTheProductionTreasury(ICity<City> city, int rounds)
        {
            // :::: ARRANGE ::::
            var stubUnits = StubWorld.NoUnits;
            var stubNotifier = A.Fake<INotifyBeginningNextRound>();
            var accumulatingCity = new ProductionAccumulation<City>(city, stubUnits, stubNotifier);

            // :::: ACT ::::
            rounds.Times(() => stubNotifier.BeginningNextRound += Raise.With(DummyEventArgs));

            // :::: ASSERT ::::
            var expectedTreasury = rounds * city.GeneratedProduction - city.ProductionProject.Cost;
            accumulatingCity.ProductionTreasury.Should().Be(expectedTreasury);
        }

        /// <summary>
        ///     When the production treasury has accumulated enough points to produce a unit, the production cost is
        ///     deducted from the treasury.
        /// </summary>
        public static TheoryData WhenThereAreEnoughPointsToProduceAUnit => new TheoryData
            <ICity, int>
        {
            /* A city generating 2 points for five rounds for Archers of 10 points has accumulated 5 * 2 - 10 = 0 points. */
            { Red.City().Generating(2).ProductionPerRound.Producing(Archers), 5 },
            //
            /* A city generating 6 points for three rounds for Legions of 15 points has accumulated 3 * 6 - 15 = 3 points. */
            { Blue.City().Generating(6).ProductionPerRound.Producing(Legions), 3 },
        };

        /// <summary>
        ///     Newly produced units are placed on the city tile and belong to the city owner.
        /// </summary>
        /// <param name="city">The city that produces units.</param>
        /// <param name="expectedType">The expected unit type to be produced.</param>
        [Theory]
        [MemberData(nameof(WhenAUnitIsProduced))]
        public void TheUnit_IsPlacedOnTheCityTile_AndBelongsToTheCityOwner(ICity<City> city, Type expectedType)
        {
            // :::: ARRANGE ::::
            var stubUnits = StubWorld.NoUnits;
            var stubNotifier = A.Fake<INotifyBeginningNextRound>();
            var accumulatingCity = new ProductionAccumulation<City>(city, stubUnits, stubNotifier);

            // :::: ACT ::::
            stubNotifier.BeginningNextRound += Raise.With(DummyEventArgs);

            // :::: ASSERT ::::
            var newlyProducedUnit = stubUnits.Single();

            newlyProducedUnit.Should().BeOfType(expectedType);
            newlyProducedUnit.Owner.Should().Be(accumulatingCity.Owner);
            newlyProducedUnit.Location.Should().Be(accumulatingCity.Location);
        }

        /// <summary>
        ///     When a unit is produced, it is placed on the city tile and belongs to the city owner.
        /// </summary>
        public static TheoryData WhenAUnitIsProduced => new TheoryData
            <ICity, Type>
        {
            /* A Red City at (2, 0) produces a Red Archer. */
            { Red.City().At(2, 0).Generating(10).ProductionPerRound.Producing(Archers), typeof (Archer) },
            //
            /* A Blue City at (4, 3) produces a Blue Legion. */
            { Blue.City().At(4, 3).Generating(15).ProductionPerRound.Producing(Legions), typeof (Legion) },
        };

        /// <summary>
        ///     Units do not spawn on city tile when it is occupied by another unit.
        /// </summary>
        /// <param name="city">The city that produces units.</param>
        /// <param name="existingUnit">The unit that occupies the city tile.</param>
        [Theory]
        [MemberData(nameof(WhenTheCityTileIsOccupiedByAnotherUnit))]
        public void Units_DoNotSpawnOnTheCityTile(ICity<City> city, IUnit existingUnit)
        {
            // :::: ARRANGE ::::
            var stubUnits = StubWorld.Units(new[] { existingUnit });
            var stubNotifier = A.Fake<INotifyBeginningNextRound>();
            var accumulatingCity = new ProductionAccumulation<City>(city, stubUnits, stubNotifier);

            // :::: ACT ::::
            stubNotifier.BeginningNextRound += Raise.With(DummyEventArgs);

            // :::: ASSERT ::::
            stubUnits.Should().HaveCount(1);
        }

        /// <summary>
        ///     When the city tile is occupied by another unit, the cost of the unit being produced is not deducted
        ///     from the production treasury.
        /// </summary>
        /// <param name="city">The city that produces units.</param>
        /// <param name="existingUnit">The unit that occupies the city tile.</param>
        [Theory]
        [MemberData(nameof(WhenTheCityTileIsOccupiedByAnotherUnit))]
        public void ProductionCost_IsNotDeductedFromTheProductionTreasury(ICity<City> city, IUnit existingUnit)
        {
            // :::: ARRANGE ::::
            var stubUnits = StubWorld.Units(new[] { existingUnit });
            var stubNotifier = A.Fake<INotifyBeginningNextRound>();
            var accumulatingCity = new ProductionAccumulation<City>(city, stubUnits, stubNotifier);

            // :::: ACT ::::
            stubNotifier.BeginningNextRound += Raise.With(DummyEventArgs);

            // :::: ASSERT ::::
            accumulatingCity.ProductionTreasury.Should().BeGreaterOrEqualTo(accumulatingCity.ProductionProject.Cost);
        }

        /// <summary>
        ///     When the city tile is occupied by another unit, the city does not produce a unit.
        /// </summary>
        public static TheoryData WhenTheCityTileIsOccupiedByAnotherUnit => new TheoryData
            <ICity, IUnit>
        {
            /* A Red City at (2, 0) does not produce a Red Archer when there is a Red Legion at (2, 0). */
            { Red.City().At(2, 0).Generating(10).ProductionPerRound.Producing(Archers), Red.Legion().At(2, 0) },
            //
            /* A Blue City at (4, 3) does not produce a Blue Legion when there is a Blue Archer at (4, 3). */
            { Blue.City().At(4, 3).Generating(15).ProductionPerRound.Producing(Legions), Blue.Archer().At(4, 3) },
        };

        #region HELPERS: Shortcuts

        private static Player Red => new Player("Red");
        private static Player Blue => new Player("Blue");

        private static IProductionProject Nothing
            => StubProductionProject(int.MaxValue, DummyUnitFactory);

        private static IProductionProject Archers
            => StubProductionProject(10, new GenericUnitFactoryAdapter<Archer>(StubFactories.SimpleArcherFactory));

        private static IProductionProject Legions
            => StubProductionProject(15, new GenericUnitFactoryAdapter<Legion>(StubFactories.SimpleLegionFactory));

        #endregion

        #region HELPERS: Stubs

        private static IProductionProject StubProductionProject(int cost, IUnitFactory factory)
        {
            var stubProductionProject = A.Fake<IProductionProject>();

            A.CallTo(() => stubProductionProject.Cost).Returns(cost);
            A.CallTo(() => stubProductionProject.Factory).Returns(factory);

            return stubProductionProject;
        }

        #endregion

        #region HELPERS: Dummies

        private static BeginningNextRoundEventArgs DummyEventArgs => new BeginningNextRoundEventArgs(42);
        private static IUnitFactory DummyUnitFactory => A.Fake<IUnitFactory>();

        #endregion
    }
}
