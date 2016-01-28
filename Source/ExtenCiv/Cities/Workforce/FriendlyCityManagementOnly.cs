using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Players.Abstractions;

namespace ExtenCiv.Cities.Workforce
{
    /// <summary>
    ///     A player can only set the production project in cities that belongs to him.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Decorated city,
    ///     Turn-taking.
    /// </summary>
    public sealed class FriendlyCityManagementOnly<TCity> : CityDecorator<TCity> where TCity : ICity<TCity>
    {
        private readonly ITurnTaking turnTaking;

        public FriendlyCityManagementOnly(ICity<TCity> city, ITurnTaking turnTaking) : base(city)
        {
            this.turnTaking = turnTaking;
        }

        /// <summary>
        ///     The current production project of this city.
        /// </summary>
        public override IProductionProject ProductionProject
        {
            set
            {
                if (turnTaking.CurrentPlayer == Owner)
                    base.ProductionProject = value;
            }
        }
    }
}
