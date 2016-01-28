using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Units.Types.Factories;
using ExtenCiv.Units.Types.Factories.Abstractions;

namespace ExtenCiv.Units.Types.ProductionProjects
{
    /// <summary>
    ///     A legion costs 15 production points to produce in a city.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Legion factory.
    /// </summary>
    public sealed class LegionProject : IProductionProject
    {
        public LegionProject(IUnitFactory<Legion> legionFactory)
        {
            Factory = new GenericUnitFactoryAdapter<Legion>(legionFactory);
        }

        /// <summary>
        ///     The factory that spawns the unit in production.
        /// </summary>
        public IUnitFactory Factory { get; }

        /// <summary>
        ///     The cost of the unit in production.
        /// </summary>
        public int Cost { get; } = 15;
    }
}
