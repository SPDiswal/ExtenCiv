namespace ExtenCiv.WorldAges
{
    /// <summary>
    /// The world age progresses at a decelerating rate, starting in 4000 BCE.
    /// <para></para>
    /// Between 4000 BCE and 1 BCE, it ages by 100 years every round.
    /// <para></para>
    /// When the world age is 1 BCE, it advances to 1 CE in the following round.
    /// <para></para>
    /// Between 1 CE and 1750, it ages by 50 years every round.
    /// <para></para>
    /// Between 1750 and 1900, it ages by 25 years every round.
    /// <para></para>
    /// Between 1900 and 1970, it ages by five years every round.
    /// <para></para>
    /// After 1970, it ages by one year every round.
    /// </summary>
    public sealed class DeceleratingWorldAge : IWorldAgeStrategy
    {
        /// <summary>
        ///     The current age of the world, in years.
        /// </summary>
        public int WorldAge { get; private set; } = -4000;

        /// <summary>
        ///     Moves one step forward in time.
        /// </summary>
        public void AdvanceWorldAge()
        {
            if (WorldAge < -100) WorldAge += 100;
            else if (WorldAge == -100) WorldAge = -1;
            else if (WorldAge == -1) WorldAge = 1;
            else if (WorldAge == 1) WorldAge = 50;
            else if (WorldAge >= 50 && WorldAge < 1750) WorldAge += 50;
            else if (WorldAge >= 1750 && WorldAge < 1900) WorldAge += 25;
            else if (WorldAge >= 1900 && WorldAge < 1970) WorldAge += 5;
            else WorldAge += 1;
        }
    }
}
