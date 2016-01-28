using System;
using System.Linq;
using StructureMap;
using StructureMap.Graph;
using StructureMap.Graph.Scanning;

namespace ExtenCiv.Composition.StructureMap.Conventions
{
    public sealed class AlwaysUniqueConvention : IRegistrationConvention
    {
        private readonly Func<Type, bool> predicate;
        private readonly Func<Type, Type> serviceSelector;

        public AlwaysUniqueConvention(Func<Type, bool> predicate, Func<Type, Type> serviceSelector)
        {
            this.predicate = predicate;
            this.serviceSelector = serviceSelector;
        }

        public void ScanTypes(TypeSet types, Registry registry)
        {
            types.AllTypes().Where(predicate).ToList()
                 .ForEach(t => registry.For(serviceSelector.Invoke(t)).Use(t).AlwaysUnique());
        }
    }
}
