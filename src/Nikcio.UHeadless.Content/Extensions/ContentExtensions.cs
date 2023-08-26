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
    /// This is for internal use only.
    /// </summary>
    internal static bool UsingContentQueries { get; set; } = false;

    /// <summary>
    /// Adds the necessary extensions to properly use content queries.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IRequestExecutorBuilder UseContentQueries(this IRequestExecutorBuilder builder)
    {
        UsingContentQueries = true;

        builder.AddTypeModule<ContentTypeModule>();

        return builder;
    }
}
