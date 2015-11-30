using System;
using ExtenCiv.Benchmarks.Common;
using ExtenCiv.Game;
using ExtenCiv.GameBoards;
using ExtenCiv.Players;
using ExtenCiv.Winners;
using ExtenCiv.WorldAges;

namespace ExtenCiv.Benchmarks.Manual
{
    public sealed class ManualBenchmarks : IBenchmark
    {
        /// <summary>
        ///     Runs the benchmark program with the AlphaCiv configuration.
        /// </summary>
        public void AlphaCiv() { throw new NotImplementedException(); }

        /// <summary>
        ///     Runs the benchmark program with the BetaCiv configuration.
        /// </summary>
        public void BetaCiv() { throw new NotImplementedException(); }

        /// <summary>
        ///     Runs the benchmark program with the GammaCiv configuration.
        /// </summary>
        public void GammaCiv() { throw new NotImplementedException(); }

        /// <summary>
        ///     Runs the benchmark program with the DeltaCiv configuration.
        /// </summary>
        public void DeltaCiv() { throw new NotImplementedException(); }

        /// <summary>
        ///     Runs the benchmark program with the EpsilonCiv configuration.
        /// </summary>
        public void EpsilonCiv() { throw new NotImplementedException(); }

        /// <summary>
        ///     Runs the benchmark program with the ZetaCiv configuration.
        /// </summary>
        public void ZetaCiv() { throw new NotImplementedException(); }

        /// <summary>
        ///     Runs the benchmark program with the EtaCiv configuration.
        /// </summary>
        public void EtaCiv() { throw new NotImplementedException(); }

        /// <summary>
        ///     Runs the benchmark program with the ThetaCiv configuration.
        /// </summary>
        public void ThetaCiv() { throw new NotImplementedException(); }

        /// <summary>
        ///     Runs the benchmark program with the SemiCiv configuration.
        /// </summary>
        public void SemiCiv() { throw new NotImplementedException(); }

        private IGame Resolve()
        {
            Player[] players = { new Player("Red"), new Player("Blue") };

            ITurnTakingStrategy turnTakingStrategy = new RoundRobinTurnTaking(players);
            IGameBoardStrategy gameBoardStrategy = new SimpleFixedGameBoard();
            IWorldAgeStrategy worldAgeStrategy = new LinearWorldAge();
            IWinnerStrategy winnerStrategy = new RedWinsIn3000Bce(worldAgeStrategy);

            IGame game = new ExtenCivGame(gameBoardStrategy, turnTakingStrategy, worldAgeStrategy, winnerStrategy);

            return game;
        }

        public override string ToString() => "Poor-man's dependency injection";
    }
}
