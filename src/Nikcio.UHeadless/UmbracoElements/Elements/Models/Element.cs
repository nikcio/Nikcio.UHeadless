using Nikcio.UHeadless.UmbracoElements.Elements.Commands;
using Nikcio.UHeadless.UmbracoElements.Properties.Factories;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoElements.Elements.Models
{
    /// <inheritdoc/>
    public abstract class Element<TProperty> : IElement<TProperty>
        where TProperty : IProperty
    {
        /// <inheritdoc/>
        protected Element(CreateElement createElement, IPropertyFactory<TProperty> propertyFactory)
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
