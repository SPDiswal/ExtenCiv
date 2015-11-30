using System;

namespace ExtenCiv.GameBoards
{
    /// <summary>
    ///     Positions represent an entry in the world matrix of the game.
    /// </summary>
    public class Position : IEquatable<Position>
    {
        /// <summary>
        ///     Creates a position of the given row and column.
        /// </summary>
        /// <param name="row">The row in the world matrix (on the vertical axis).</param>
        /// <param name="column">The column in the world matrix (on the horizontal axis).</param>
        public Position(int row, int column)
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

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        ///     true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Position other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Row == other.Row && Column == other.Column;
        }

        /// <summary>
        ///     Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <returns>
        ///     true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Position) obj);
        }

        /// <summary>
        ///     Serves as the default hash function.
        /// </summary>
        /// <returns>
        ///     A hash code for the current object.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (Row * 397) ^ Column;
            }
        }

        public static bool operator ==(Position left, Position right) => Equals(left, right);

        public static bool operator !=(Position left, Position right) => !Equals(left, right);

        /// <summary>
        ///     Formats the position to the string "(<c>Row</c>, <c>Column</c>)".
        /// </summary>
        public override string ToString() => $"({Row}, {Column})";
    }
}
