using Autofac;
using ExtenCiv.Composition.Autofac.Modules.Units;
using ExtenCiv.Winners;
using ExtenCiv.Winners.Abstractions;
using ExtenCiv.WorldAges;
using ExtenCiv.WorldAges.Abstractions;

namespace ExtenCiv.Composition.Autofac.Modules
{
    public sealed class AlphaCivModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CommonModule>();
            builder.RegisterModule<ThreeProducibleUnitsModule>();

            builder.RegisterType<LinearWorldAge>().As<IWorldAge>().SingleInstance();
            builder.RegisterType<RedWinsIn3000Bce>().As<IWinnerStrategy>().SingleInstance();
        }
    }
}
