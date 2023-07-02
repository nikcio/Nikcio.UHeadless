using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Content.TypeModules;

namespace Nikcio.UHeadless.Content.Extensions;

/// <summary>
/// Content extensions
/// </summary>
public static class ContentExtensions
{
    /// <summary>
    /// Adds all the content services
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddContentServices(this IServiceCollection services)
    {
        services
            .AddContentRepositories()
            .AddFactories()
            .AddRouters();

        return services;
    }

    /// <summary>
    /// Adds the necessary extensions to properly use content queries.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IRequestExecutorBuilder UseContentQueries(this IRequestExecutorBuilder builder)
    {
        builder.AddTypeModule<ContentTypeModule>();

        return builder;
    }
}
