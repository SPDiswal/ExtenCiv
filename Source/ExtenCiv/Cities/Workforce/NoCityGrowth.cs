using ExtenCiv.Cities.Abstractions;

namespace ExtenCiv.Cities.Workforce
{
    /// <summary>
    ///     The generated food is fixed to zero points per round.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Decorated city.
    /// </summary>
    public sealed class NoCityGrowth<TCity> : CityDecorator<TCity> where TCity : ICity<TCity>
    {
        public NoCityGrowth(ICity<TCity> city) : base(city) { }

        /// <summary>
        ///     The generated number of surplus food points per round in this city.
        /// </summary>
        public override int GeneratedFood => 0;
    }
}
