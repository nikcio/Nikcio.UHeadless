using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Properties.Extensions.Options;
using Nikcio.UHeadless.Properties.Maps;

namespace Nikcio.UHeadless.Properties.Extensions {
    /// <summary>
    /// Map extensions
    /// </summary>
    public static class MapExtensions {
        /// <summary>
        /// Adds the property maps
        /// </summary>
        /// <param name="services"></param>
        /// <param name="propertyMapOptions"></param>
        /// <returns></returns>
        public static IServiceCollection AddPropertyMaps(this IServiceCollection services, PropertyMapOptions propertyMapOptions) {
            var propertyMap = new PropertyMap();

            services
                .AddSingleton<IPropertyMap>(propertyMap);

            if (propertyMapOptions.PropertyMappings != null) {
                foreach (var propertyMapping in propertyMapOptions.PropertyMappings) {
                    propertyMapping.Invoke(propertyMap);
                }
            }

            propertyMap.AddPropertyMapDefaults();

            return services;
        }
    }
}
