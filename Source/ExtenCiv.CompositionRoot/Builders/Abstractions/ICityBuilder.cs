using ExtenCiv.Cities.Abstractions;

namespace ExtenCiv.CompositionRoot.Builders.Abstractions
{
    public interface ICityBuilder
    {
        ICityBuilder WithNoCityGrowth<TCity>() where TCity : ICity<TCity>;

        ICityBuilder WithFixedGeneratedProduction<TCity>() where TCity : ICity<TCity>;

        ICityBuilder WithProductionAccumulation<TCity>() where TCity : ICity<TCity>;

        ICityBuilder WithFriendlyCityManagementOnly<TCity>() where TCity : ICity<TCity>;
    }
}
