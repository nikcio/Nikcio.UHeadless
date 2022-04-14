using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.UmbracoContent.ContentTypes.Factories;

namespace Nikcio.UHeadless.UmbracoContent.ContentTypes.Extensions
{
    /// <inheritdoc/>
    public static class FactoryExtensions
    {
        /// <summary>
        /// Adds factories
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddFactories(this IServiceCollection services)
        {
            services
                .AddScoped(typeof(IContentTypeFactory<>), typeof(ContentTypeFactory<>));

            return services;
        }
    }
}
