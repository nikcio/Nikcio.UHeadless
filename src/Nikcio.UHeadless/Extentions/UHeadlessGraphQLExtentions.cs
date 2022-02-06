using HotChocolate.Configuration;
using HotChocolate.Execution.Configuration;
using HotChocolate.Types.Descriptors;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nikcio.UHeadless.Options;
using Nikcio.UHeadless.Queries;
using Nikcio.UHeadless.UmbracoContent.Content.Models;
using Nikcio.UHeadless.UmbracoContent.Content.Queries;
using Nikcio.UHeadless.UmbracoContent.ContentType.Models;
using Nikcio.UHeadless.UmbracoContent.Elements.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.Queries;
using System;

namespace Nikcio.UHeadless.Extentions
{
    public static class UHeadlessGraphQLExtentions
    {
        public static IRequestExecutorBuilder AddTracing(this IRequestExecutorBuilder requestExecutorBuilder, TracingOptions tracingOptions)
        {
            if (tracingOptions != null)
            {
                requestExecutorBuilder
                    .AddApolloTracing(tracingOptions.TracingPreference, tracingOptions.TimestampProvider);
            }
            return requestExecutorBuilder;
        }

        public static IRequestExecutorBuilder AddUHeadlessGraphQL(this IRequestExecutorBuilder requestExecutorBuilder, bool throwOnSchemaError = false)
        {
            requestExecutorBuilder
                .InitializeOnStartup()
                .AddFiltering()
                .AddSorting()
                .OnSchemaError(HandleSchemaError(throwOnSchemaError))
                .AddQueryType<Query>()
                .AddTypeExtension<ContentQuery>()
                .AddTypeExtension<PropertyQuery>()
                .AddInterfaceType<IPublishedContentGraphType>()
                .AddInterfaceType<IPublishedElementGraphType>()
                .AddType<PublishedContentGraphType>()
                .AddType<PublishedContentTypeGraphType>()
                .AddType<PublishedElementGraphType>()
                .AddInterfaceType<IPublishedPropertyGraphType>()
                .AddType<PublishedPropertyGraphType>();

            return requestExecutorBuilder;
        }

        private static OnSchemaError HandleSchemaError(bool throwOnSchemaError)
        {
            return new OnSchemaError((dc, ex) => LogSchemaError(throwOnSchemaError, dc, ex));
        }

        private static void LogSchemaError(bool throwOnSchemaError, IDescriptorContext dc, Exception ex)
        {
            var logger = dc.Services.GetService<ILogger<Query>>();
            logger.LogError(ex, "Schema failed to generate. GraphQL is unavalible");
            if (throwOnSchemaError)
            {
                throw ex;
            }
        }
    }
}
