namespace ExtenCiv.WorldAges
{
    /// <summary>
    ///     The world age progresses at a decelerating rate, starting in 4000 BCE.
    ///     <para></para>
    ///     Dependencies: None.
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
