using Grace.DependencyInjection;

namespace ExtenCiv.Resolvers.Grace
{
    /// <summary>
    ///     Registers and resolves dependencies using Grace.
    /// </summary>
    public sealed class GraceResolver : IResolver
    {
        private readonly IDependencyInjectionContainer container = new DependencyInjectionContainer();

        /// <summary>
        ///     Registers a dependency from a type.
        /// </summary>
        /// <typeparam name="TDependency">The type of the dependency to register.</typeparam>
        public void Inject<TDependency>() where TDependency : class
        {
            container.Configure(c => c.Export<TDependency>().As<TDependency>());
        }

        /// <summary>
        ///     Registers an instance of a dependency.
        /// </summary>
        /// <typeparam name="TDependency">The type of the dependency to register.</typeparam>
        /// <param name="dependency">The dependency instance to register.</param>
        public void Inject<TDependency>(TDependency dependency) where TDependency : class
        {
            container.Configure(c => c.ExportInstance(dependency).As<TDependency>());
        }

        /// <summary>
        ///     Resolves all dependencies of a service and instantiates it.
        /// </summary>
        /// <typeparam name="TService">The type of the service to resolve.</typeparam>
        public TService Resolve<TService>() where TService : class => container.Locate<TService>();

        public override string ToString() => "Grace";
    }
}
