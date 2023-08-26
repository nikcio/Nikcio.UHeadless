﻿using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Media.TypeModules;

namespace Nikcio.UHeadless.Media.Extensions;

/// <summary>
/// Media extensions
/// </summary>
public static class MediaExtensions
{
    /// <summary>
    /// This is for internal use only
    /// </summary>
    internal static bool UsingMediaQueries { get; set; } = false;

    /// <summary>
    /// Adds the necessary extensions to properly use media queries.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IRequestExecutorBuilder UseMediaQueries(this IRequestExecutorBuilder builder)
    {
        UsingMediaQueries = true;

        builder.AddTypeModule<MediaTypeModule>();

        return builder;
    }
}
