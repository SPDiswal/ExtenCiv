using LightInject;

namespace ExtenCiv.Resolvers.LightInject
{
    /// <summary>
    ///     Registers and resolves dependencies using LightInject.
    /// </summary>
    public sealed class LightInjectResolver : IResolver
    {
        private readonly IServiceContainer container = new ServiceContainer();

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
            container.RegisterInstance(dependency);
        }

        /// <summary>
        ///     Resolves all dependencies of a service and instantiates it.
        /// </summary>
        /// <typeparam name="TService">The type of the service to resolve.</typeparam>
        public TService Resolve<TService>() where TService : class
        {
            container.Register<TService>();
            return container.GetInstance<TService>();
        }

        public override string ToString() => "LightInject";
    }
}
