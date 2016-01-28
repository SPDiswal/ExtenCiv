using ExtenCiv.Units.Abstractions;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Units.Movement
{
    /// <summary>
    ///     The unit can move across the world map.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Decorated unit.
    /// </summary>
    public sealed class Movability<TUnit> : UnitDecorator<TUnit> where TUnit : IUnit<TUnit>
    {
        public Movability(IUnit<TUnit> unit) : base(unit) { }

        /// <summary>
        ///     Moves this unit to the specified location.
        /// </summary>
        /// <param name="destination">The tile to move the unit to.</param>
        public override void MoveTo(ITile destination)
        {
            base.MoveTo(destination);
            Location = destination;
        }
    }
}
