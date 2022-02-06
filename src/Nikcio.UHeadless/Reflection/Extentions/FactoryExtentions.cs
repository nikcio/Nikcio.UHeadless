using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Reflection.Factories;

namespace Nikcio.UHeadless.Reflection.Extentions
{
    public static class FactoryExtentions
    {
        public static IServiceCollection AddReflectionFactories(this IServiceCollection services)
        {
            services.
                AddScoped<IDependencyReflectorFactory, DependencyReflectorFactory>();

            return services;
        }
    }
}
