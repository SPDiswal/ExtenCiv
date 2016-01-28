using System;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.WorldMaps.Tiles
{
    /// <summary>
    ///     Square tiles define the world map as a two-dimensional matrix of positions.
    /// </summary>
    public class SquareTile : ITile
    {
        /// <summary>
        ///     Creates a tile at the given row and column.
        /// </summary>
        /// <param name="row">The row in the world matrix (on the vertical axis).</param>
        /// <param name="column">The column in the world matrix (on the horizontal axis).</param>
        public SquareTile(int row, int column)
        {
            Row = row;
            Column = column;
        }

        /// <summary>
        ///     The row in the matrix (on the vertical axis).
        /// </summary>
        public int Row { get; }

        /// <summary>
        ///     The column in the matrix (on the horizontal axis).
        /// </summary>
        public int Column { get; }

        /// <summary>
        ///     Computes the distance from this tile to another tile.
        /// </summary>
        /// <param name="destination">The destination tile to which the distance is computed.</param>
        public int DistanceTo(ITile destination)
        {
            var squareTileDestination = destination as SquareTile;
            if (squareTileDestination == null) throw new NotSupportedException();

            var destinationRow = squareTileDestination.Row;
            var destinationColumn = squareTileDestination.Column;

            return Math.Max(Math.Abs(Row - destinationRow), Math.Abs(Column - destinationColumn));
        }

        public bool Equals(SquareTile other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Row == other.Row && Column == other.Column;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((SquareTile) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Row * 397) ^ Column;
            }
        }

        public static bool operator ==(SquareTile left, SquareTile right) => Equals(left, right);

        public static bool operator !=(SquareTile left, SquareTile right) => !Equals(left, right);

        public override string ToString() => $"({Row}, {Column})";
    }
}
