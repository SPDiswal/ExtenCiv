using Ninject;

namespace ExtenCiv.Resolvers.Ninject
{
    /// <summary>
    ///     Registers and resolves dependencies using Ninject.
    /// </summary>
    public sealed class NinjectResolver : IResolver
    {
        private readonly IKernel kernel = new StandardKernel();

        /// <summary>
        ///     Registers a dependency from a type.
        /// </summary>
        /// <typeparam name="TDependency">The type of the dependency to register.</typeparam>
        public void Inject<TDependency>() where TDependency : class => kernel.Bind<TDependency>().ToSelf();

        /// <summary>
        ///     Registers an instance of a dependency.
        /// </summary>
        /// <typeparam name="TDependency">The type of the dependency to register.</typeparam>
        /// <param name="dependency">The dependency instance to register.</param>
        public void Inject<TDependency>(TDependency dependency) where TDependency : class
        {
            kernel.Bind<TDependency>().ToMethod(_ => dependency);
        }

        /// <summary>
        ///     Resolves all dependencies of a service and instantiates it.
        /// </summary>
        /// <typeparam name="TService">The type of the service to resolve.</typeparam>
        public TService Resolve<TService>() where TService : class => kernel.Get<TService>();

        public override string ToString() => "Ninject";
    }
}
