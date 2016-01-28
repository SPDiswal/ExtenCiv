using System.Collections.Generic;
using System.Linq;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Units.Movement
{
    /// <summary>
    ///     Friendly units are not allowed to stack, that is, there can only be a single unit at a time on a certain tile.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Decorated unit,
    ///     Set of units.
    /// </summary>
    public sealed class NoFriendlyUnitStacking<TUnit> : UnitDecorator<TUnit> where TUnit : IUnit<TUnit>
    {
        private readonly ISet<IUnit> units;

        public NoFriendlyUnitStacking(IUnit<TUnit> unit, ISet<IUnit> units) : base(unit) { this.units = units; }

        /// <summary>
        ///     Moves this unit to the specified location.
        /// </summary>
        /// <param name="destination">The tile to move the unit to.</param>
        public override void MoveTo(ITile destination)
        {
            if (!units.Any(unit => unit.Location.Equals(destination) && unit.Owner == Owner))
                base.MoveTo(destination);
        }
    }
}
