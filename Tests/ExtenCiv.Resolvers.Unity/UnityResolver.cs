using Microsoft.Practices.Unity;

namespace ExtenCiv.Resolvers.Unity
{
    /// <summary>
    ///     Registers and resolves dependencies using Unity Container.
    /// </summary>
    public sealed class UnityResolver : IResolver
    {
        private readonly IUnityContainer container = new UnityContainer();

        /// <summary>
        ///     Registers a dependency from a type.
        /// </summary>
        /// <typeparam name="TDependency">The type of the dependency to register.</typeparam>
        public void Inject<TDependency>() where TDependency : class
        {
            container.RegisterType<TDependency, TDependency>();
        }

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
        public TService Resolve<TService>() where TService : class => container.Resolve<TService>();

        public override string ToString() => "Unity";
    }
}
