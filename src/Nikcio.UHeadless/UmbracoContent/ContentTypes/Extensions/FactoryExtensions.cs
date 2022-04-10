using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.UmbracoContent.ContentTypes.Factories;

namespace Nikcio.UHeadless.UmbracoContent.ContentTypes.Extensions
{
    public static class FactoryExtensions
    {
        public static IServiceCollection AddFactories(this IServiceCollection services)
        {
            services
                .AddScoped(typeof(IContentTypeFactory<>), typeof(ContentTypeFactory<>));

            return services;
        }
    }
}
