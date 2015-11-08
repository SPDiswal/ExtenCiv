using System;

namespace ExtenCiv.Players
{
    /// <summary>
    ///     Players control their own cities and units in the game and are identified by names.
    /// </summary>
    public struct Player : IEquatable<Player>
    {
        /// <summary>
        ///     A player that represents nobody.
        /// </summary>
        public static readonly Player Nobody = default(Player);

        /// <summary>
        ///     Creates a player with the given name.
        /// </summary>
        /// <param name="name">
        ///     The name of the player, or <c>null</c> if the player represents nobody.
        /// </param>
        public static Player For(string name) => new Player(name);
        
        private Player(string name) { Name = name; }

        /// <summary>
        ///     The name of the player, or <c>null</c> if the player represents nobody.
        /// </summary>
        public string Name { get; }

        public bool Equals(Player other) => string.Equals(Name, other.Name);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Player && Equals((Player) obj);
        }

        public override int GetHashCode() => Name?.GetHashCode() ?? 0;

        public static bool operator ==(Player left, Player right) => left.Equals(right);

        public static bool operator !=(Player left, Player right) => !left.Equals(right);

        /// <summary>
        ///     Formats the player to the string "[<c>Name</c>]".
        /// </summary>
        public override string ToString() => Name != null ? $"[{Name}]" : "[Nobody]";
    }
}
