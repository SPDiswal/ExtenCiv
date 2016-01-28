using ExtenCiv.Composition.Ninject.Modules.Units;
using ExtenCiv.Winners;
using ExtenCiv.Winners.Abstractions;
using ExtenCiv.WorldAges;
using ExtenCiv.WorldAges.Abstractions;
using Ninject;
using Ninject.Modules;

namespace ExtenCiv.Composition.Ninject.Modules
{
    public sealed class AlphaCivModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Load<CommonModule>();
            Kernel.Load<ThreeProducibleUnitsModule>();

            Bind<IWorldAge>().To<LinearWorldAge>().InSingletonScope();
            Bind<IWinnerStrategy>().To<RedWinsIn3000Bce>().InSingletonScope();
        }
    }
}
