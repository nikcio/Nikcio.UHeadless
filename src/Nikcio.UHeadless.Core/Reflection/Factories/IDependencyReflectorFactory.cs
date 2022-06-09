namespace Nikcio.UHeadless.Core.Reflection.Factories {
    /// <summary>
    /// A factory that can create objects with DI
    /// </summary>
    public interface IDependencyReflectorFactory {
        /// <summary>
        /// Gets the reflected type with DI
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeToReflect">The type to create</param>
        /// <param name="constructorRequiredParamerters">The required parameters on the constructor</param>
        /// <returns></returns>
        T? GetReflectedType<T>(Type typeToReflect, object[] constructorRequiredParamerters) where T : class;
    }
}