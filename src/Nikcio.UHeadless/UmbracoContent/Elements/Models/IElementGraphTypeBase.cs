using HotChocolate;
using Nikcio.UHeadless.UmbracoContent.Properties.Factories;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Elements.Models
{
    /// <summary>
    /// Represents a element item
    /// </summary>
    /// <typeparam name="TPropertyGraphType"></typeparam>
    [GraphQLDescription("Represents a element item.")]
    public interface IElementGraphTypeBase<TPropertyGraphType>
        where TPropertyGraphType : IPropertyGraphTypeBase
    {
        /// <summary>
        /// The propertyFactory
        /// </summary>
        [GraphQLIgnore]
        IPropertyFactory<TPropertyGraphType>? PropertyFactory { get; set; }

        /// <summary>
        /// The content
        /// </summary>
        [GraphQLIgnore]
        IPublishedContent? Content { get; set; }

        /// <summary>
        /// The culture
        /// </summary>
        [GraphQLIgnore]
        string? Culture { get; set; }

        /// <summary>
        /// Sets a contents initial values
        /// </summary>
        /// <param name="element"></param>
        /// <param name="propertyFactory"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        [GraphQLIgnore]
        public IElementGraphTypeBase<TPropertyGraphType>? SetInitalValues(IElementGraphTypeBase<TPropertyGraphType> element, IPropertyFactory<TPropertyGraphType> propertyFactory, string? culture);
    }
}
