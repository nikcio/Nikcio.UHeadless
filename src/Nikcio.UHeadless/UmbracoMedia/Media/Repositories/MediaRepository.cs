using AutoMapper;
using Nikcio.UHeadless.UmbracoContent.Properties.Factories;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using Nikcio.UHeadless.UmbracoMedia.Media.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.UmbracoMedia.Media.Repositories
{
    /// <inheritdoc/>
    public class MediaRepository<T, TPropertyGraphType> : IMediaRepository<T, TPropertyGraphType>
        where T : IMediaGraphTypeBase<TPropertyGraphType>, new()
        where TPropertyGraphType : IPropertyGraphTypeBase
    {
        private readonly IPublishedSnapshotAccessor publishedSnapshotAccessor;
        private readonly IMapper mapper;
        private readonly IPropertyFactory<TPropertyGraphType> propertyFactory;

        /// <inheritdoc/>
        public MediaRepository(IPublishedSnapshotAccessor publishedSnapshotAccessor, IMapper mapper, IUmbracoContextFactory umbracoContextFactory, IPropertyFactory<TPropertyGraphType> propertyFactory)
        {
            umbracoContextFactory.EnsureUmbracoContext();
            this.publishedSnapshotAccessor = publishedSnapshotAccessor;
            this.mapper = mapper;
            this.propertyFactory = propertyFactory;
        }

        /// <inheritdoc/>
        public virtual T? GetMedia(Func<IPublishedMediaCache?, IPublishedContent?> fetch, string? culture)
        {
            if (publishedSnapshotAccessor.TryGetPublishedSnapshot(out var publishedSnapshot))
            {
                var media = fetch(publishedSnapshot?.Media);
                if (media != null && culture == null || media != null && media.IsInvariantOrHasCulture(culture))
                {
                    return GetConvertedMedia(media, culture);
                }
            }

            return default;
        }

        /// <inheritdoc/>
        public virtual IEnumerable<T> GetMediaList(Func<IPublishedMediaCache?, IEnumerable<IPublishedContent>?> fetch, string? culture)
        {
            if (publishedSnapshotAccessor.TryGetPublishedSnapshot(out var publishedSnapshot))
            {
                var MediaList = fetch(publishedSnapshot?.Media);
                if (MediaList != null)
                {
                    return MediaList.Select(Media => GetConvertedMedia(Media, culture));
                }
            }

            return new List<T>();
        }

        /// <inheritdoc/>
        public virtual T GetConvertedMedia(IPublishedContent Media, string? culture)
        {
            var mappedObject = mapper.Map<T>(Media);
            mappedObject.SetInitalValues(mappedObject, propertyFactory, culture, mapper);
            return mappedObject;
        }
    }
}
