using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Units.Types.Factories;
using ExtenCiv.Units.Types.Factories.Abstractions;

namespace ExtenCiv.Units.Types.ProductionProjects
{
    /// <summary>
    ///     An archer costs 10 production points to produce in a city.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Archer factory.
    /// </summary>
    public sealed class ArcherProject : IProductionProject
    {
        public ArcherProject(IUnitFactory<Archer> archerFactory)
        {
            Factory = new GenericUnitFactoryAdapter<Archer>(archerFactory);
        }

        /// <summary>
        ///     The factory that spawns the unit in production.
        /// </summary>
        public IUnitFactory Factory { get; }

        /// <summary>
        ///     The cost of the unit in production.
        /// </summary>
        public int Cost { get; } = 10;
    }
}
