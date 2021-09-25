using Microsoft.Extensions.DependencyInjection;
using Nikcio.Umbraco.Headless.Core.Services.Headless;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Nikcio.Umbraco.Headless.Core.Services
{
    public class ServicesComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddScoped<IHeadlessService, HeadlessService>();
        }
    }
}
