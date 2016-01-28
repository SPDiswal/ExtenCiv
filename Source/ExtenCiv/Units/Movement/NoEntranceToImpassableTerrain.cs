using System.Collections.Generic;
using System.Linq;
using ExtenCiv.Terrains.Abstractions;
using ExtenCiv.Terrains.Types;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Units.Movement
{
    /// <summary>
    ///     Units cannot move over Mountains or Oceans.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Decorated unit,
    ///     Set of terrains.
    /// </summary>
    public sealed class NoEntranceToImpassableTerrain<TUnit> : UnitDecorator<TUnit> where TUnit : IUnit<TUnit>
    {
        private readonly ISet<ITerrain> terrains;

        public NoEntranceToImpassableTerrain(IUnit<TUnit> unit, ISet<ITerrain> terrains) : base(unit)
        {
            this.terrains = terrains;
        }

        /// <summary>
        ///     Moves this unit to the specified location.
        /// </summary>
        /// <param name="destination">The tile to move the unit to.</param>
        public override void MoveTo(ITile destination)
        {
            var terrainAtDestination = terrains.SingleOrDefault(terrain => terrain.Location.Equals(destination));

            if (!(terrainAtDestination is Mountains || terrainAtDestination is Oceans))
                base.MoveTo(destination);
        }
    }
}
