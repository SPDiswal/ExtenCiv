using ExtenCiv.Units.Types;
using ExtenCiv.Units.Types.Factories.Abstractions;
using ExtenCiv.Units.Types.ProductionProjects;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace ExtenCiv.Tests.Unit.Units.Types.ProductionProjects
{
    public sealed class TestProductionProjects
    {
        // TODO: Refactor to use theories.

        /// <summary>
        ///     Archers cost 10 production points.
        /// </summary>
        [Fact]
        public void TheCost_Is10_WhenProducingArchers()
        {
            // :::: ARRANGE ::::
            var dummyFactory = A.Fake<IUnitFactory<Archer>>();
            var project = new ArcherProject(dummyFactory);

            // :::: ACT ::::
            var actualCost = project.Cost;

            // :::: ASSERT ::::
            actualCost.Should().Be(10);
        }

        /// <summary>
        ///     An archer factory is provided in the constructor of the production project.
        /// </summary>
        [Fact]
        public void TheUnitFactory_IsProvidedInTheConstructor_WhenProducingArchers()
        {
            // :::: ARRANGE ::::
            var dummyFactory = A.Fake<IUnitFactory<Archer>>();
            var project = new ArcherProject(dummyFactory);

            // :::: ACT ::::
            var actualFactory = project.Factory;

            // :::: ASSERT ::::
            actualFactory.Should().BeSameAs(dummyFactory);
        }

        /// <summary>
        ///     Legions cost 15 production points.
        /// </summary>
        [Fact]
        public void TheCost_Is15_WhenProducingLegions()
        {
            // :::: ARRANGE ::::
            var dummyFactory = A.Fake<IUnitFactory<Legion>>();
            var project = new LegionProject(dummyFactory);

            // :::: ACT ::::
            var actualCost = project.Cost;

            // :::: ASSERT ::::
            actualCost.Should().Be(15);
        }

        /// <summary>
        ///     A legion factory is provided in the constructor of the production project.
        /// </summary>
        [Fact]
        public void TheUnitFactory_IsProvidedInTheConstructor_WhenProducingLegions()
        {
            // :::: ARRANGE ::::
            var dummyFactory = A.Fake<IUnitFactory<Legion>>();
            var project = new LegionProject(dummyFactory);

            // :::: ACT ::::
            var actualFactory = project.Factory;

            // :::: ASSERT ::::
            actualFactory.Should().BeSameAs(dummyFactory);
        }

        /// <summary>
        ///     Settlers cost 30 production points.
        /// </summary>
        [Fact]
        public void TheCost_Is30_WhenProducingSettlers()
        {
            // :::: ARRANGE ::::
            var dummyFactory = A.Fake<IUnitFactory<Settler>>();
            var project = new SettlerProject(dummyFactory);

            // :::: ACT ::::
            var actualCost = project.Cost;

            // :::: ASSERT ::::
            actualCost.Should().Be(30);
        }

        /// <summary>
        ///     A settler factory is provided in the constructor of the production project.
        /// </summary>
        [Fact]
        public void TheUnitFactory_IsProvidedInTheConstructor_WhenProducingSettlers()
        {
            // :::: ARRANGE ::::
            var dummyFactory = A.Fake<IUnitFactory<Settler>>();
            var project = new SettlerProject(dummyFactory);

            // :::: ACT ::::
            var actualFactory = project.Factory;

            // :::: ASSERT ::::
            actualFactory.Should().BeSameAs(dummyFactory);
        }

        /// <summary>
        ///     Chariots cost 20 production points.
        /// </summary>
        [Fact]
        public void TheCost_Is20_WhenProducingChariots()
        {
            // :::: ARRANGE ::::
            var dummyFactory = A.Fake<IUnitFactory<Chariot>>();
            var project = new ChariotProject(dummyFactory);

            // :::: ACT ::::
            var actualCost = project.Cost;

            // :::: ASSERT ::::
            actualCost.Should().Be(20);
        }

        /// <summary>
        ///     A chariot factory is provided in the constructor of the production project.
        /// </summary>
        [Fact]
        public void TheUnitFactory_IsProvidedInTheConstructor_WhenProducingChariots()
        {
            // :::: ARRANGE ::::
            var dummyFactory = A.Fake<IUnitFactory<Chariot>>();
            var project = new ChariotProject(dummyFactory);

            // :::: ACT ::::
            var actualFactory = project.Factory;

            // :::: ASSERT ::::
            actualFactory.Should().BeSameAs(dummyFactory);
        }
    }
}
