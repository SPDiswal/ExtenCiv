using System.Collections.Generic;
using ExtenCiv.Cities.Abstractions;

namespace ExtenCiv.Cities.Utilities
{
    public sealed class CityEqualityComparer : IEqualityComparer<ICity>
    {
        public bool Equals(ICity first, ICity second) => ReferenceEquals(first, second)
                                                         || !ReferenceEquals(first, null)
                                                         && !ReferenceEquals(second, null)
                                                         && first.Id == second.Id;

        public int GetHashCode(ICity city) => city.Id.GetHashCode();
    }
}
