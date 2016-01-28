using System.Collections.Generic;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Cities.Types.Factories.Abstractions;
using ExtenCiv.Cities.Utilities;
using ExtenCiv.Composition.StructureMap.Conventions;
using ExtenCiv.CompositionRoot.Utilities;
using ExtenCiv.WorldMaps;
using ExtenCiv.WorldMaps.Abstractions;
using StructureMap;

namespace ExtenCiv.Composition.StructureMap.Registries.WorldMaps
{
    public sealed class CitiesRegistry : Registry
    {
        public CitiesRegistry()
        {
            Scan(s =>
            {
                s.AssemblyContainingType(typeof (ICity<>));
                s.With(new AlwaysUniqueConvention(t => t.IsCity(), t => t.ToGenericCity()));
            });

            Scan(s =>
            {
                s.AssemblyContainingType(typeof (ICityFactory<>));
                s.With(new SingletonConvention(t => t.IsCityFactory(), t => t.ToGenericCityFactory()));
            });

            ForSingletonOf<ISet<ICity>>().Use(_ => new HashSet<ICity>(new CityEqualityComparer()));
            ForSingletonOf<ICityLayer>().Use<SimpleFixedCityLayer>();
        }
    }
}
