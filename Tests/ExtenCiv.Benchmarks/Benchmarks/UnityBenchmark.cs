﻿using ExtenCiv.Benchmarks.Benchmarks.Abstractions;
using ExtenCiv.Composition.Unity.Builders;
using ExtenCiv.Games.Abstractions;

namespace ExtenCiv.Benchmarks.Benchmarks
{
    /// <summary>
    ///     Benchmark for Unity.
    /// </summary>
    public sealed class UnityBenchmark : IBenchmark
    {
        /// <summary>
        ///     Runs the benchmark program with the AlphaCiv configuration.
        /// </summary>
        public IGame AlphaCiv() => new UnityAlphaCiv().BuildGame();

        /// <summary>
        ///     Runs the benchmark program with the SemiCiv configuration.
        /// </summary>
        public IGame SemiCiv() => new UnitySemiCiv().BuildGame();

        public override string ToString() => "Unity";
    }
}
