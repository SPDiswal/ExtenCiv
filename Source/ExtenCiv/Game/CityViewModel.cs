using ExtenCiv.Players;

namespace ExtenCiv.Game
{
    /// <summary>
    ///     A city view model exposes a readonly facade of a city.
    /// </summary>
    public class CityViewModel
    {
        /// <summary>
        ///     The player that controls this city.
        /// </summary>
        public Player Owner { get; set; }

        /// <summary>
        ///     The population size of this city.
        /// </summary>
        public int Population { get; set; }
    }
}
