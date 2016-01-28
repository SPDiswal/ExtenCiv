using ExtenCiv.Units.Abstractions;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Units.Movement
{
    /// <summary>
    ///     Units can only move as many tiles as they have moves left.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Decorated unit.
    /// </summary>
    public sealed class LimitedMoveRange<TUnit> : UnitDecorator<TUnit> where TUnit : IUnit<TUnit>
    {
        public LimitedMoveRange(IUnit<TUnit> unit) : base(unit) { }

        /// <summary>
        ///     Moves this unit to the specified location.
        /// </summary>
        /// <param name="destination">The tile to move the unit to.</param>
        public override void MoveTo(ITile destination)
        {
            if (Location.DistanceTo(destination) == 1 && RemainingMoves == 1)
                base.MoveTo(destination);
        }
    }
}
