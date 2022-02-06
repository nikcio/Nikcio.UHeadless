using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.UmbracoContent.Properties.Factories;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Extentions
{
    /// <summary>
    /// Factory extentions
    /// </summary>
    public static class FactoryExtentions
    {
        /// <summary>
        /// Adds all the property factories
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddPropertyFactories(this IServiceCollection services)
        {
            services
                .AddScoped<IPropertyFactory, PropertyFactory>()
                .AddScoped<IPropertyValueFactory, PropertyValueFactory>();

            return services;
        }
    }
}
