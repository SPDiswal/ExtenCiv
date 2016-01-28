using System;
using System.Linq;
using System.Linq.Expressions;
using SimpleInjector;

namespace ExtenCiv.Composition.SimpleInjector.Extensions
{
    public static class ContainerExtensions
    {
        /// <summary>
        ///     Enables automatic resolution of Func-delegates in constructors.
        ///     <para></para>
        ///     Borrowed from:
        ///     http://simpleinjector.readthedocs.org/en/latest/howto.html#register-factory-delegates
        /// </summary>
        public static void AllowResolvingFuncFactories(this ContainerOptions options)
        {
            options.Container.ResolveUnregisteredType += (s, e) =>
            {
                var type = e.UnregisteredServiceType;
                if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof (Func<>)) return;

                var serviceType = type.GetGenericArguments().First();
                var registration = options.Container.GetRegistration(serviceType, true);
                var funcType = typeof (Func<>).MakeGenericType(serviceType);

                var factoryDelegate = Expression.Lambda(funcType, registration.BuildExpression()).Compile();
                e.Register(Expression.Constant(factoryDelegate));
            };
        }
    }
}
