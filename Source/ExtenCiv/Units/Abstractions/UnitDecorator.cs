using System;
using ExtenCiv.Players;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Units.Abstractions
{
    /// <summary>
    ///     An abstract helper class for unit decorators.
    /// </summary>
    public abstract class UnitDecorator<TUnit> : IUnit<TUnit> where TUnit : IUnit<TUnit>
    {
        private readonly IUnit<TUnit> unit;

        protected UnitDecorator(IUnit<TUnit> unit) { this.unit = unit; }

        /// <summary>
        ///     The unique identifier of this unit.
        /// </summary>
        public virtual Guid Id
        {
            get { return unit.Id; }
            set { unit.Id = value; }
        }

        /// <summary>
        ///     The type string identifying the type of this unit.
        /// </summary>
        public virtual string Type
        {
            get { return unit.Type; }
            set { unit.Type = value; }
        }

        /// <summary>
        ///     The location of this unit on the world map.
        /// </summary>
        public virtual ITile Location
        {
            get { return unit.Location; }
            set { unit.Location = value; }
        }

        /// <summary>
        ///     The player that controls this object.
        /// </summary>
        public virtual Player Owner
        {
            get { return unit.Owner; }
            set { unit.Owner = value; }
        }

        /// <summary>
        ///     The remaining movement points of this unit for the current round.
        /// </summary>
        public virtual int RemainingMoves
        {
            get { return unit.RemainingMoves; }
            set { unit.RemainingMoves = value; }
        }

        /// <summary>
        ///     The total movement points of this unit.
        /// </summary>
        public virtual int TotalMoves
        {
            get { return unit.TotalMoves; }
            set { unit.TotalMoves = value; }
        }

        /// <summary>
        ///     The attacking strength of this unit.
        /// </summary>
        public virtual int Attack
        {
            get { return unit.Attack; }
            set { unit.Attack = value; }
        }

        /// <summary>
        ///     The defensive strength of this unit.
        /// </summary>
        public virtual int Defence
        {
            get { return unit.Defence; }
            set { unit.Defence = value; }
        }

        /// <summary>
        ///     Moves this unit to the specified location.
        /// </summary>
        /// <param name="destination">The tile to move the unit to.</param>
        public virtual void MoveTo(ITile destination) => unit.MoveTo(destination);

        /// <summary>
        ///     Performs the special action of this unit.
        /// </summary>
        public virtual void PerformAction() => unit.PerformAction();
    }
}
