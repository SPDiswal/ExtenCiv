using System.Collections.Generic;
using ExtenCiv.Players;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Types;
using ExtenCiv.Units.Types.Factories.Abstractions;
using ExtenCiv.WorldMaps.Abstractions;
using ExtenCiv.WorldMaps.Tiles;
using ExtenCiv.WorldMaps.Tiles.Abstractions;

namespace ExtenCiv.WorldMaps
{
    /// <summary>
    ///     Initially, a player named 'Red' has an archer and a settler while a player named 'Blue' has a legion.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Set of units,
    ///     Archer factory,
    ///     Legion factory,
    ///     Settler factory.
    /// </summary>
    public sealed class SimpleFixedUnitLayer : IUnitLayer
    {
        private static readonly Player Red = new Player("Red");
        private static readonly Player Blue = new Player("Blue");

        private static readonly ITile RedArcherTile = new SquareTile(2, 0);
        private static readonly ITile BlueLegionTile = new SquareTile(3, 2);
        private static readonly ITile RedSettlerTile = new SquareTile(4, 3);

        public SimpleFixedUnitLayer(ISet<IUnit> units,
                                    IUnitFactory<Archer> archerFactory,
                                    IUnitFactory<Legion> legionFactory,
                                    IUnitFactory<Settler> settlerFactory)
        {
            Units = units;

            Units.Add(archerFactory.Create(RedArcherTile, Red));
            Units.Add(legionFactory.Create(BlueLegionTile, Blue));
            Units.Add(settlerFactory.Create(RedSettlerTile, Red));
        }

        /// <summary>
        ///     Returns the units on the world map.
        /// </summary>
        public ISet<IUnit> Units { get; }
    }
}
