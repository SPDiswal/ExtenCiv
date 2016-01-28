using System.Collections.Generic;
using System.Linq;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Players;
using ExtenCiv.Winners.Abstractions;

namespace ExtenCiv.Winners
{
    /// <summary>
    ///     The winner is the player that controls all cities on the world map.
    ///     If there are multiple players controlling cities, there is no winner.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Set of cities.
    /// </summary>
    public sealed class CityConquerorWins : IWinnerStrategy
    {
        private readonly ISet<ICity> cities;

        public CityConquerorWins(ISet<ICity> cities) { this.cities = cities; }

        /// <summary>
        ///     The winner of the game, or <c>Player.Nobody</c> if there is no winner yet.
        /// </summary>
        public Player Winner
        {
            get
            {
                var cityOwners = cities.Select(city => city.Owner).Distinct().ToArray();
                return cityOwners.Length == 1 ? cityOwners.Single() : Player.Nobody;
            }
        }
    }
}
