using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.UmbracoContent.Properties.Maps;
using System;
using System.Collections.Generic;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Extensions
{
    /// <summary>
    /// Map extensions
    /// </summary>
    public static class MapExtensions
    {
        /// <summary>
        /// Adds the property maps
        /// </summary>
        /// <param name="services"></param>
        /// <param name="customPropertyMappings">Any custom mappings of properties</param>
        /// <returns></returns>
        public static IServiceCollection AddPropertyMaps(this IServiceCollection services, List<Action<IPropertyMap>> customPropertyMappings)
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
