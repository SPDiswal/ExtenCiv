using System;
using ExtenCiv.Players;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Cities.Abstractions
{
    /// <summary>
    ///     An abstract helper class for city decorators.
    /// </summary>
    public abstract class CityDecorator<TCity> : ICity<TCity> where TCity : ICity<TCity>
    {
        private readonly ICity<TCity> city;

        protected CityDecorator(ICity<TCity> city) { this.city = city; }

        /// <summary>
        ///     The unique identifier of this city.
        /// </summary>
        public virtual Guid Id
        {
            get { return city.Id; }
            set { city.Id = value; }
        }

        /// <summary>
        ///     The type string identifying the type of this city.
        /// </summary>
        public virtual string Type
        {
            get { return city.Type; }
            set { city.Type = value; }
        }

        /// <summary>
        ///     The location of this city on the world map.
        /// </summary>
        public virtual ITile Location
        {
            get { return city.Location; }
            set { city.Location = value; }
        }

        /// <summary>
        ///     The player that controls this city.
        /// </summary>
        public virtual Player Owner
        {
            get { return city.Owner; }
            set { city.Owner = value; }
        }

        /// <summary>
        ///     The population size of this city.
        /// </summary>
        public virtual int Population
        {
            get { return city.Population; }
            set { city.Population = value; }
        }

        /// <summary>
        ///     The accumulated number of points in the food treasury of this city.
        /// </summary>
        public virtual int FoodTreasury
        {
            get { return city.FoodTreasury; }
            set { city.FoodTreasury = value; }
        }

        /// <summary>
        ///     The accumulated number of points in the production treasury of this city.
        /// </summary>
        public virtual int ProductionTreasury
        {
            get { return city.ProductionTreasury; }
            set { city.ProductionTreasury = value; }
        }

        /// <summary>
        ///     The generated number of surplus food points per round in this city.
        /// </summary>
        public virtual int GeneratedFood
        {
            get { return city.GeneratedFood; }
            set { city.GeneratedFood = value; }
        }

        /// <summary>
        ///     The generated number of production points per round in this city.
        /// </summary>
        public virtual int GeneratedProduction
        {
            get { return city.GeneratedProduction; }
            set { city.GeneratedProduction = value; }
        }

        /// <summary>
        ///     The current production project of this city.
        /// </summary>
        public virtual IProductionProject ProductionProject
        {
            get { return city.ProductionProject; }
            set { city.ProductionProject = value; }
        }
    }
}
