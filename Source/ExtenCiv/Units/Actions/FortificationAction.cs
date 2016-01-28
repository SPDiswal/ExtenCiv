using ExtenCiv.Units.Abstractions;

namespace ExtenCiv.Units.Actions
{
    /// <summary>
    ///     A fortifiable unit can perform a special action that doubles its defensive strength, but makes it stationary.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Decorated unit.
    /// </summary>
    public sealed class FortificationAction<TUnit> : UnitDecorator<TUnit> where TUnit : IUnit<TUnit>
    {
        private bool isFortified;

        public FortificationAction(IUnit<TUnit> unit) : base(unit) { }

        /// <summary>
        ///     The remaining movement points of this unit for the current round.
        /// </summary>
        public override int RemainingMoves => isFortified ? 0 : base.RemainingMoves;

        /// <summary>
        ///     The defensive strength of this unit.
        /// </summary>
        public override int Defence => (isFortified ? 2 : 1) * base.Defence;

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
