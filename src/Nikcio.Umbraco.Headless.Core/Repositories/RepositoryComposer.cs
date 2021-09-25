using Microsoft.Extensions.DependencyInjection;
using Nikcio.Umbraco.Headless.Core.Repositories.Umbraco.Content;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Nikcio.Umbraco.Headless.Core.Repositories
{
    public class RepositoryComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddScoped<IUmbracoContentRepository, UmbracoContentRepository>();
        }
    }
}
