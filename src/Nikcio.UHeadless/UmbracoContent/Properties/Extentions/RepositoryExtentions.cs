using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.UmbracoContent.Properties.Repositories;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Extentions
{
    /// <summary>
    /// Repository extentions
    /// </summary>
    public static class RepositoryExtentions
    {
        /// <summary>
        /// Adds all property reposiotries
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddPropertyRepositories(this IServiceCollection services)
        {
            services
                .AddScoped<IPropertyRespository, PropertyRespository>();

            return services;
        }
    }
}
