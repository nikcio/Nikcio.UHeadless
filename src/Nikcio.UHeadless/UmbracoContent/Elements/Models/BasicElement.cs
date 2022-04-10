using HotChocolate;
using HotChocolate.Data;
using Nikcio.UHeadless.UmbracoContent.ContentTypes.Factories;
using Nikcio.UHeadless.UmbracoContent.ContentTypes.Models;
using Nikcio.UHeadless.UmbracoContent.Elements.Commands;
using Nikcio.UHeadless.UmbracoContent.Properties.Factories;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using System;
using System.Collections.Generic;

namespace Nikcio.UHeadless.UmbracoContent.Elements.Models
{
    /// <inheritdoc/>
    [GraphQLDescription("Represents a element item.")]
    public class BasicElement<TProperty, TContentType> : Element<TProperty>
        where TProperty : IProperty
        where TContentType : IContentType
    {
        protected virtual IContentTypeFactory<TContentType> ContentTypeFactory { get; }

        public BasicElement(CreateElement createElement, IPropertyFactory<TProperty> propertyFactory, IContentTypeFactory<TContentType> contentTypeFactory) : base(createElement, propertyFactory)
        {
            ContentTypeFactory = contentTypeFactory;
        }

        /// <inheritdoc/>
        [GraphQLDescription("Gets the content type.")]
        public virtual TContentType? ContentType => ContentTypeFactory.CreateContentType(Content.ContentType);

        /// <inheritdoc/>
        [GraphQLDescription("Gets the unique key of the element.")]
        public virtual Guid Key => Content.Key;

        /// <inheritdoc/>
        [GraphQLDescription("Gets the properties of the element.")]
        [UseFiltering]
        public virtual IEnumerable<TProperty> Properties => PropertyFactory.CreateProperties(Content, Culture);
    }
}
