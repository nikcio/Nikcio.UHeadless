using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Core.Reflection.Factories;

namespace Nikcio.UHeadless.Core.Reflection.Extensions;

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
