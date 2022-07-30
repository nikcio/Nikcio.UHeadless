using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Base.Properties.Extensions;
using Nikcio.UHeadless.Basics.Properties.Maps.Extensions;
using Nikcio.UHeadless.Content.Basics.Queries;
using Nikcio.UHeadless.Content.Extensions;
using Nikcio.UHeadless.ContentTypes.Extensions;
using Nikcio.UHeadless.Core.Reflection.Extensions;
using Nikcio.UHeadless.Extensions.Options;
using Nikcio.UHeadless.Media.Basics.Queries;
using Nikcio.UHeadless.Media.Extensions;
using Umbraco.Cms.Core.DependencyInjection;

namespace Nikcio.UHeadless.Extensions {
    /// <summary>
    /// The default UHeadless extensions used for the default setup
    /// </summary>
    public static class UHeadlessExtensions {
        /// <summary>
        /// Adds all services the UHeadless package needs
        /// </summary>
        /// <param name="builder">The Umbraco builder</param>
        /// <returns></returns>
        public static IUmbracoBuilder AddUHeadless(this IUmbracoBuilder builder) {
            var uHeadlessOptions = new UHeadlessOptions();
            return AddUHeadless(builder, uHeadlessOptions);
        }

        /// <summary>
        /// Adds all services the UHeadless package needs
        /// </summary>
        /// <param name="builder">The Umbraco builder</param>
        /// <param name="uHeadlessOptions"></param>
        /// <returns></returns>
        public static IUmbracoBuilder AddUHeadless(this IUmbracoBuilder builder, UHeadlessOptions uHeadlessOptions) {
            uHeadlessOptions.PropertyServicesOptions.PropertyMapOptions.PropertyMap.AddPropertyMapDefaults();

            builder.Services
                .AddReflectionServices()
                .AddContentServices()
                .AddPropertyServices(uHeadlessOptions.PropertyServicesOptions)
                .AddMediaServices()
                .AddContentTypeServices();

            if (uHeadlessOptions.UHeadlessGraphQLOptions.GraphQLExtensions == null) {
                uHeadlessOptions.UHeadlessGraphQLOptions.GraphQLExtensions = (builder) =>
                    builder
                        .AddTypeExtension<BasicContentQuery>()
                        .AddTypeExtension<BasicMediaQuery>();
            }

            var propertyValueTypes = uHeadlessOptions.PropertyServicesOptions.PropertyMapOptions.PropertyMap.GetAllTypes();

            uHeadlessOptions.UHeadlessGraphQLOptions.PropertyValueTypes.AddRange(propertyValueTypes);

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
        public static IApplicationBuilder UseUHeadlessGraphQLEndpoint(this IApplicationBuilder applicationBuilder) {
            var uHeadlessEndpointOptions = new UHeadlessEndpointOptions();
            return UseUHeadlessGraphQLEndpoint(applicationBuilder, uHeadlessEndpointOptions);
        }

        /// <summary>
        /// Creates a GraphQL endpoint at the graphQlPath or "/graphql" by default
        /// </summary>
        /// <param name="applicationBuilder">The application builder</param>
        /// <param name="uHeadlessEndpointOptions"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseUHeadlessGraphQLEndpoint(this IApplicationBuilder applicationBuilder, UHeadlessEndpointOptions uHeadlessEndpointOptions) {
            applicationBuilder.UseRouting();

            if (uHeadlessEndpointOptions.CorsPolicy != null) {
                applicationBuilder.UseCors(uHeadlessEndpointOptions.CorsPolicy);
            } else {
                applicationBuilder.UseCors();
            }

            if (uHeadlessEndpointOptions.UseSecurity) {
                applicationBuilder
                    .UseAuthentication()
                    .UseAuthorization();
            }

            applicationBuilder
                .UseEndpoints(endpoints => {
                    endpoints.MapGraphQL(uHeadlessEndpointOptions.GraphQLPath);
                });
            return applicationBuilder;
        }
    }
}
