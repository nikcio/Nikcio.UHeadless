using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Options;
using Nikcio.UHeadless.Reflection.Extentions;
using Nikcio.UHeadless.UmbracoContent.Content.Extentions;
using Nikcio.UHeadless.UmbracoContent.Properties.Extentions;
using Nikcio.UHeadless.UmbracoContent.Properties.Maps;
using System;
using System.Collections.Generic;
using System.Reflection;
using Umbraco.Cms.Core.DependencyInjection;

namespace Nikcio.UHeadless.Extentions
{
    public static class UHeadlessExtentions
    {
        public static IUmbracoBuilder AddUHeadless(this IUmbracoBuilder builder,
                                                   List<Assembly> automapperAssemblies = null,
                                                   List<Action<IPropertyMap>> customPropertyMappings = null,
                                                   bool throwOnSchemaError = false,
                                                   TracingOptions tracingOptions = null)
        {
            builder.Services.AddUHeadlessAutomapper(automapperAssemblies);

            builder.Services
                .AddReflectionServices()
                .AddContentServices()
                .AddPropertyServices(customPropertyMappings);

            builder.Services
                .AddGraphQLServer()
                .AddUHeadlessGraphQL(throwOnSchemaError)
                .AddTracing(tracingOptions);


            return builder;
        }

        public static IApplicationBuilder UseUHeadlessGraphQLEndpoint(this IApplicationBuilder applicationBuilder, string corsPolicy = null)
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

            applicationBuilder
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapGraphQL();
                });
            return applicationBuilder;
        }
    }
}
