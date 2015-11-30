using ExtenCiv.Units;

namespace ExtenCiv.UnitActions
{
    /// <summary>
    ///     A fortifiable unit can perform a special action that doubles its defensive strength, but makes it stationary.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Decorated unit.
    /// </summary>
    public sealed class FortificationAction : UnitDecorator
    {
        private bool isFortified;

        public FortificationAction(IUnit unit) : base(unit) { }

        /// <summary>
        ///     The remaining movement points of this unit for the current round.
        /// </summary>
        public override int RemainingMovement => isFortified ? 0 : base.RemainingMovement;

        /// <summary>
        ///     The defensive strength of this unit.
        /// </summary>
        public override int Defence => isFortified ? 2 * base.Defence : base.Defence;

        /// <summary>
        ///     Performs the special action of this unit.
        /// </summary>
        public override void PerformAction()
        {
            base.PerformAction();
            isFortified = !isFortified;
        }
    }
}
