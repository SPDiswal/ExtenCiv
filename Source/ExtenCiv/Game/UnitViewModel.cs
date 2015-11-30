using ExtenCiv.Players;

namespace ExtenCiv.Game
{
    /// <summary>
    ///     A unit view model exposes a readonly facade of a unit.
    /// </summary>
    public class UnitViewModel
    {
        /// <summary>
        ///     The type string of this unit.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     The player that controls this unit.
        /// </summary>
        public Player Owner { get; set; }

        /// <summary>
        ///     The remaining movement points of this unit for the current round.
        /// </summary>
        public int RemainingMovement { get; set; }

        /// <summary>
        ///     The total movement points of this unit.
        /// </summary>
        public int TotalMovement { get; set; }

        /// <summary>
        ///     The attacking strength of this unit.
        /// </summary>
        public int Attack { get; set; }

        /// <summary>
        ///     The defensive strength of this unit.
        /// </summary>
        public int Defence { get; set; }
    }
}
