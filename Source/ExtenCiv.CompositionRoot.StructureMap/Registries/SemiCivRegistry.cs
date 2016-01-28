using ExtenCiv.Composition.StructureMap.Registries.Units;
using ExtenCiv.Winners;
using ExtenCiv.Winners.Abstractions;
using ExtenCiv.WorldAges;
using ExtenCiv.WorldAges.Abstractions;
using StructureMap;

namespace ExtenCiv.Composition.StructureMap.Registries
{
    public sealed class SemiCivRegistry : Registry
    {
        public SemiCivRegistry()
        {
            IncludeRegistry<CommonRegistry>();
            IncludeRegistry<FourProducibleUnitsRegistry>();

            ForSingletonOf<IWorldAge>().Use<DeceleratingWorldAge>();
            ForSingletonOf<IWinnerStrategy>().Use<CityConquerorWins>();
        }
    }
}
