using ExtenCiv.Players.Events;
using ExtenCiv.WorldAges.Abstractions;

namespace ExtenCiv.WorldAges
{
    /// <summary>
    ///     The world age progresses at a decelerating pace, starting in 4000 BCE.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Notifier of when the next round begins.
    /// </summary>
    public sealed class DeceleratingWorldAge : IWorldAge
    {
        public DeceleratingWorldAge(INotifyBeginningNextRound notifier)
        {
            notifier.BeginningNextRound += OnBeginningNextRound;
        }

        private void OnBeginningNextRound(object sender, BeginningNextRoundEventArgs e)
        {
            if (CurrentWorldAge < -100) CurrentWorldAge += 100;
            else if (CurrentWorldAge == -100) CurrentWorldAge = -1;
            else if (CurrentWorldAge == -1) CurrentWorldAge = 1;
            else if (CurrentWorldAge == 1) CurrentWorldAge = 50;
            else if (CurrentWorldAge >= 50 && CurrentWorldAge < 1750) CurrentWorldAge += 50;
            else if (CurrentWorldAge >= 1750 && CurrentWorldAge < 1900) CurrentWorldAge += 25;
            else if (CurrentWorldAge >= 1900 && CurrentWorldAge < 1970) CurrentWorldAge += 5;
            else CurrentWorldAge += 1;
        }

        /// <summary>
        ///     The current age of the world, in years.
        /// </summary>
        public int CurrentWorldAge { get; private set; } = -4000;
    }
}
