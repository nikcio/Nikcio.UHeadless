using Microsoft.Extensions.DependencyInjection;

namespace Nikcio.UHeadless.Reflection.Extentions
{
    /// <summary>
    /// Extentions for the Reflections
    /// </summary>
    public static class ReflectionExtentions
    {
        /// <summary>
        /// Adds all the Reflections services
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddReflectionServices(this IServiceCollection services)
        {
            services
                .AddReflectionFactories();

            return services;
        }
    }
}
