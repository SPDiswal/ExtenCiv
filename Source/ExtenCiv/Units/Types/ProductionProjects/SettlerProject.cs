using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Units.Types.Factories;
using ExtenCiv.Units.Types.Factories.Abstractions;

namespace ExtenCiv.Units.Types.ProductionProjects
{
    /// <summary>
    ///     A settler costs 30 production points to produce in a city.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Settler factory.
    /// </summary>
    public sealed class SettlerProject : IProductionProject
    {
        public SettlerProject(IUnitFactory<Settler> settlerFactory)
        {
            Factory = new GenericUnitFactoryAdapter<Settler>(settlerFactory);
        }

        /// <summary>
        ///     The factory that spawns the unit in production.
        /// </summary>
        public IUnitFactory Factory { get; }

        /// <summary>
        ///     The cost of the unit in production.
        /// </summary>
        public int Cost { get; } = 30;
    }
}
