using System;
using Autofac;
using ExtenCiv.Benchmarks.Common;
using ExtenCiv.Game;
using ExtenCiv.GameBoards;
using ExtenCiv.Players;
using ExtenCiv.Winners;
using ExtenCiv.WorldAges;

namespace ExtenCiv.Autofac
{
    public sealed class AutofacBenchmarks : IBenchmark
    {
        /// <summary>
        ///     Runs the benchmark program with the AlphaCiv configuration.
        /// </summary>
        public void AlphaCiv()
        {
            var container = Register();
            var game = Resolve(container);
        }

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

        // TODO: Refactor into Autofac modules (assembling).
        private IContainer Register()
        {
            var builder = new ContainerBuilder();

            builder.Register(_ => new[] { new Player("Red"), new Player("Blue") }).As<Player[]>();

            builder.RegisterType<RoundRobinTurnTaking>().As<ITurnTakingStrategy>().SingleInstance();
            builder.RegisterType<SimpleFixedGameBoard>().As<IGameBoardStrategy>().SingleInstance();
            builder.RegisterType<LinearWorldAge>().As<IWorldAgeStrategy>().SingleInstance();
            builder.RegisterType<RedWinsIn3000Bce>().As<IWinnerStrategy>().SingleInstance();

            builder.RegisterType<ExtenCivGame>().As<IGame>().SingleInstance();

            return builder.Build();
        }

        private IGame Resolve(IContainer container) => container.Resolve<IGame>();

        public override string ToString() => "Autofac";
    }
}
