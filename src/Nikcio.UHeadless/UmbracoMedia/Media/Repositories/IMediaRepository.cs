using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using Nikcio.UHeadless.UmbracoMedia.Media.Models;
using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;

namespace Nikcio.UHeadless.UmbracoMedia.Media.Repositories
{
    /// <summary>
    /// A repository to get Media from Umbraco
    /// </summary>
    public interface IMediaRepository<T, TProperty>
        where T : IMedia<TProperty>
        where TProperty : IProperty
    {
        /// <summary>
        /// Gets the Media based on a fetch method
        /// </summary>
        /// <param name="fetch">The fetch method</param>
        /// <param name="culture">The culture</param>
        /// <returns></returns>
        T? GetMedia(Func<IPublishedMediaCache?, IPublishedContent?> fetch, string? culture);

        /// <summary>
        /// Gets a Media lsit based on a fetch method
        /// </summary>
        /// <param name="fetch">The fetch method</param>
        /// <param name="culture">The culture</param>
        /// <returns></returns>
        IEnumerable<T> GetMediaList(Func<IPublishedMediaCache?, IEnumerable<IPublishedContent>?> fetch, string? culture);

        /// <summary>
        /// Gets a <see cref="IPublishedContent"/> converted to T
        /// </summary>
        /// <param name="Media">The published Media</param>
        /// <param name="culture">The culture</param>
        /// <returns></returns>
        T GetConvertedMedia(IPublishedContent Media, string culture);
    }
}