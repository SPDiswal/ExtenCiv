using ExtenCiv.Composition.Ninject.Modules.Units;
using ExtenCiv.Winners;
using ExtenCiv.Winners.Abstractions;
using ExtenCiv.WorldAges;
using ExtenCiv.WorldAges.Abstractions;
using Ninject;
using Ninject.Modules;

namespace ExtenCiv.Composition.Ninject.Modules
{
    public sealed class SemiCivModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Load<CommonModule>();
            Kernel.Load<FourProducibleUnitsModule>();

            Bind<IWorldAge>().To<DeceleratingWorldAge>().InSingletonScope();
            Bind<IWinnerStrategy>().To<CityConquerorWins>().InSingletonScope();
        }
    }
}
