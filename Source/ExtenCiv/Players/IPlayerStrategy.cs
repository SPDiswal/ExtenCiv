using System.Collections.Generic;

namespace ExtenCiv.Players
{
    public interface IPlayerStrategy
    {
        IEnumerable<Player> Players { get; }
    }
}
