using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.UmbracoContent.Content.Repositories;

namespace Nikcio.UHeadless.UmbracoContent.Content.Extentions
{
    public static class RepositoryExtentions
    {
        public static IServiceCollection AddContentRepositories(this IServiceCollection services)
        {
            services
                .AddScoped<IContentRepository, ContentRepository>();

            return services;
        }
    }
}
