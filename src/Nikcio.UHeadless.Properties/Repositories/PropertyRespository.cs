using Nikcio.UHeadless.Properties.Factories;
using Nikcio.UHeadless.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;

namespace Nikcio.UHeadless.Properties.Repositories {
    /// <inheritdoc/>
    public class PropertyRespository<TProperty> : IPropertyRespository<TProperty>
        where TProperty : IProperty {
        /// <summary>
        /// A factory for creating properties
        /// </summary>
        protected readonly IPropertyFactory<TProperty> propertyFactory;

        /// <summary>
        /// A accessor for the published snapshot
        /// </summary>
        protected readonly IPublishedSnapshotAccessor publishedSnapshotAccessor;

        /// <inheritdoc/>
        public PropertyRespository(IPropertyFactory<TProperty> propertyFactory, IPublishedSnapshotAccessor publishedSnapshotAccessor) {
            this.propertyFactory = propertyFactory;
            this.publishedSnapshotAccessor = publishedSnapshotAccessor;
        }

        /// <inheritdoc/>
        public virtual IEnumerable<TProperty?>? GetProperties(Func<IPublishedContentCache?, IPublishedContent?> fetch, string? culture) {
            if (publishedSnapshotAccessor.TryGetPublishedSnapshot(out var publishedSnapshot)) {
                var content = fetch(publishedSnapshot?.Content);
                if ((content != null && culture == null) || content != null) {
                    return GetProperties(content, culture);
                }
            }

            return null;
        }

        /// <inheritdoc/>
        public virtual IEnumerable<TProperty?> GetProperties(IPublishedContent content, string? culture) {
            return content.Properties.Select(IPublishedProperty => propertyFactory.GetProperty(IPublishedProperty, content, culture));
        }
    }
}