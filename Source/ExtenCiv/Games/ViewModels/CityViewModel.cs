using ExtenCiv.Players;

namespace ExtenCiv.Games.ViewModels
{
    /// <summary>
    ///     A city view model exposes a readonly facade of a city.
    /// </summary>
    public class CityViewModel
    {
        /// <summary>
        ///     The type string of this city.
        /// </summary>
        public string Type { get; set; }

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
