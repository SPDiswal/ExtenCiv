using ExtenCiv.Players;

namespace ExtenCiv.Cities
{
    public sealed class City : ICity
    {
        public City(Player owner, int population)
        {
            Owner = owner;
            Population = population;
        }

        /// <summary>
        ///     The player that controls this city.
        /// </summary>
        public Player Owner { get; }

        /// <summary>
        ///     The population size of this city.
        /// </summary>
        public int Population { get; }
    }
}
