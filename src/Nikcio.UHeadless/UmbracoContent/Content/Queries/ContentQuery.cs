using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Nikcio.UHeadless.Queries;
using Nikcio.UHeadless.UmbracoContent.Content.Models;
using Nikcio.UHeadless.UmbracoContent.Content.Repositories;
using System;
using System.Collections.Generic;

namespace Nikcio.UHeadless.UmbracoContent.Content.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class ContentQuery
    {
        [UseFiltering]
        [UseSorting]
        public IPublishedContentGraphType GetContentById([Service] ContentRepository contentRepository, int id, string culture = null, bool preview = false)
        {
            return contentRepository.GetContent(x => x.GetById(preview, id), culture);
        }

        [UseFiltering]
        [UseSorting]
        public IPublishedContentGraphType GetContentByGuid([Service] ContentRepository contentRepository, Guid id, string culture = null, bool preview = false)
        {
            return contentRepository.GetContent(x => x.GetById(preview, id), culture);
        }

        [UseFiltering]
        [UseSorting]
        public IPublishedContentGraphType GetContentByRoute([Service] ContentRepository contentRepository, string route, string culture = null, bool preview = false)
        {
            return contentRepository.GetContent(x => x.GetByRoute(preview, route, culture: culture), culture);
        }

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<IPublishedContentGraphType> GetContentAtRoot([Service] ContentRepository contentRepository, string culture = null, bool preview = false)
        {
            return contentRepository.GetContentList(x => x.GetAtRoot(preview, culture), culture);
        }
    }
}
