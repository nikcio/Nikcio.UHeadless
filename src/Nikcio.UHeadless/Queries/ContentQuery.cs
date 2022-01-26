using HotChocolate;
using Nikcio.UHeadless.Models.Dtos.Content;
using System;
using System.Collections.Generic;

namespace Nikcio.UHeadless.Queries
{
    public class ContentQuery
    {
        public IPublishedContentGraphType GetById([Service] ContentRepository contentRepository, int id, string culture = null, bool preview = false)
        {
            return contentRepository.GetContent(x => x.GetById(preview, id), culture);
        }

        public IPublishedContentGraphType GetByGuid([Service] ContentRepository contentRepository, Guid id, string culture = null, bool preview = false)
        {
            return contentRepository.GetContent(x => x.GetById(preview, id), culture);
        }

        public IPublishedContentGraphType GetByRoute([Service] ContentRepository contentRepository, string route, string culture = null, bool preview = false)
        {
            return contentRepository.GetContent(x => x.GetByRoute(preview, route, culture: culture), culture);
        }

        public IEnumerable<IPublishedContentGraphType> GetAtRoot([Service] ContentRepository contentRepository, string culture = null, bool preview = false)
        {
            return contentRepository.GetContentList(x => x.GetAtRoot(preview, culture), culture);
        }
    }
}
