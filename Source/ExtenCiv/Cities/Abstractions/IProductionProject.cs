using ExtenCiv.Units.Types.Factories.Abstractions;

namespace ExtenCiv.Cities.Abstractions
{
    /// <summary>
    ///     A production project defines the unit that a city is currently producing as well as the cost of it.
    /// </summary>
    public interface IProductionProject
    {
        /// <summary>
        ///     The factory that spawns the unit in production.
        /// </summary>
        IUnitFactory Factory { get; }

        /// <summary>
        ///     The cost of the unit in production.
        /// </summary>
        int Cost { get; }
    }
}
