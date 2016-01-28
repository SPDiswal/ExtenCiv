using ExtenCiv.Players.Abstractions;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.Units.Movement
{
    /// <summary>
    ///     A player can only move and perform special actions of units that belongs to him.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Decorated unit,
    ///     Turn-taking.
    /// </summary>
    public sealed class FriendlyUnitManagementOnly<TUnit> : UnitDecorator<TUnit> where TUnit : IUnit<TUnit>
    {
        private readonly ITurnTaking turnTaking;

        public FriendlyUnitManagementOnly(IUnit<TUnit> unit, ITurnTaking turnTaking) : base(unit)
        {
            this.turnTaking = turnTaking;
        }

        /// <summary>
        ///     Moves this unit to the specified location.
        /// </summary>
        /// <param name="destination">The tile to move the unit to.</param>
        public override void MoveTo(ITile destination)
        {
            if (turnTaking.CurrentPlayer == Owner)
                base.MoveTo(destination);
        }

        /// <summary>
        ///     Performs the special action of this unit.
        /// </summary>
        public override void PerformAction()
        {
            if (turnTaking.CurrentPlayer == Owner)
                base.PerformAction();
        }
    }
}
