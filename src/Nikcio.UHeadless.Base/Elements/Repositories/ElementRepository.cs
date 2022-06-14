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
    /// A repository for elements
    /// </summary>
    /// <typeparam name="TElement"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    public abstract class ElementRepository<TElement, TProperty>
        where TElement : IElement<TProperty>
        where TProperty : IProperty {
        /// <summary>
        /// A factory for creating elements
        /// </summary>
        protected readonly IElementFactory<TElement, TProperty> elementFactory;

        /// <inheritdoc/>
        protected ElementRepository(IUmbracoContextFactory umbracoContextFactory, IElementFactory<TElement, TProperty> elementFactory) {
            umbracoContextFactory.EnsureUmbracoContext();
            this.elementFactory = elementFactory;
        }

        /// <summary>
        /// Gets an element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        protected virtual TElement? GetElement(IPublishedContent? element, string? culture) {
            if (element == null) {
                return default;
            }

            return GetConvertedElement(element, culture);
        }

        /// <summary>
        /// Gets a list of elements
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        protected virtual IEnumerable<TElement?> GetElementList(IEnumerable<IPublishedContent>? elements, string? culture) {
            if (elements == null) {
                return Enumerable.Empty<TElement>();
            }

            return elements.Select(element => GetConvertedElement(element, culture));
        }

        /// <summary>
        /// Get the converted element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        protected virtual TElement? GetConvertedElement(IPublishedContent? element, string? culture) {
            return elementFactory.CreateElement(element, culture);
        }
    }
}
