using Nikcio.UHeadless.UmbracoContent.Content.Models;
using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;

namespace Nikcio.UHeadless.UmbracoContent.Content.Repositories
{
    public interface IContentRepository
    {
        IPublishedContentGraphType GetContent(Func<IPublishedContentCache, IPublishedContent> fetch, string culture);
        IEnumerable<IPublishedContentGraphType> GetContentList(Func<IPublishedContentCache, IEnumerable<IPublishedContent>> fetch, string culture);
        IPublishedContentGraphType GetConvertedContent(IPublishedContent content, string culture);
    }
}