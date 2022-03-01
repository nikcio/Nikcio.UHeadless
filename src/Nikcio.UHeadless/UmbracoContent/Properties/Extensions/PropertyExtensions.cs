using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.UmbracoContent.Properties.Maps;
using System;
using System.Collections.Generic;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Extensions
{
    /// <summary>
    /// Property extensions
    /// </summary>
    public static class PropertyExtensions
    {
        /// <summary>
        /// Adds all the property services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="customPropertyMappings"></param>
        /// <returns></returns>
        public static IServiceCollection AddPropertyServices(this IServiceCollection services, List<Action<IPropertyMap>> customPropertyMappings)
        {
            services
                .AddPropertyFactories()
                .AddPropertyMaps(customPropertyMappings)
                .AddPropertyRepositories();

            return services;
        }
    }
}
