using ExtenCiv.Players;

namespace ExtenCiv.Cities
{
    /// <summary>
    ///     A city belongs to a player and produces new units.
    /// </summary>
    public interface ICity
    {
        /// <summary>
        ///     The player that controls this city.
        /// </summary>
        Player Owner { get; }

        /// <summary>
        ///     The population size of this city.
        /// </summary>
        int Population { get; }
    }
}
