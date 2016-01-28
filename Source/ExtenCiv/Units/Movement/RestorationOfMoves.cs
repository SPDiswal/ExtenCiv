using ExtenCiv.Players.Events;
using ExtenCiv.Units.Abstractions;

namespace ExtenCiv.Units.Movement
{
    /// <summary>
    ///     The remaining number of moves is restored to the total number of moves in the beginning of every round.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Decorated unit,
    ///     Notifier of when the next round begins.
    /// </summary>
    public sealed class RestorationOfMoves<TUnit> : UnitDecorator<TUnit> where TUnit : IUnit<TUnit>
    {
        public RestorationOfMoves(IUnit<TUnit> unit, INotifyBeginningNextRound notifier) : base(unit)
        {
            /* TODO There is a memory leak here. The unit must unsubscribe from the event when it has been defeated 
                    or otherwise removed from the world map in order to garbage-collect it. */

            notifier.BeginningNextRound += OnBeginningNextRound;
        }

        private void OnBeginningNextRound(object sender, BeginningNextRoundEventArgs e) { RemainingMoves = TotalMoves; }
    }
}
