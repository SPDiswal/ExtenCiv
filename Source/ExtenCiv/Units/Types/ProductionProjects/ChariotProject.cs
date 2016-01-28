using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Units.Types.Factories;
using ExtenCiv.Units.Types.Factories.Abstractions;

namespace ExtenCiv.Units.Types.ProductionProjects
{
    /// <summary>
    ///     A chariot costs 20 production points to produce in a city.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Chariot factory.
    /// </summary>
    public sealed class ChariotProject : IProductionProject
    {
        public ChariotProject(IUnitFactory<Chariot> chariotFactory)
        {
            Factory = new GenericUnitFactoryAdapter<Chariot>(chariotFactory);
        }

        /// <summary>
        ///     The factory that spawns the unit in production.
        /// </summary>
        public IUnitFactory Factory { get; }

        /// <summary>
        ///     The cost of the unit in production.
        /// </summary>
        public int Cost { get; } = 20;
    }
}
