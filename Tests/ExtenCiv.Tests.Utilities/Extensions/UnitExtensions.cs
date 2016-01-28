using ExtenCiv.Units.Abstractions;
using ExtenCiv.WorldMaps.Tiles;

namespace ExtenCiv.Tests.Utilities.Extensions
{
    public static class UnitExtensions
    {
        public static IUnit<TUnit> At<TUnit>(this IUnit<TUnit> unit, int row, int column) where TUnit : IUnit<TUnit>
        {
            unit.Location = new SquareTile(row, column);
            return unit;
        }

        public static IUnit<TUnit> ThatCanMove<TUnit>(this IUnit<TUnit> unit, int remainingMoves)
            where TUnit : IUnit<TUnit>
        {
            unit.RemainingMoves = remainingMoves;
            return unit;
        }

        public static IUnit<TUnit> Of<TUnit>(this IUnit<TUnit> unit, int totalMoves) where TUnit : IUnit<TUnit>
        {
            unit.TotalMoves = totalMoves;
            return unit;
        }

        public static IUnit<TUnit> WithDefenceOf<TUnit>(this IUnit<TUnit> unit, int defence) where TUnit : IUnit<TUnit>
        {
            unit.Defence = defence;
            return unit;
        }
    }
}
