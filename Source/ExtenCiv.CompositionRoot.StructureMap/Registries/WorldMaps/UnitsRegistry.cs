using System.Collections.Generic;
using ExtenCiv.Cities.Abstractions;
using ExtenCiv.Composition.StructureMap.Conventions;
using ExtenCiv.CompositionRoot.Utilities;
using ExtenCiv.Units.Abstractions;
using ExtenCiv.Units.Types.Factories.Abstractions;
using ExtenCiv.Units.Utilities;
using ExtenCiv.WorldMaps;
using ExtenCiv.WorldMaps.Abstractions;
using StructureMap;

namespace ExtenCiv.Composition.StructureMap.Registries.WorldMaps
{
    public sealed class UnitsRegistry : Registry
    {
        public UnitsRegistry()
        {
            Scan(s =>
            {
                s.AssemblyContainingType(typeof (IUnit<>));
                s.With(new AlwaysUniqueConvention(t => t.IsUnit(), t => t.ToGenericUnit()));
            });

            Scan(s =>
            {
                s.AssemblyContainingType(typeof (IUnitFactory<>));
                s.With(new SingletonConvention(t => t.IsUnitFactory(), t => t.ToGenericUnitFactory()));
            });

            Scan(s =>
            {
                s.AssemblyContainingType(typeof(IProductionProject));
                s.With(new SingletonConvention(t => t.IsProductionProject(), t => t));
            });

            ForSingletonOf<ISet<IUnit>>().Use(_ => new HashSet<IUnit>(new UnitEqualityComparer()));
            ForSingletonOf<IUnitLayer>().Use<SimpleFixedUnitLayer>();
        }
    }
}
