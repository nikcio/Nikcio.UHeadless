using HotChocolate;
using HotChocolate.Data;
using Nikcio.UHeadless.UmbracoContent.Properties.Factories;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Elements.Models
{
    /// <inheritdoc/>
    [GraphQLDescription("Represents a element item.")]
    public class BasicElement<TProperty> : IElement<TProperty>
        where TProperty : IProperty
    {
        /// <inheritdoc/>
        [GraphQLDescription("Gets the content type.")]
        public virtual ContentType.Models.ContentType? ContentType => throw new NotImplementedException(); //TODO //Mapper?.Map<ContentType>(BasicContent?.ContentType);

        /// <inheritdoc/>
        [GraphQLDescription("Gets the unique key of the element.")]
        public virtual Guid? Key => Content?.Key;

        /// <inheritdoc/>
        [GraphQLDescription("Gets the properties of the element.")]
        [UseFiltering]
        public virtual IEnumerable<TProperty>? Properties => PropertyFactory != null ? Content?.Properties.Select(IPublishedProperty => PropertyFactory.GeTProperty(IPublishedProperty, Content, Culture)) : null;

        /// <inheritdoc/>
        [GraphQLIgnore]
        public virtual IPropertyFactory<TProperty>? PropertyFactory { get; set; }

        /// <inheritdoc/>
        [GraphQLIgnore]
        public virtual IPublishedContent? Content { get; set; }

        /// <inheritdoc/>
        [GraphQLIgnore]
        public virtual string? Culture { get; set; }

        /// <inheritdoc/>
        [GraphQLIgnore]
        public virtual IElement<TProperty>? SetInitalValues(IElement<TProperty>? element, IPropertyFactory<TProperty>? propertyFactory, string? culture)
        {
            if (element == null)
            {
                return null;
            }
            element.PropertyFactory = propertyFactory;
            element.Culture = culture ?? "";
            return element;
        }
    }
}
