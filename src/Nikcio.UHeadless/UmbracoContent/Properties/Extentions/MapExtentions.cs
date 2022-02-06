using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.UmbracoContent.Properties.Maps;
using System;
using System.Collections.Generic;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Extentions
{
    public static class MapExtentions
    {
        public static IServiceCollection AddMaps(this IServiceCollection services, List<Action<IPropertyMap>> customPropertyMappings)
        {
            var propertyMap = new PropertyMap();

            services
                .AddSingleton<IPropertyMap>(propertyMap);

            if (customPropertyMappings != null)
            {
                foreach (var customPropertyMapping in customPropertyMappings)
                {
                    customPropertyMapping.Invoke(propertyMap);
                }
            }

            propertyMap.AddPropertyMapDefaults();

            return services;
        }
    }
}
