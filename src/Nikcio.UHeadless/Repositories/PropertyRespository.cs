using Nikcio.UHeadless.Factories.Properties;
using Nikcio.UHeadless.Models.Dtos.Propreties;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.Queries
{
    public class PropertyRespository
    {
        private readonly IPropertyFactory propertyFactory;
        private readonly IPublishedSnapshotAccessor publishedSnapshotAccessor;

        public PropertyRespository(IPropertyFactory propertyFactory, IPublishedSnapshotAccessor publishedSnapshotAccessor)
        {
            this.propertyFactory = propertyFactory;
            this.publishedSnapshotAccessor = publishedSnapshotAccessor;
        }

        public IEnumerable<IPublishedPropertyGraphType> GetProperties(Func<IPublishedContentCache, IPublishedContent> fetch, string culture)
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

        public IEnumerable<IPublishedPropertyGraphType> GetProperties(IPublishedContent content, string culture)
        {
            return content.Properties.Select(IPublishedProperty => propertyFactory.GetPropertyGraphType(IPublishedProperty, content, culture));
        }
    }
}