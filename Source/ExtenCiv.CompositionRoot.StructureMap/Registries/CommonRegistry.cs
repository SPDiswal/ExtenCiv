using ExtenCiv.Composition.StructureMap.Registries.Players;
using ExtenCiv.Composition.StructureMap.Registries.WorldMaps;
using ExtenCiv.Games;
using ExtenCiv.Games.Abstractions;
using ExtenCiv.Units.Combat;
using ExtenCiv.Units.Combat.Abstractions;
using StructureMap;

namespace ExtenCiv.Composition.StructureMap.Registries
{
    public sealed class CommonRegistry : Registry
    {
        public CommonRegistry()
        {
            IncludeRegistry<TwoPlayersRegistry>();

            IncludeRegistry<CitiesRegistry>();
            IncludeRegistry<TerrainsRegistry>();
            IncludeRegistry<UnitsRegistry>();

            ForSingletonOf<IUnitCombat>().Use<AttackerIsAlwaysVictorious>();
            ForSingletonOf<IGame>().Use<ExtenCivGame>();
        }
    }
}
