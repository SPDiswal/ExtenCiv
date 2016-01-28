using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Types;
using ExtenCiv.Players;
using ExtenCiv.Players.Abstractions;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Types;
using FakeItEasy;

namespace ExtenCiv.Tests.Utilities.Extensions
{
    public static class PlayerExtensions
    {
        public static IUnit<Archer> Archer(this Player owner) => new Archer { Owner = owner };
        public static IUnit<Legion> Legion(this Player owner) => new Legion { Owner = owner };
        public static IUnit<Settler> Settler(this Player owner) => new Settler { Owner = owner };

        public static ICity<City> City(this Player owner) => new City { Owner = owner };

        public static ITurnTaking InTurn(this Player player)
        {
            var stubTurnTaking = A.Fake<ITurnTaking>();

            A.CallTo(() => stubTurnTaking.CurrentPlayer).Returns(player);
            A.CallTo(() => stubTurnTaking.ToString()).Returns($"{player} is in turn");

            return stubTurnTaking;
        }
    }
}
