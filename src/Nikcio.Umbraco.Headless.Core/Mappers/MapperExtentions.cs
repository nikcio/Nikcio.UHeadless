using Microsoft.Extensions.DependencyInjection;
using Nikcio.Umbraco.Headless.Core.Mappers.Sites;
using Nikcio.Umbraco.Headless.Core.Mappers.Sites.Pages;
using Nikcio.Umbraco.Headless.Core.Mappers.Sites.Pages.PageData;

namespace Nikcio.Umbraco.Headless.Core.Mappers
{
    public static class MapperExtentions
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            var propertyMapper = new PropertyMapper();
            services.AddSingleton<IPropertyMapper>(propertyMapper);
            var pageMapper = new PageMapper();
            services.AddSingleton<IPageMapper>(pageMapper);
            var siteMapper = new SiteMapper();
            services.AddSingleton<ISiteMapper>(siteMapper);

            return services;
        }
    }
}
