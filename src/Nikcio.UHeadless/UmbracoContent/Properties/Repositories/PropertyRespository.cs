using Nikcio.UHeadless.UmbracoContent.Properties.Factories;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Repositories
{
    /// <inheritdoc/>
    public class PropertyRespository<T> : IPropertyRespository<T>
        where T : IPropertyGraphTypeBase
    {
        private readonly IPropertyFactory<T> propertyFactory;
        private readonly IPublishedSnapshotAccessor publishedSnapshotAccessor;

        public PropertyRespository(IPropertyFactory<T> propertyFactory, IPublishedSnapshotAccessor publishedSnapshotAccessor)
        {
            this.propertyFactory = propertyFactory;
            this.publishedSnapshotAccessor = publishedSnapshotAccessor;
        }

        /// <inheritdoc/>
        public IEnumerable<T> GetProperties(Func<IPublishedContentCache, IPublishedContent> fetch, string culture)
        {
            if (publishedSnapshotAccessor.TryGetPublishedSnapshot(out var publishedSnapshot))
            {
                var content = fetch(publishedSnapshot?.Content);
                if (culture == null || content != null && content.IsInvariantOrHasCulture(culture))
                {
                    return GetProperties(content, culture);
                }
            }

            return null;
        }

        /// <inheritdoc/>
        public IEnumerable<T> GetProperties(IPublishedContent content, string culture)
        {
            return content.Properties.Select(IPublishedProperty => propertyFactory.GetPropertyGraphType(IPublishedProperty, content, culture));
        }
    }
}