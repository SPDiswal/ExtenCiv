using System;
using System.Collections.Generic;

namespace ExtenCiv.Boards
{
    /// <summary>
    ///     Positions represent an entry in the world matrix of the game.
    /// </summary>
    public struct SquarePosition : IPosition, IEquatable<SquarePosition>
    {
        /// <summary>
        ///     Creates a position of the given row and column.
        /// </summary>
        /// <param name="row">The row in the world matrix (on the vertical axis).</param>
        /// <param name="column">The column in the world matrix (on the horizontal axis).</param>
        public static SquarePosition Of(int row, int column) => new SquarePosition(row, column);

        private SquarePosition(int row, int column)
        {
            Row = row;
            Column = column;
        }

        /// <summary>
        ///     The row in the world matrix (on the vertical axis).
        /// </summary>
        public int Row { get; }

        /// <summary>
        ///     The column in the world matrix (on the horizontal axis).
        /// </summary>
        public int Column { get; }

        public bool Equals(SquarePosition other) => Row == other.Row && Column == other.Column;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is SquarePosition && Equals((SquarePosition) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Row * 397) ^ Column;
            }
        }

        public static bool operator ==(SquarePosition left, SquarePosition right) => left.Equals(right);

        public static bool operator !=(SquarePosition left, SquarePosition right) => !left.Equals(right);

        /// <summary>
        ///     Formats the position to the string "(<c>Row</c>, <c>Column</c>)".
        /// </summary>
        public override string ToString() => $"({Row}, {Column})";

        /// <summary>
        ///     Returns the set of neighbour positions.
        /// </summary>
        public IEnumerable<IPosition> Neighbours
        {
            get { throw new NotImplementedException(); }
        }
    }
}
