using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace ExtenCiv.Resolvers.Windsor
{
    /// <summary>
    ///     Registers and resolves dependencies using Castle Windsor.
    /// </summary>
    public sealed class WindsorResolver : IResolver
    {
        private readonly IWindsorContainer container = new WindsorContainer();

        /// <summary>
        ///     Registers a dependency from a type.
        /// </summary>
        /// <typeparam name="TDependency">The type of the dependency to register.</typeparam>
        public void Inject<TDependency>() where TDependency : class
        {
            container.Register(Component.For<TDependency>());
        }

        /// <summary>
        ///     Registers an instance of a dependency.
        /// </summary>
        /// <typeparam name="TDependency">The type of the dependency to register.</typeparam>
        /// <param name="dependency">The dependency instance to register.</param>
        public void Inject<TDependency>(TDependency dependency) where TDependency : class
        {
            container.Register(Component.For<TDependency>().Instance(dependency));
        }

        /// <summary>
        ///     Resolves all dependencies of a service and instantiates it.
        /// </summary>
        /// <typeparam name="TService">The type of the service to resolve.</typeparam>
        public TService Resolve<TService>() where TService : class
        {
            container.Register(Component.For<TService>());
            return container.Resolve<TService>();
        }

        public override string ToString() => "Windsor";
    }
}
