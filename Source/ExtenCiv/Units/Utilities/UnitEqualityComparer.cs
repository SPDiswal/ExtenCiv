using System.Collections.Generic;
using ExtenCiv.Units.Abstractions;

namespace ExtenCiv.Units.Utilities
{
    public sealed class UnitEqualityComparer : IEqualityComparer<IUnit>
    {
        public bool Equals(IUnit first, IUnit second) => ReferenceEquals(first, second)
                                                         || !ReferenceEquals(first, null)
                                                         && !ReferenceEquals(second, null)
                                                         && first.Id == second.Id;

        public int GetHashCode(IUnit unit) => unit.Id.GetHashCode();
    }
}
