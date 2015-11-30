using System.Collections.Generic;
using System.Linq;
using ExtenCiv.Cities;
using ExtenCiv.Players;
using ExtenCiv.Terrains;
using ExtenCiv.Units;
using ExtenCiv.Utilities.Extensions;

namespace ExtenCiv.GameBoards
{
    /// <summary>
    ///     The game board consists of a two cities and three units as well as plains, with a few exceptions.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     None.
    /// </summary>
    public sealed class SimpleFixedGameBoard : IGameBoardStrategy
    {
        private const int WorldSize = 16;

        private static readonly Player Red = new Player("Red");
        private static readonly Player Blue = new Player("Blue");

        public SimpleFixedGameBoard()
        {
            Terrains = new Dictionary<Position, ITerrain>
            {
                [new Position(1, 0)] = new Oceans(),
                [new Position(0, 1)] = new Hills(),
                [new Position(2, 2)] = new Mountains(),
            };

            AddPlainsOnRemainingPositions();
        }

        private void AddPlainsOnRemainingPositions()
        {
            var worldGrid = 0.To(WorldSize - 1).Cartesian(0.To(WorldSize - 1),
                                                          (row, column) => new Position(row, column));

            foreach (var position in worldGrid.Where(position => !Terrains.ContainsKey(position)))
                Terrains[position] = new Plains();
        }

        /// <summary>
        ///     Returns the set of cities on the game board.
        /// </summary>
        public IDictionary<Position, ICity> Cities { get; } = new Dictionary<Position, ICity>
        {
            [new Position(1, 1)] = new City(Red, 1),
            [new Position(4, 1)] = new City(Blue, 1),
        };

        /// <summary>
        ///     Returns the set of terrains on the game board.
        /// </summary>
        public IDictionary<Position, ITerrain> Terrains { get; }

        /// <summary>
        ///     Returns the set of units on the game board.
        /// </summary>
        public IDictionary<Position, IUnit> Units { get; } = new Dictionary<Position, IUnit>
        {
            [new Position(2, 0)] = new Archer(Red),
            [new Position(3, 2)] = new Legion(Blue),
            [new Position(4, 3)] = new Settler(Red),
        };
    }
}
