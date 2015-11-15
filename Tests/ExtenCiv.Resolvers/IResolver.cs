namespace ExtenCiv.Resolvers
{
    /// <summary>
    ///     Registers and resolves dependencies.
    /// </summary>
    public interface IResolver
    {
        /// <summary>
        ///     Registers a dependency from a type.
        /// </summary>
        /// <typeparam name="TDependency">The type of the dependency to register.</typeparam>
        void Inject<TDependency>() where TDependency : class;

        /// <summary>
        ///     Registers an instance of a dependency.
        /// </summary>
        /// <typeparam name="TDependency">The type of the dependency to register.</typeparam>
        /// <param name="dependency">The dependency instance to register.</param>
        void Inject<TDependency>(TDependency dependency) where TDependency : class;

        /// <summary>
        ///     Resolves all dependencies of a service and instantiates it.
        /// </summary>
        /// <typeparam name="TService">The type of the service to resolve.</typeparam>
        TService Resolve<TService>() where TService : class;
    }
}
