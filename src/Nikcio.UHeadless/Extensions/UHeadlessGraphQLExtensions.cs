﻿using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Base.Properties.Maps;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Content.Models;
using Nikcio.UHeadless.Content.TypeModules;
using Nikcio.UHeadless.Core.GraphQL.Queries;
using Nikcio.UHeadless.Extensions.Options;
using Umbraco.Cms.Core.Services;

namespace Nikcio.UHeadless.Extensions;

/// <summary>
/// The UHeadless extensions for GraphQL functionallity
/// </summary>
public static class UHeadlessGraphQLExtensions
{
    /// <summary>
    /// Adds Apollo tracing if the tracingOptions is set
    /// </summary>
    /// <param name="requestExecutorBuilder"></param>
    /// <param name="tracingOptions">Options for the Apollo tracing</param>
    /// <returns></returns>
    public static IRequestExecutorBuilder AddTracing(this IRequestExecutorBuilder requestExecutorBuilder, TracingOptions tracingOptions)
    {
        if (tracingOptions.TracingPreference != null)
        {
            requestExecutorBuilder
                .AddApolloTracing(tracingOptions.TracingPreference.GetValueOrDefault(), tracingOptions.TimestampProvider);
        }
        return requestExecutorBuilder;
    }

    /// <summary>
    /// Adds UHeadless types and GraphQL server settings
    /// </summary>
    /// <param name="requestExecutorBuilder"></param>
    /// <param name="uHeadlessGraphQLOptions"></param>
    /// <returns></returns>
    public static IRequestExecutorBuilder AddUHeadlessGraphQL(this IRequestExecutorBuilder requestExecutorBuilder, UHeadlessGraphQLOptions uHeadlessGraphQLOptions)
    {
        requestExecutorBuilder
            .InitializeOnStartup()
            .AddFiltering()
            .AddSorting()
            .AddQueryType<Query>()
            .AddInterfaceType<PropertyValue>()
            .AddTypeModule(serviceProvider => serviceProvider.GetRequiredService<ContentTypeModule>());

        foreach (var type in uHeadlessGraphQLOptions.PropertyValueTypes)
        {
            requestExecutorBuilder.AddType(type);
        }

        uHeadlessGraphQLOptions.GraphQLExtensions?.Invoke(requestExecutorBuilder);

        return requestExecutorBuilder;
    }
}
