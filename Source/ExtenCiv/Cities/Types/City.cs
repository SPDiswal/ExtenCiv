using System;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.ProductionProjects;
using ExtenCiv.Players;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Cities.Types
{
    public sealed class City : ICity<City>
    {
        /// <summary>
        ///     The unique identifier of this city.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        ///     The type string identifying the type of this city.
        /// </summary>
        public string Type { get; set; } = "City";

        /// <summary>
        ///     The location of this city on the world map.
        /// </summary>
        public ITile Location { get; set; }

        /// <summary>
        ///     The player that controls this city.
        /// </summary>
        public Player Owner { get; set; } = Player.Nobody;

        /// <summary>
        ///     The population size of this city.
        /// </summary>
        public int Population { get; set; } = 1;

        /// <summary>
        ///     The accumulated number of points in the food treasury of this city.
        /// </summary>
        public int FoodTreasury { get; set; } = 0;

        /// <summary>
        ///     The accumulated number of points in the production treasury of this city.
        /// </summary>
        public int ProductionTreasury { get; set; } = 0;

        /// <summary>
        ///     The generated number of surplus food points per round in this city.
        /// </summary>
        public int GeneratedFood { get; set; }

        /// <summary>
        ///     The generated number of production points per round in this city.
        /// </summary>
        public int GeneratedProduction { get; set; }

        /// <summary>
        ///     The current production project of this city.
        /// </summary>
        public IProductionProject ProductionProject { get; set; } = new EmptyProject(); // TODO: Unit test.

        public override string ToString() => $"{Owner} {Type}";
    }
}
