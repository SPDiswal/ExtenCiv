namespace ExtenCiv.WorldMaps.Tiles.Abstractions
{
    /// <summary>
    ///     Tiles represent positions in the world map on which cities, terrains and units can be located.
    /// </summary>
    public interface ITile
    {
        /// <summary>
        ///     Computes the distance from this tile to another tile.
        /// </summary>
        /// <param name="destination">The destination tile to which the distance is computed.</param>
        int DistanceTo(ITile destination);
    }
}
