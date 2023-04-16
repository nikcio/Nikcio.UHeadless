using HotChocolate.Configuration;
using HotChocolate.Execution.Configuration;
using HotChocolate.Types.Descriptors;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Core.GraphQL.Queries;
using Nikcio.UHeadless.Extensions.Options;

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
            .AddInterfaceType<PropertyValue>();

        foreach (var type in uHeadlessGraphQLOptions.PropertyValueTypes)
        {
            requestExecutorBuilder.AddType(type);
        }

        if (uHeadlessGraphQLOptions.UseSecurity)
        {
            requestExecutorBuilder.AddAuthorization();
        }

        uHeadlessGraphQLOptions.GraphQLExtensions?.Invoke(requestExecutorBuilder);

        return requestExecutorBuilder;
    }

    /// <summary>
    /// Handles a schema error
    /// </summary>
    /// <param name="throwOnSchemaError">Should the schema builder throw an exception when a schema error occurs. (true = yes, false = no)</param>
    /// <returns></returns>
    private static OnSchemaError HandleSchemaError(bool throwOnSchemaError)
    {
        return new OnSchemaError((dc, ex) => LogSchemaError(throwOnSchemaError, dc, ex));
    }

    /// <summary>
    /// Logs the error and throws if the option is set
    /// </summary>
    /// <param name="throwOnSchemaError"></param>
    /// <param name="dc"></param>
    /// <param name="ex"></param>
    private static void LogSchemaError(bool throwOnSchemaError, IDescriptorContext dc, Exception ex)
    {
        var logger = dc.Services.GetRequiredService<ILogger<Query>>();
        logger.LogError(ex, "Schema failed to generate. GraphQL is unavalible");
        if (throwOnSchemaError)
        {
            throw ex;
        }
    }
}
