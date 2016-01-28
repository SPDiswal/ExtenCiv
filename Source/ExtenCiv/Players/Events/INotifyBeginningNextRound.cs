using System;

namespace ExtenCiv.Players.Events
{
    /// <summary>
    ///     Announces when the next round begins.
    /// </summary>
    public interface INotifyBeginningNextRound
    {
        event EventHandler<BeginningNextRoundEventArgs> BeginningNextRound;
    }
}
