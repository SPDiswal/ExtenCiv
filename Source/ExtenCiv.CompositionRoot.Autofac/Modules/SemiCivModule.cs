using Autofac;
using ExtenCiv.Composition.Autofac.Modules.Units;
using ExtenCiv.Winners;
using ExtenCiv.Winners.Abstractions;
using ExtenCiv.WorldAges;
using ExtenCiv.WorldAges.Abstractions;

namespace ExtenCiv.Composition.Autofac.Modules
{
    public sealed class SemiCivModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CommonModule>();
            builder.RegisterModule<FourProducibleUnitsModule>();

            builder.RegisterType<DeceleratingWorldAge>().As<IWorldAge>().SingleInstance();
            builder.RegisterType<CityConquerorWins>().As<IWinnerStrategy>().SingleInstance();
        }
    }
}
