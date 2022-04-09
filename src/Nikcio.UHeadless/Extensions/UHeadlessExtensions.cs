using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Extensions.Options;
using Nikcio.UHeadless.Reflection.Extensions;
using Nikcio.UHeadless.UmbracoContent.Content.Extensions;
using Nikcio.UHeadless.UmbracoContent.Content.Queries;
using Nikcio.UHeadless.UmbracoContent.Properties.Extensions;
using Nikcio.UHeadless.UmbracoContent.Properties.Queries;
using Nikcio.UHeadless.UmbracoMedia.Media.Extensions;
using Nikcio.UHeadless.UmbracoMedia.Media.Queries;
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
        /// <returns></returns>
        public static IUmbracoBuilder AddUHeadless(this IUmbracoBuilder builder)
        {
            var uHeadlessOptions = new UHeadlessOptions();
            return AddUHeadless(builder, uHeadlessOptions);
        }

        /// <summary>
        /// Adds all services the UHeadless package needs
        /// </summary>
        /// <param name="builder">The Umbraco builder</param>
        /// <param name="uHeadlessOptions"></param>
        /// <returns></returns>
        public static IUmbracoBuilder AddUHeadless(this IUmbracoBuilder builder, UHeadlessOptions uHeadlessOptions)
        {
            builder.Services
                .AddReflectionServices()
                .AddContentServices()
                .AddPropertyServices(uHeadlessOptions.PropertyServicesOptions)
                .AddMediaServices();

            if (uHeadlessOptions.UHeadlessGraphQLOptions.GraphQLExtensions == null)
            {
                uHeadlessOptions.UHeadlessGraphQLOptions.GraphQLExtensions = (builder) =>
                    builder
                        .AddTypeExtension<BasicContentQuery>()
                        .AddTypeExtension<BasicPropertyQuery>()
                        .AddTypeExtension<BasicMediaQuery>();
            }

            builder.Services
                .AddGraphQLServer()
                .AddUHeadlessGraphQL(uHeadlessOptions.UHeadlessGraphQLOptions)
                .AddTracing(uHeadlessOptions.TracingOptions);

            return builder;
        }


        /// <summary>
        /// Creates a GraphQL endpoint at the graphQlPath or "/graphql" by default
        /// </summary>
        /// <param name="applicationBuilder">The application builder</param>
        /// <returns></returns>
        public static IApplicationBuilder UseUHeadlessGraphQLEndpoint(this IApplicationBuilder applicationBuilder)
        {
            var uHeadlessEndpointOptions = new UHeadlessEndpointOptions();
            return UseUHeadlessGraphQLEndpoint(applicationBuilder, uHeadlessEndpointOptions);
        }

        /// <summary>
        /// Creates a GraphQL endpoint at the graphQlPath or "/graphql" by default
        /// </summary>
        /// <param name="applicationBuilder">The application builder</param>
        /// <param name="uHeadlessEndpointOptions"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseUHeadlessGraphQLEndpoint(this IApplicationBuilder applicationBuilder, UHeadlessEndpointOptions uHeadlessEndpointOptions)
        {
            applicationBuilder.UseRouting();

            if (uHeadlessEndpointOptions.CorsPolicy != null)
            {
                applicationBuilder.UseCors(uHeadlessEndpointOptions.CorsPolicy);
            }
            else
            {
                applicationBuilder.UseCors();
            }

            if (uHeadlessEndpointOptions.UseSecurity)
            {
                applicationBuilder
                    .UseAuthentication()
                    .UseAuthorization();
            }

            applicationBuilder
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapGraphQL(uHeadlessEndpointOptions.GraphQLPath);
                });
            return applicationBuilder;
        }
    }
}
