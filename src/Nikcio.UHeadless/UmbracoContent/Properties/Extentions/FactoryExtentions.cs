using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.UmbracoContent.Properties.Factories;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Extentions
{
    public static class FactoryExtentions
    {
        public static IServiceCollection AddPropertyFactories(this IServiceCollection services)
        {
            services
                .AddScoped<IPropertyFactory, PropertyFactory>()
                .AddScoped<IPropertyValueFactory, PropertyValueFactory>();

            return services;
        }
    }
}
