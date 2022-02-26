using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.UmbracoContent.Content.Repositories;

namespace Nikcio.UHeadless.UmbracoContent.Content.Extentions
{
    /// <summary>
    /// Repository extentions
    /// </summary>
    public static class RepositoryExtentions
    {
        /// <summary>
        /// Adds all the content repositories
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddContentRepositories(this IServiceCollection services)
        {
            services
                .AddScoped(typeof(IContentRepository<,>), typeof(ContentRepository<,>));

            return services;
        }
    }
}
