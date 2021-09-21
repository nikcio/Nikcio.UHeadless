using Microsoft.Extensions.DependencyInjection;
using Nikcio.Umbraco.Headless.Core.Models.SiteData.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Models.PublishedContent;
using UmbracoConstants = Umbraco.Cms.Core.Constants;

namespace Nikcio.Umbraco.Headless.Core.Factories
{
    public class PageDataFactoryComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddScoped<IPageDataFactory, PageDataFactory>();
        }
    }

    public class PageDataFactory : IPageDataFactory
    {
        public Dictionary<string, Func<IPublishedProperty, IPublishedContent, IPropertyModelBase>> PropertyMap { get; set; }

        public PageDataFactory()
        {
            PropertyMap = new()
            {
                { "Default", (x, y) => new PropertyModel(x) },
                { UmbracoConstants.PropertyEditors.Aliases.BlockList, (x, y) => new BlockPropertyModel(x, y, this) }
            };
        }

        public IPropertyModelBase GetPropertyData(IPublishedProperty publishedProperty, IPublishedContent content)
        {
            return PropertyMap.ContainsKey(publishedProperty.PropertyType.EditorAlias)
                ? PropertyMap[publishedProperty.PropertyType.EditorAlias].Invoke(publishedProperty, content)
                : PropertyMap["Default"].Invoke(publishedProperty, content);
        }
    }
}
