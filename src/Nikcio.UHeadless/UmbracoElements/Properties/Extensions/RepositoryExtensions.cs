using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.UmbracoElements.Properties.Repositories;

namespace Nikcio.UHeadless.UmbracoElements.Properties.Extensions
{
    /// <summary>
    /// Repository extensions
    /// </summary>
    public static class RepositoryExtensions
    {
        /// <summary>
        /// Adds all property reposiotries
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddPropertyRepositories(this IServiceCollection services)
        {
            services
                .AddScoped(typeof(IPropertyRespository<>), typeof(PropertyRespository<>));

            return services;
        }
    }
}
