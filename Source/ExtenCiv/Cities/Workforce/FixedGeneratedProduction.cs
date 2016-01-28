using ExtenCiv.Cities.Abstractions;

namespace ExtenCiv.Cities.Workforce
{
    /// <summary>
    ///     The generated production is fixed to six points per round.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Decorated city.
    /// </summary>
    public sealed class FixedGeneratedProduction<TCity> : CityDecorator<TCity> where TCity : ICity<TCity>
    {
        public FixedGeneratedProduction(ICity<TCity> city) : base(city) { }

        /// <summary>
        ///     The generated number of production points per round in this city.
        /// </summary>
        public override int GeneratedProduction => 6;
    }
}
