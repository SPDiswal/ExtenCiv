using ExtenCiv.Units.Abstractions;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Units.Movement
{
    /// <summary>
    ///     The number of remaining moves is decremented by one per tile moved.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Decorated unit.
    /// </summary>
    public sealed class MoveCosts<TUnit> : UnitDecorator<TUnit> where TUnit : IUnit<TUnit>
    {
        public MoveCosts(IUnit<TUnit> unit) : base(unit) { }

        /// <summary>
        ///     Moves this unit to the specified location.
        /// </summary>
        /// <param name="destination">The tile to move the unit to.</param>
        public override void MoveTo(ITile destination)
        {
            var distance = Location.DistanceTo(destination);
            RemainingMoves -= distance;

            base.MoveTo(destination);
        }
    }
}
