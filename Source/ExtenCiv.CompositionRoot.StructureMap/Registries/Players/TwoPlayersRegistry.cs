using ExtenCiv.Players;
using ExtenCiv.Players.Abstractions;
using ExtenCiv.Players.Events;
using StructureMap;

namespace ExtenCiv.Composition.StructureMap.Registries.Players
{
    public sealed class TwoPlayersRegistry : Registry
    {
        public TwoPlayersRegistry()
        {
            var players = new[] { new Player("Red"), new Player("Blue") };

            ForSingletonOf<ITurnTaking>().Use<RoundRobinTurns>().Ctor<Player[]>().Is(() => players);
            Forward<ITurnTaking, INotifyBeginningNextRound>();
        }
    }
}
