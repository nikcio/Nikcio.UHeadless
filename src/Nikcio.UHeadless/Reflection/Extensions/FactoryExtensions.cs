using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Reflection.Factories;

namespace Nikcio.UHeadless.Reflection.Extensions
{
    /// <summary>
    /// Extensions for the factories
    /// </summary>
    public static class FactoryExtensions
    {
        /// <summary>
        /// Adds the reflection factories
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddReflectionFactories(this IServiceCollection services)
        {
            services.
                AddScoped<IDependencyReflectorFactory, DependencyReflectorFactory>();

            return services;
        }
    }
}
