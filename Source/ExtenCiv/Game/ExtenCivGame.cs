using System;
using ExtenCiv.GameBoards;
using ExtenCiv.Players;
using ExtenCiv.Winners;
using ExtenCiv.WorldAges;

namespace ExtenCiv.Game
{
    /// <summary>
    ///     A game is the facade of the ExtenCiv system.
    ///     It exposes a view model of the current state of the game as well as actions for changing the game state properly.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Game board strategy,
    ///     Turn taking strategy,
    ///     World age strategy,
    ///     Winner strategy.
    /// </summary>
    public sealed class ExtenCivGame : IGame
    {
        private readonly IGameBoardStrategy gameBoardStrategy;
        private readonly ITurnTakingStrategy turnTakingStrategy;
        private readonly IWorldAgeStrategy worldAgeStrategy;
        private readonly IWinnerStrategy winnerStrategy;

        // TODO: Unify world-related strategies under a world facade to avoid constructor over-injection.
        public ExtenCivGame(IGameBoardStrategy gameBoardStrategy,
                            ITurnTakingStrategy turnTakingStrategy,
                            IWorldAgeStrategy worldAgeStrategy,
                            IWinnerStrategy winnerStrategy)
        {
            this.gameBoardStrategy = gameBoardStrategy;
            this.turnTakingStrategy = turnTakingStrategy;
            this.worldAgeStrategy = worldAgeStrategy;
            this.winnerStrategy = winnerStrategy;
        }

        /// <summary>
        ///     Returns a view model of the terrain at the given position.
        /// </summary>
        /// <param name="position">The position in the world matrix.</param>
        public TerrainViewModel TerrainAt(Position position) { throw new NotImplementedException(); }

        /// <summary>
        ///     Returns a view model of the city at the given position, or <c>null</c> if there is no city.
        /// </summary>
        /// <param name="position">The position in the world matrix.</param>
        public CityViewModel CityAt(Position position) { throw new NotImplementedException(); }

        /// <summary>
        ///     Returns a view model of the unit at the given position, or <c>null</c> if there is no unit.
        /// </summary>
        /// <param name="position">The position in the world matrix.</param>
        public UnitViewModel UnitAt(Position position) { throw new NotImplementedException(); }

        /// <summary>
        ///     Ends the turn of the current player, moving on to the next player.
        ///     Once all players have ended their turns, a new round begins.
        /// </summary>
        public void EndTurn() { throw new NotImplementedException(); }

        /// <summary>
        ///     Moves a unit to a new position, potentially going into combat with an opponent unit.
        /// </summary>
        /// <param name="from">The current position of the unit.</param>
        /// <param name="to">The destination of the unit.</param>
        /// <returns>
        ///     <c>true</c> if the move is valid and has been done,
        ///     or <c>false</c> if the move is invalid and has been rejected.
        /// </returns>
        public bool MoveUnit(Position @from, Position to) { throw new NotImplementedException(); }

        /// <summary>
        ///     Performs the special action of the unit at the given position.
        /// </summary>
        /// <param name="position">The position of the unit.</param>
        public void PerformUnitActionAt(Position position) { throw new NotImplementedException(); }
    }
}
