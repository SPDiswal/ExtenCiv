using System.Linq;
using ExtenCiv.Cities;
using ExtenCiv.GameBoards;
using ExtenCiv.Units;

namespace ExtenCiv.UnitActions
{
    /// <summary>
    ///     A city-building unit can perform a special action that replaces the unit with a new city.
    ///     <para></para>
    ///     <para>Dependencies:</para>
    ///     Decorated unit,
    ///     Game board strategy.
    /// </summary>
    public sealed class CityBuildingAction : UnitDecorator
    {
        private readonly IGameBoardStrategy gameBoardStrategy;

        public CityBuildingAction(IUnit unit, IGameBoardStrategy gameBoardStrategy) : base(unit)
        {
            this.gameBoardStrategy = gameBoardStrategy;
        }

        /// <summary>
        ///     Performs the special action of this unit.
        /// </summary>
        public override void PerformAction()
        {
            base.PerformAction();

            var positionOfUnit = gameBoardStrategy.Units.Single(positionUnitPair => positionUnitPair.Value == this).Key;
            gameBoardStrategy.Cities[positionOfUnit] = new City(Owner, 1);
        }
    }
}
