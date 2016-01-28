using System;

namespace ExtenCiv.Players.Events
{
    public class BeginningNextRoundEventArgs : EventArgs
    {
        public BeginningNextRoundEventArgs(int round) { Round = round; }

        /// <summary>
        ///     The number of the round that has just begun.
        /// </summary>
        public int Round { get; }
    }
}
