using System.Collections.Generic;
using System.Linq;
using ExtenCiv.Resolvers;
using ExtenCiv.Resolvers.Autofac;
using ExtenCiv.Resolvers.DryIoc;
using ExtenCiv.Resolvers.Grace;
using ExtenCiv.Resolvers.HaveBox;
using ExtenCiv.Resolvers.LightInject;
using ExtenCiv.Resolvers.Ninject;
using ExtenCiv.Resolvers.SimpleInjector;
using ExtenCiv.Resolvers.StructureMap;
using ExtenCiv.Resolvers.TinyIoC;
using ExtenCiv.Resolvers.Unity;
using ExtenCiv.Resolvers.Windsor;

namespace ExtenCiv.Common.Utilities.Theories
{
    /// <summary>
    ///     This class provides a short-cut to executing sets of unit tests across multiple dependency injection frameworks
    ///     while retaining a single code base for the unit tests.
    /// </summary>
    public sealed class ExtenCivTheory : List<object[]>
    {
        private static IEnumerable<IResolver> Resolvers => new List<IResolver>
        {
            new AutofacResolver(),
            new DryIocResolver(),
            new GraceResolver(),
            new HaveBoxResolver(),
            new LightInjectResolver(),
            new NinjectResolver(),
            new SimpleInjectorResolver(),
            new StructureMapResolver(),
            new TinyIoCResolver(),
            new UnityResolver(),
            new WindsorResolver()
        };

        public new void Add(params object[] input)
        {
            // Prepends the individual framework resolvers to the existing theory data.
            foreach (var resolver in Resolvers)
                base.Add(new object[] { resolver }.Concat(input).ToArray());
        }
    }
}
