using System;
using ExtenCiv.CompositionRoot.Builders.Abstractions;

namespace ExtenCiv.CompositionRoot.Directors.Abstractions
{
    public interface IUnitDirector
    {
        void SetUpUnits(Func<IUnitBuilder> builder);
    }
}
