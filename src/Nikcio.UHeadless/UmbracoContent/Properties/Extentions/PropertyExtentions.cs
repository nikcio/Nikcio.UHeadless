using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.UmbracoContent.Properties.Maps;
using System;
using System.Collections.Generic;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Extentions
{
    public static class PropertyExtentions
    {
        public static IServiceCollection AddPropertyServices(this IServiceCollection services, List<Action<IPropertyMap>> customPropertyMappings)
        {
            services
                .AddPropertyFactories()
                .AddMaps(customPropertyMappings)
                .AddPropertyRepositories();

            return services;
        }
    }
}
