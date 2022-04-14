using Nikcio.UHeadless.UmbracoContent.Elements.Commands;
using Nikcio.UHeadless.UmbracoContent.Properties.Factories;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Elements.Models
{
    /// <inheritdoc/>
    public abstract class Element<TProperty> : IElement<TProperty>
        where TProperty : IProperty
    {
        /// <inheritdoc/>
        public Element(CreateElement createElement, IPropertyFactory<TProperty> propertyFactory)
        {
            Content = createElement.Content;
            Culture = createElement.Culture;
            PropertyFactory = propertyFactory;
        }

        /// <summary>
        /// The propertyFactory
        /// </summary>
        protected IPropertyFactory<TProperty> PropertyFactory { get; }

        /// <summary>
        /// The content
        /// </summary>
        protected IPublishedContent Content { get; }

        /// <summary>
        /// The culture
        /// </summary>
        protected string? Culture { get; }
    }
}
