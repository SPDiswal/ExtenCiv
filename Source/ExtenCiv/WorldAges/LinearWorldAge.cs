using ExtenCiv.Players.Events;
using ExtenCiv.WorldAges.Abstractions;

namespace ExtenCiv.WorldAges
{
    /// <summary>
    ///     The world age progresses linearly by 100 years in every round, starting in 4000 BCE.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Notifier of when the next round begins.
    /// </summary>
    public sealed class LinearWorldAge : IWorldAge
    {
        public LinearWorldAge(INotifyBeginningNextRound notifier)
        {
            notifier.BeginningNextRound += OnBeginningNextRound;
        }

        private void OnBeginningNextRound(object sender, BeginningNextRoundEventArgs e) => CurrentWorldAge += 100;

        /// <summary>
        ///     The current age of the world, in years.
        /// </summary>
        public int CurrentWorldAge { get; private set; } = -4000;
    }
}
