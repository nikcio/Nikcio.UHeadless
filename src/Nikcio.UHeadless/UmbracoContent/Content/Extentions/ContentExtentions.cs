using Microsoft.Extensions.DependencyInjection;

namespace Nikcio.UHeadless.UmbracoContent.Content.Extentions
{
    public static class ContentExtentions
    {
        public static IServiceCollection AddContentServices(this IServiceCollection services)
        {
            services
                .AddContentRepositories();

            return services;
        }
    }
}
