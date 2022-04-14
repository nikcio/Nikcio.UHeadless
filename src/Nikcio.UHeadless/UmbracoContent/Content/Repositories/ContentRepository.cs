using Nikcio.UHeadless.UmbracoContent.Content.Factories;
using Nikcio.UHeadless.UmbracoContent.Content.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;
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
    public class ContentRepository<TContent, TProperty> : IContentRepository<TContent, TProperty>
        where TContent : IContent<TProperty>
        where TProperty : IProperty
    {
        private readonly IPublishedSnapshotAccessor publishedSnapshotAccessor;
        private readonly IContentFactory<TContent, TProperty> contentFactory;

        /// <inheritdoc/>
        public ContentRepository(IPublishedSnapshotAccessor publishedSnapshotAccessor, IUmbracoContextFactory umbracoContextFactory, IContentFactory<TContent, TProperty> contentFactory)
        {
            umbracoContextFactory.EnsureUmbracoContext();
            this.publishedSnapshotAccessor = publishedSnapshotAccessor;
            this.contentFactory = contentFactory;
        }

        /// <inheritdoc/>
        public virtual TContent? GetContent(Func<IPublishedContentCache?, IPublishedContent?> fetch, string? culture)
        {
            if (publishedSnapshotAccessor.TryGetPublishedSnapshot(out var publishedSnapshot))
            {
                var content = fetch(publishedSnapshot?.Content);
                if (content != null && culture == null || content != null && content.IsInvariantOrHasCulture(culture))
                {
                    return GetConvertedContent(content, culture);
                }
            }

            return default;
        }

        /// <inheritdoc/>
        public virtual IEnumerable<TContent?> GetContentList(Func<IPublishedContentCache?, IEnumerable<IPublishedContent>?> fetch, string? culture)
        {
            if (publishedSnapshotAccessor.TryGetPublishedSnapshot(out var publishedSnapshot))
            {
                var contentList = fetch(publishedSnapshot?.Content);
                if (contentList != null)
                {
                    return contentList.Select(content => GetConvertedContent(content, culture));
                }
            }

            return new List<TContent>();
        }

        /// <inheritdoc/>
        public virtual TContent? GetConvertedContent(IPublishedContent content, string? culture)
        {
            return contentFactory.CreateContent(content, culture);
        }
    }
}
