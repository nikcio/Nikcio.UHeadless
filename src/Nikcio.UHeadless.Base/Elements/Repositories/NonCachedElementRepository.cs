using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Nikcio.UHeadless.Base.Elements.Factories;
using Nikcio.UHeadless.Base.Elements.Models;
using Nikcio.UHeadless.Base.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Web;

namespace Nikcio.UHeadless.Base.Elements.Repositories {
    /// <summary>
    /// A repository for get elements that doesn't appar in the published snapshot
    /// </summary>
    /// <typeparam name="TElement"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    public abstract class NonCachedElementRepository<TElement, TProperty> : ElementRepository<TElement, TProperty>
        where TElement : IElement<TProperty>
        where TProperty : IProperty {

        /// <inheritdoc/>
        protected NonCachedElementRepository(IUmbracoContextFactory umbracoContextFactory, IElementFactory<TElement, TProperty> elementFactory) : base(umbracoContextFactory, elementFactory) {
            umbracoContextFactory.EnsureUmbracoContext();
        }

        ///// <summary>
        ///// Gets an element
        ///// </summary>
        ///// <param name="element"></param>
        ///// <param name="culture"></param>
        ///// <returns></returns>
        //protected virtual TElement? GetElement(IPublishedContent? element, string? culture) {
        //    if (element == null) {
        //        return default;
        //    }

        //    return GetConvertedElement(element, culture);
        //}

        ///// <summary>
        ///// Gets a list of elements
        ///// </summary>
        ///// <param name="elements"></param>
        ///// <param name="culture"></param>
        ///// <returns></returns>
        //protected virtual IEnumerable<TElement?> GetElementList(IEnumerable<IPublishedContent>? elements, string? culture) {
        //    var publishedCache = GetPublishedCache(cacheSelector);
        //    if (publishedCache is not null and TPublishedCache typedPublishedCache) {
        //        return base.GetElementList(fetch(typedPublishedCache), culture);
        //    }
        //    return Enumerable.Empty<TElement>();
        //}
    }
}
