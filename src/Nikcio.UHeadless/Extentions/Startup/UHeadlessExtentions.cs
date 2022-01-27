using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Factories.Properties;
using Nikcio.UHeadless.Factories.Properties.PropertyValues;
using Nikcio.UHeadless.Factories.Reflection;
using Nikcio.UHeadless.Mappers.Properties;
using Nikcio.UHeadless.Models.Dtos.Content;
using Nikcio.UHeadless.Models.Dtos.ContentTypes;
using Nikcio.UHeadless.Models.Dtos.Elements;
using Nikcio.UHeadless.Models.Dtos.Propreties;
using Nikcio.UHeadless.Queries;
using System.Collections.Generic;
using System.Reflection;
using Umbraco.Cms.Core.DependencyInjection;

namespace Nikcio.UHeadless.Extentions.Startup
{
    public static class UHeadlessExtentions
    {
        public static IUmbracoBuilder AddUHeadless(this IUmbracoBuilder builder, List<Assembly> automapperAssemblies = null)
        {
            builder.Services.AddUHeadlessAutomapper(automapperAssemblies);

            builder.Services
                .AddScoped<ContentRepository>()
                .AddScoped<IPropertyFactory, PropertyFactory>()
                .AddScoped<IPropertyValueFactory, PropertyValueFactory>()
                .AddSingleton<IPropertyMap, PropertyMap>()
                .AddScoped<IDependencyReflectorFactory, DependencyReflectorFactory>();

            builder.Services
                .AddGraphQLServer()
                .AddUHeadlessGraphQL();

            return builder;
        }

        private static IServiceCollection AddUHeadlessAutomapper(this IServiceCollection services, List<Assembly> automapperAssemblies)
        {
            if (automapperAssemblies == null)
            {
                automapperAssemblies = new List<Assembly>();
            }

            automapperAssemblies.Add(typeof(UHeadlessExtentions).Assembly);

            services
                .AddAutoMapper(automapperAssemblies);

            return services;
        }

        public static IRequestExecutorBuilder AddUHeadlessGraphQL(this IRequestExecutorBuilder requestExecutorBuilder)
        {
            requestExecutorBuilder
                .OnSchemaError(new HotChocolate.Configuration.OnSchemaError((dc, ex) =>
                {
                    throw ex;
                }))
                .AddQueryType<ContentQuery>()
                .AddInterfaceType<IPublishedContentGraphType>()
                .AddInterfaceType<IPublishedElementGraphType>()
                .AddType<PublishedContentGraphType>()
                .AddType<PublishedContentTypeGraphType>()
                .AddType<PublishedElementGraphType>()
                .AddInterfaceType<IPublishedPropertyGraphType>()
                .AddType<PublishedPropertyGraphType>();
            return requestExecutorBuilder;
        }

        public static IApplicationBuilder UseUHeadlessGraphQLEndpoint(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapGraphQL();
                });
            return applicationBuilder;
        }

    }
}
