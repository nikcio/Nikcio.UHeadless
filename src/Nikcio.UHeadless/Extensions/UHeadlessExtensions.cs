using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Options;
using Nikcio.UHeadless.Reflection.Extensions;
using Nikcio.UHeadless.UmbracoContent.Content.Extensions;
using Nikcio.UHeadless.UmbracoContent.Content.Queries;
using Nikcio.UHeadless.UmbracoContent.Properties.Extensions;
using Nikcio.UHeadless.UmbracoContent.Properties.Maps;
using Nikcio.UHeadless.UmbracoContent.Properties.Queries;
using Nikcio.UHeadless.UmbracoMedia.Media.Extensions;
using Nikcio.UHeadless.UmbracoMedia.Media.Queries;
using System;
using System.Collections.Generic;
using System.Reflection;
using Umbraco.Cms.Core.DependencyInjection;

namespace Nikcio.UHeadless.Extensions
{
    /// <summary>
    /// The default UHeadless extensions used for the default setup
    /// </summary>
    public static class UHeadlessExtensions
    {
        /// <summary>
        /// Adds all services the UHeadless package needs
        /// </summary>
        /// <param name="builder">The Umbraco builder</param>
        /// <param name="automapperAssemblies">Any extra assemblies that should be added to Automapper</param>
        /// <param name="customPropertyMappings">Any custom mappings of properties</param>
        /// <param name="throwOnSchemaError">Should the schema builder throw an exception when a schema error occurs. (true = yes, false = no)</param>
        /// <param name="useSecurity"></param>
        /// <param name="tracingOptions">Options for the Apollo tracing</param>
        /// <param name="graphQLExtensions"></param>
        /// <returns></returns>
        public static IUmbracoBuilder AddUHeadless(this IUmbracoBuilder builder,
                                                   List<Assembly>? automapperAssemblies = null,
                                                   List<Action<IPropertyMap>>? customPropertyMappings = null,
                                                   bool throwOnSchemaError = false,
                                                   TracingOptions? tracingOptions = null,
                                                   bool useSecurity = false,
                                                   List<Func<IRequestExecutorBuilder, IRequestExecutorBuilder>>? graphQLExtensions = null)
        {
            builder.Services.AddUHeadlessAutomapper(automapperAssemblies);

            builder.Services
                .AddReflectionServices()
                .AddContentServices()
                .AddPropertyServices(customPropertyMappings)
                .AddMediaServices();

            if (graphQLExtensions == null)
            {
                graphQLExtensions = new List<Func<IRequestExecutorBuilder, IRequestExecutorBuilder>>
                { (builder) =>
                    builder
                        .AddTypeExtension<ContentQuery>()
                        .AddTypeExtension<PropertyQuery>()
                        .AddTypeExtension<MediaQuery>()
                };
            }

            builder.Services
                .AddGraphQLServer()
                .AddUHeadlessGraphQL(useSecurity, throwOnSchemaError, graphQLExtensions)
                .AddTracing(tracingOptions);

            return builder;
        }

        /// <summary>
        /// Creates a GraphQL endpoint at the graphQlPath or "/graphql" by default
        /// </summary>
        /// <param name="applicationBuilder">The application builder</param>
        /// <param name="corsPolicy">Alternate cors policy to use. If not defined it will call the UseCors()</param>
        /// <param name="graphQlPath">The path where the graphql endpoint will be placed</param>
        /// <param name="useSecurity"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseUHeadlessGraphQLEndpoint(this IApplicationBuilder applicationBuilder, string? corsPolicy = null, string graphQlPath = "/graphql", bool useSecurity = false)
        {
            applicationBuilder.UseRouting();

            if (corsPolicy != null)
            {
                applicationBuilder.UseCors(corsPolicy);
            }
            else
            {
                applicationBuilder.UseCors();
            }

            if (useSecurity)
            {
                applicationBuilder
                    .UseAuthentication()
                    .UseAuthorization();
            }

            applicationBuilder
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapGraphQL(graphQlPath);
                });
            return applicationBuilder;
        }
    }
}
