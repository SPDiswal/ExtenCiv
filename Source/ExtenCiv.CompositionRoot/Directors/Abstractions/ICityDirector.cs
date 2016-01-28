using System;
using ExtenCiv.CompositionRoot.Builders.Abstractions;

namespace ExtenCiv.CompositionRoot.Directors.Abstractions
{
    public interface ICityDirector
    {
        void SetUpCities(Func<ICityBuilder> builder);
    }
}
