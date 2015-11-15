using System;
using Autofac;

namespace ExtenCiv.Resolvers.Autofac
{
    /// <summary>
    ///     Registers and resolves dependencies using Autofac.
    /// </summary>
    public sealed class AutofacResolver : IResolver
    {
        private readonly ContainerBuilder builder;
        private readonly Lazy<IContainer> container;

        public AutofacResolver()
        {
            builder = new ContainerBuilder();
            container = new Lazy<IContainer>(() => builder.Build());
        }

        /// <summary>
        ///     Registers a dependency from a type.
        /// </summary>
        /// <typeparam name="TDependency">The type of the dependency to register.</typeparam>
        public void Inject<TDependency>() where TDependency : class => builder.RegisterType<TDependency>().AsSelf();

        /// <summary>
        ///     Registers an instance of a dependency.
        /// </summary>
        /// <typeparam name="TDependency">The type of the dependency to register.</typeparam>
        /// <param name="dependency">The dependency instance to register.</param>
        public void Inject<TDependency>(TDependency dependency) where TDependency : class
        {
            builder.Register(_ => dependency).As<TDependency>();
        }

        /// <summary>
        ///     Resolves all dependencies of a service and instantiates it.
        /// </summary>
        /// <typeparam name="TService">The type of the service to resolve.</typeparam>
        public TService Resolve<TService>() where TService : class
        {
            builder.RegisterType<TService>().As<TService>();

            using (var scope = container.Value.BeginLifetimeScope())
            {
                return scope.Resolve<TService>();
            }
        }

        public override string ToString() => "Autofac";
    }
}
