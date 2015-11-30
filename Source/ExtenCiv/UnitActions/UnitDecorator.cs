using ExtenCiv.Players;
using ExtenCiv.Units;

namespace ExtenCiv.UnitActions
{
    /// <summary>
    ///     An abstract helper class for unit decorators.
    /// </summary>
    public abstract class UnitDecorator : IUnit
    {
        private readonly IUnit unit;

        protected UnitDecorator(IUnit unit) { this.unit = unit; }

        /// <summary>
        ///     The player that controls this object.
        /// </summary>
        public virtual Player Owner => unit.Owner;

        /// <summary>
        ///     The remaining movement points of this unit for the current round.
        /// </summary>
        public virtual int RemainingMovement
        {
            get { return unit.RemainingMovement; }
            set { unit.RemainingMovement = value; }
        }

        /// <summary>
        ///     The total movement points of this unit.
        /// </summary>
        public virtual int TotalMovement => unit.TotalMovement;

        /// <summary>
        ///     The attacking strength of this unit.
        /// </summary>
        public virtual int Attack => unit.Attack;

        /// <summary>
        ///     The defensive strength of this unit.
        /// </summary>
        public virtual int Defence => unit.Defence;

        /// <summary>
        ///     The production costs of this unit.
        /// </summary>
        public virtual int ProductionCost => unit.ProductionCost;

        /// <summary>
        ///     Performs the special action of this unit.
        /// </summary>
        public virtual void PerformAction() { unit.PerformAction(); }
    }
}
