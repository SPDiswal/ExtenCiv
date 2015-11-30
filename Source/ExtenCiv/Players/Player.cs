using System;

namespace ExtenCiv.Players
{
    /// <summary>
    ///     Players control their own cities and units in the game and are identified by names.
    /// </summary>
    public class Player : IEquatable<Player>
    {
        /// <summary>
        ///     A player that represents nobody.
        /// </summary>
        public static readonly Player Nobody = new Player();

        private Player() { Name = null; }

        /// <summary>
        ///     Creates a player with the given name.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        public Player(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            Name = name;
        }

        /// <summary>
        ///     The name of the player, or <c>null</c> if the player represents nobody.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        ///     true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Player other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name);
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
            return obj.GetType() == GetType() && Equals((Player) obj);
        }

        /// <summary>
        ///     Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => Name?.GetHashCode() ?? 0;

        public static bool operator ==(Player left, Player right) => Equals(left, right);

        public static bool operator !=(Player left, Player right) => !Equals(left, right);

        public override string ToString() => Name != null ? $"{Name}" : "Nobody";
    }
}
