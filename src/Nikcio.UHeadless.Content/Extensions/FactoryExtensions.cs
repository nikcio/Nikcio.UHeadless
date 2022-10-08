using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Content.Factories;

namespace Nikcio.UHeadless.Content.Extensions;

/// <inheritdoc/>
public static class FactoryExtensions
{
    /// <summary>
    /// Adds factories
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddFactories(this IServiceCollection services)
    {
        services
            .AddScoped(typeof(IContentFactory<,>), typeof(ContentFactory<,>))
            .AddScoped(typeof(IContentRedirectFactory<>), typeof(ContentRedirectFactory<>));

        return services;
    }
}
