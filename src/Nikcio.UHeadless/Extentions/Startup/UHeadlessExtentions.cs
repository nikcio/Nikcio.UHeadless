using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Dtos.Content;
using Nikcio.UHeadless.Dtos.ContentTypes;
using Nikcio.UHeadless.Dtos.Elements;
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
            if (automapperAssemblies == null)
            {
                automapperAssemblies = new List<Assembly>();
            }
            automapperAssemblies.Add(typeof(UHeadlessExtentions).Assembly);
            builder.Services
                .AddAutoMapper(automapperAssemblies);

            builder.Services
                .AddScoped<ContentRepository>();

            builder.Services
                .AddGraphQLServer()
                .AddUHeadlessGraphQL();

            return builder;
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
                .AddType<PublishedElementGraphType>();
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
