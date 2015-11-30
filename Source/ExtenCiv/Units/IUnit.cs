using ExtenCiv.Players;

namespace ExtenCiv.Units
{
    /// <summary>
    ///     A unit belongs to a player, can be moved around on the game board, engage in combat and perform special actions.
    /// </summary>
    public interface IUnit
    {
        /// <summary>
        ///     The player that controls this unit.
        /// </summary>
        Player Owner { get; }

        /// <summary>
        ///     The remaining movement points of this unit for the current round.
        /// </summary>
        int RemainingMovement { get; set; }

        /// <summary>
        ///     The total movement points of this unit.
        /// </summary>
        int TotalMovement { get; }

        /// <summary>
        ///     The attacking strength of this unit.
        /// </summary>
        int Attack { get; }

        /// <summary>
        ///     The defensive strength of this unit.
        /// </summary>
        int Defence { get; }

        /// <summary>
        ///     The production costs of this unit.
        /// </summary>
        int ProductionCost { get; }

        /// <summary>
        ///     Performs the special action of this unit.
        /// </summary>
        void PerformAction();
    }
}
