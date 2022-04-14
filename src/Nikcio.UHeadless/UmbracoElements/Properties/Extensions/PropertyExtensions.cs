using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.UmbracoElements.Properties.Extensions.Options;

namespace Nikcio.UHeadless.UmbracoElements.Properties.Extensions
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
        /// <param name="propertyServicesOptions"></param>
        /// <returns></returns>
        public static IServiceCollection AddPropertyServices(this IServiceCollection services, PropertyServicesOptions propertyServicesOptions)
        {
            services
                .AddPropertyFactories()
                .AddPropertyMaps(propertyServicesOptions.PropertyMapOptions)
                .AddPropertyRepositories();

            return services;
        }
    }

    /// <summary>
    /// Options for the property services
    /// </summary>
    public class PropertyServicesOptions
    {
        /// <summary>
        /// Options for the property map
        /// </summary>
        public PropertyMapOptions PropertyMapOptions { get; set; } = new();
    }
}
