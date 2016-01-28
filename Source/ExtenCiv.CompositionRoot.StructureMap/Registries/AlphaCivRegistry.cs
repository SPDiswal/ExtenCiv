using ExtenCiv.Composition.StructureMap.Registries.Units;
using ExtenCiv.Winners;
using ExtenCiv.Winners.Abstractions;
using ExtenCiv.WorldAges;
using ExtenCiv.WorldAges.Abstractions;
using StructureMap;

namespace ExtenCiv.Composition.StructureMap.Registries
{
    public sealed class AlphaCivRegistry : Registry
    {
        public AlphaCivRegistry()
        {
            IncludeRegistry<CommonRegistry>();
            IncludeRegistry<ThreeProducibleUnitsRegistry>();

            ForSingletonOf<IWorldAge>().Use<LinearWorldAge>();
            ForSingletonOf<IWinnerStrategy>().Use<RedWinsIn3000Bce>();
        }
    }
}
