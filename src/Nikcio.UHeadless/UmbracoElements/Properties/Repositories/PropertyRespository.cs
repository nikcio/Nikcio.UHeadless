using Nikcio.UHeadless.UmbracoElements.Properties.Factories;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.UmbracoElements.Properties.Repositories
{
    /// <inheritdoc/>
    public class PropertyRespository<TProperty> : IPropertyRespository<TProperty>
        where TProperty : IProperty
    {
        /// <summary>
        /// A factory for creating properties
        /// </summary>
        protected readonly IPropertyFactory<TProperty> propertyFactory;

        /// <summary>
        /// A accessor for the published snapshot
        /// </summary>
        protected readonly IPublishedSnapshotAccessor publishedSnapshotAccessor;

        /// <inheritdoc/>
        public PropertyRespository(IPropertyFactory<TProperty> propertyFactory, IPublishedSnapshotAccessor publishedSnapshotAccessor)
        {
            this.propertyFactory = propertyFactory;
            this.publishedSnapshotAccessor = publishedSnapshotAccessor;
        }

        /// <inheritdoc/>
        public virtual IEnumerable<TProperty>? GetProperties(Func<IPublishedContentCache?, IPublishedContent?> fetch, string? culture)
        {
            if (publishedSnapshotAccessor.TryGetPublishedSnapshot(out var publishedSnapshot))
            {
                var content = fetch(publishedSnapshot?.Content);
                if (content != null && culture == null || content != null && content.IsInvariantOrHasCulture(culture))
                {
                    return GetProperties(content, culture);
                }
            }

            return null;
        }

        /// <inheritdoc/>
        public virtual IEnumerable<TProperty> GetProperties(IPublishedContent content, string? culture)
        {
            return content.Properties.Select(IPublishedProperty => propertyFactory.GetProperty(IPublishedProperty, content, culture));
        }
    }
}