using System;
using ExtenCiv.Players;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Cities.Abstractions
{
    /// <summary>
    ///     A city belongs to a player and produces new units.
    /// </summary>
    public interface ICity
    {
        /// <summary>
        ///     The unique identifier of this city.
        /// </summary>
        Guid Id { get; set; }

        /// <summary>
        ///     The type string identifying the type of this city.
        /// </summary>
        string Type { get; set; }

        /// <summary>
        ///     The location of this city on the world map.
        /// </summary>
        ITile Location { get; set; }

        /// <summary>
        ///     The player that controls this city.
        /// </summary>
        Player Owner { get; set; }

        /// <summary>
        ///     The population size of this city.
        /// </summary>
        int Population { get; set; }

        /// <summary>
        ///     The number of points in the food treasury of this city.
        /// </summary>
        int FoodTreasury { get; set; }

        /// <summary>
        ///     The number of points in the production treasury of this city.
        /// </summary>
        int ProductionTreasury { get; set; }

        /// <summary>
        ///     The generated number of surplus food points per round in this city.
        /// </summary>
        int GeneratedFood { get; set; }

        /// <summary>
        ///     The generated number of production points per round in this city.
        /// </summary>
        int GeneratedProduction { get; set; }

        /// <summary>
        ///     The current production project of this city.
        /// </summary>
        IProductionProject ProductionProject { get; set; }
    }

    /// <summary>
    ///     A city belongs to a player and produces new units.
    /// </summary>
    public interface ICity<TCity> : ICity where TCity : ICity<TCity>
    {
    }
}
