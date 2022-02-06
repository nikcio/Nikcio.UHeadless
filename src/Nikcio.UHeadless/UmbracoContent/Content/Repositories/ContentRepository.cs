using AutoMapper;
using Nikcio.UHeadless.UmbracoContent.Content.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.UmbracoContent.Content.Repositories
{
    /// <inheritdoc/>
    public class ContentRepository : IContentRepository
    {
        private readonly IPublishedSnapshotAccessor publishedSnapshotAccessor;
        private readonly IMapper mapper;
        private readonly IPropertyFactory propertyFactory;

        public ContentRepository(IPublishedSnapshotAccessor publishedSnapshotAccessor, IMapper mapper, IUmbracoContextFactory umbracoContextFactory, IPropertyFactory propertyFactory)
        {
            umbracoContextFactory.EnsureUmbracoContext();
            this.publishedSnapshotAccessor = publishedSnapshotAccessor;
            this.mapper = mapper;
            this.propertyFactory = propertyFactory;
        }

        /// <inheritdoc/>
        public IPublishedContentGraphType GetContent(Func<IPublishedContentCache, IPublishedContent> fetch, string culture)
        {
            if (publishedSnapshotAccessor.TryGetPublishedSnapshot(out var publishedSnapshot))
            {
                var content = fetch(publishedSnapshot?.Content);
                if (culture == null || content != null && content.IsInvariantOrHasCulture(culture))
                {
                    return GetConvertedContent(content, culture);
                }
            }

            return null;
        }

        /// <inheritdoc/>
        public IEnumerable<IPublishedContentGraphType> GetContentList(Func<IPublishedContentCache, IEnumerable<IPublishedContent>> fetch, string culture)
        {
            if (publishedSnapshotAccessor.TryGetPublishedSnapshot(out var publishedSnapshot))
            {
                var contentList = fetch(publishedSnapshot?.Content);
                if (contentList != null)
                {
                    return contentList.Select(content => GetConvertedContent(content, culture));
                }
            }

            return new List<IPublishedContentGraphType>();
        }

        /// <inheritdoc/>
        public IPublishedContentGraphType GetConvertedContent(IPublishedContent content, string culture)
        {
            var mappedObject = mapper.Map<PublishedContentGraphType>(content);
            mappedObject.SetInitalValues(mappedObject, propertyFactory, culture, mapper);
            return mappedObject;
        }
    }
}
