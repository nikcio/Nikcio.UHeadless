using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Options;
using Nikcio.UHeadless.Reflection.Extentions;
using Nikcio.UHeadless.UmbracoContent.Content.Extentions;
using Nikcio.UHeadless.UmbracoContent.Content.Queries;
using Nikcio.UHeadless.UmbracoContent.Properties.Extentions;
using Nikcio.UHeadless.UmbracoContent.Properties.Maps;
using Nikcio.UHeadless.UmbracoContent.Properties.Queries;
using System;
using System.Collections.Generic;
using System.Reflection;
using Umbraco.Cms.Core.DependencyInjection;

namespace Nikcio.UHeadless.Extentions
{
    /// <summary>
    /// The default UHeadless extentions used for the default setup
    /// </summary>
    public static class UHeadlessExtentions
    {
        /// <summary>
        /// Adds all services the UHeadless package needs
        /// </summary>
        /// <param name="builder">The Umbraco builder</param>
        /// <param name="automapperAssemblies">Any extra assemblies that should be added to Automapper</param>
        /// <param name="customPropertyMappings">Any custom mappings of properties</param>
        /// <param name="throwOnSchemaError">Should the schema builder throw an exception when a schema error occurs. (true = yes, false = no)</param>
        /// <param name="tracingOptions">Options for the Apollo tracing</param>
        /// <returns></returns>
        public static IUmbracoBuilder AddUHeadless(this IUmbracoBuilder builder,
                                                   List<Assembly> automapperAssemblies = null,
                                                   List<Action<IPropertyMap>> customPropertyMappings = null,
                                                   bool throwOnSchemaError = false,
                                                   TracingOptions tracingOptions = null,
                                                   bool useSecuity = false,
                                                   List<Func<IRequestExecutorBuilder, IRequestExecutorBuilder>> graphQLExtentions = null)
        {
            builder.Services.AddUHeadlessAutomapper(automapperAssemblies);

            builder.Services
                .AddReflectionServices()
                .AddContentServices()
                .AddPropertyServices(customPropertyMappings);

            if(graphQLExtentions == null)
            {
                graphQLExtentions = new List<Func<IRequestExecutorBuilder, IRequestExecutorBuilder>>
                { (builder) => 
                    builder
                        .AddTypeExtension<ContentQuery>()
                        .AddTypeExtension<PropertyQuery>() 
                };
            }

            builder.Services
                .AddGraphQLServer()
                .AddUHeadlessGraphQL(useSecuity, throwOnSchemaError, graphQLExtentions)
                .AddTracing(tracingOptions);

            return builder;
        }

        /// <summary>
        /// Creates a GraphQL endpoint at the graphQlPath or "/graphql" by default
        /// </summary>
        /// <param name="applicationBuilder">The application builder</param>
        /// <param name="corsPolicy">Alternate cors policy to use. If not defined it will call the UseCors()</param>
        /// <param name="graphQlPath">The path where the graphql endpoint will be placed</param>
        /// <returns></returns>
        public static IApplicationBuilder UseUHeadlessGraphQLEndpoint(this IApplicationBuilder applicationBuilder, string corsPolicy = null, string graphQlPath = "/graphql", bool useSecurity = false)
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
