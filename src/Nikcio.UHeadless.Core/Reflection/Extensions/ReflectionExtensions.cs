using Microsoft.Extensions.DependencyInjection;

namespace Nikcio.UHeadless.Core.Reflection.Extensions;

/// <summary>
/// Extensions for the Reflections
/// </summary>
public static class ReflectionExtensions
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
