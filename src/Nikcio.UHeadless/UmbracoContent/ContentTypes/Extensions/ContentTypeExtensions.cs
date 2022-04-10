using Microsoft.Extensions.DependencyInjection;

namespace Nikcio.UHeadless.UmbracoContent.ContentTypes.Extensions
{
    public static class ContentTypeExtensions
    {
        public static IServiceCollection AddContentTypeServices(this IServiceCollection services)
        {
            services
                .AddFactories();

            return services;
        }
    }
}
