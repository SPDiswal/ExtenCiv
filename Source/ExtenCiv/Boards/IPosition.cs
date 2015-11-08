using System.Collections.Generic;

namespace ExtenCiv.Boards
{
    public interface IPosition
    {
        /// <summary>
        ///     Returns the set of neighbour positions.
        /// </summary>
        IEnumerable<IPosition> Neighbours { get; }
    }
}
