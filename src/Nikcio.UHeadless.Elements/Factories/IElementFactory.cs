using Nikcio.UHeadless.Elements.Models;
using Nikcio.UHeadless.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Elements.Factories {
    /// <summary>
    /// A factory for creating an element
    /// </summary>
    /// <typeparam name="TElement"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    public interface IElementFactory<TElement, TProperty>
        where TElement : IElement<TProperty>
        where TProperty : IProperty {
        /// <summary>
        /// Creates an element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="culture"></param>
        TElement? CreateElement(IPublishedContent? element, string? culture);
    }
}
