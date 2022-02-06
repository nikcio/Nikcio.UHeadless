using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Repositories
{
    public interface IPropertyRespository
    {
        IEnumerable<IPublishedPropertyGraphType> GetProperties(Func<IPublishedContentCache, IPublishedContent> fetch, string culture);
        IEnumerable<IPublishedPropertyGraphType> GetProperties(IPublishedContent content, string culture);
    }
}