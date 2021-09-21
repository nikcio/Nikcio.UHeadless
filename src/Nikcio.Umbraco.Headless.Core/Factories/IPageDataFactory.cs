using Nikcio.Umbraco.Headless.Core.Models.SiteData.Elements;
using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.Umbraco.Headless.Core.Factories
{
    public interface IPageDataFactory
    {
        Dictionary<string, Func<IPublishedProperty, IPublishedContent, IPropertyModelBase>> PropertyMap { get; set; }

        IPropertyModelBase GetPropertyData(IPublishedProperty publishedProperty, IPublishedContent content);
    }
}