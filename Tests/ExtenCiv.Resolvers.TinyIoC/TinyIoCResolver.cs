using TinyIoC;

namespace ExtenCiv.Resolvers.TinyIoC
{
    /// <summary>
    ///     Registers and resolves dependencies using Simple Injector.
    /// </summary>
    public sealed class TinyIoCResolver : IResolver
    {
        private readonly TinyIoCContainer container = new TinyIoCContainer();

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
            container.Register((c, p) => dependency);
        }

        /// <summary>
        ///     Resolves all dependencies of a service and instantiates it.
        /// </summary>
        /// <typeparam name="TService">The type of the service to resolve.</typeparam>
        public TService Resolve<TService>() where TService : class => container.Resolve<TService>();

        public override string ToString() => "TinyIoC";
    }
}
