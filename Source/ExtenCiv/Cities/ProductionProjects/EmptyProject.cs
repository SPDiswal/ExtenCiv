using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Units.Types.Factories.Abstractions;

namespace ExtenCiv.Cities.ProductionProjects
{
    /// <summary>
    ///     A production project that does not spawn any units.
    /// </summary>
    public sealed class EmptyProject : IProductionProject
    {
        /// <summary>
        ///     The factory that spawns the unit in production.
        /// </summary>
        public IUnitFactory Factory => null;

        /// <summary>
        ///     The cost of the unit in production.
        /// </summary>
        public int Cost { get; } = int.MaxValue;

        // TODO: Unit test.
    }
}
