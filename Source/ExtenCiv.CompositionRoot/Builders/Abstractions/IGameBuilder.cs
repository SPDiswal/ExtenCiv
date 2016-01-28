using ExtenCiv.Games.Abstractions;

namespace ExtenCiv.CompositionRoot.Builders.Abstractions
{
    public interface IGameBuilder
    {
        IGame BuildGame();
    }
}
