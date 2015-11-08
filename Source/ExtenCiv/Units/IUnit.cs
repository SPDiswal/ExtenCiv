using ExtenCiv.Players;

namespace ExtenCiv.Units
{
    /// <summary>
    ///     A unit belongs to a player, can be moved around on the game board and engage in combat.
    /// </summary>
    public interface IUnit
    {
        Player Owner { get; }

        int Movement { get; }

        int Defence { get; }

        int Attack { get; }
    }
}
