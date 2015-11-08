using ExtenCiv.Players;

namespace ExtenCiv.Cities
{
    /// <summary>
    ///     A city belongs to a player and produces new units.
    /// </summary>
    public interface ICity
    {
        Player Owner { get; }

        int Population { get; }
    }
}
