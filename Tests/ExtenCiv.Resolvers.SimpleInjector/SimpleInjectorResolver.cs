using SimpleInjector;

namespace ExtenCiv.Resolvers.SimpleInjector
{
    /// <summary>
    ///     Registers and resolves dependencies using Simple Injector.
    /// </summary>
    public sealed class SimpleInjectorResolver : IResolver
    {
        private readonly Container container = new Container();

        /// <summary>
        ///     Registers a dependency from a type.
        /// </summary>
        /// <typeparam name="TDependency">The type of the dependency to register.</typeparam>
        public void Inject<TDependency>() where TDependency : class => container.Register<TDependency>();

        /// <summary>
        ///     Registers an instance of a dependency.
        /// </summary>
        /// <typeparam name="TDependency">The type of the dependency to register.</typeparam>
        /// <param name="dependency">The dependency instance to register.</param>
        public void Inject<TDependency>(TDependency dependency) where TDependency : class
        {
            container.Register(() => dependency);
        }

        /// <summary>
        ///     Resolves all dependencies of a service and instantiates it.
        /// </summary>
        /// <typeparam name="TService">The type of the service to resolve.</typeparam>
        public TService Resolve<TService>() where TService : class => container.GetInstance<TService>();

        public override string ToString() => "Simple Injector";
    }
}
