using Microsoft.Extensions.DependencyInjection;
using Nikcio.Umbraco.Headless.Core.Mappers.SiteData;
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
    public class PageDataFactory : IPageDataFactory
    {
        public PageDataFactory()
        {
            AddPropertyMapDefaults();
        }

        private void AddPropertyMapDefaults()
        {
            if (!PropertyMapper.PropertyMap.ContainsKey(Constants.Constants.Factories.DefaultKey))
            {
                PropertyMapper.PropertyMap.Add(Constants.Constants.Factories.DefaultKey, (x, y) => new PropertyModel(x));
            }
            if (!PropertyMapper.PropertyMap.ContainsKey(UmbracoConstants.PropertyEditors.Aliases.BlockList))
            {
                PropertyMapper.PropertyMap.Add(UmbracoConstants.PropertyEditors.Aliases.BlockList, (x, y) => new BlockPropertyModel(x, y, this));
            }
        }

        public IPropertyModelBase GetPropertyData(IPublishedProperty publishedProperty, IPublishedContent content)
        {
            return PropertyMapper.PropertyMap.ContainsKey(publishedProperty.PropertyType.EditorAlias)
                ? PropertyMapper.PropertyMap[publishedProperty.PropertyType.EditorAlias].Invoke(publishedProperty, content)
                : PropertyMapper.PropertyMap[Constants.Constants.Factories.DefaultKey].Invoke(publishedProperty, content);
        }
    }
}
