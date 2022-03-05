using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;
using System.Linq;
using HotChocolate;
using AutoMapper;
using Nikcio.UHeadless.UmbracoContent.ContentType.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.Factories;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using HotChocolate.Data;

namespace Nikcio.UHeadless.UmbracoContent.Elements.Models
{
    /// <inheritdoc/>
    [GraphQLDescription("Represents a element item.")]
    public class ElementGraphType<TPropertyGraphType> : IElementGraphTypeBase<TPropertyGraphType>
        where TPropertyGraphType : IPropertyGraphTypeBase
    {
        /// <inheritdoc/>
        [GraphQLDescription("Gets the content type.")]
        public virtual ContentTypeGraphType? ContentType => Mapper?.Map<ContentTypeGraphType>(Content?.ContentType);

        /// <inheritdoc/>
        [GraphQLDescription("Gets the unique key of the element.")]
        public virtual Guid? Key => Content?.Key;

        /// <inheritdoc/>
        [GraphQLDescription("Gets the properties of the element.")]
        [UseFiltering]
        public virtual IEnumerable<TPropertyGraphType>? Properties => PropertyFactory != null ? Content?.Properties.Select(IPublishedProperty => PropertyFactory.GetPropertyGraphType(IPublishedProperty, Content, Culture)) : null;

        /// <inheritdoc/>
        [GraphQLIgnore]
        public virtual IPropertyFactory<TPropertyGraphType>? PropertyFactory { get; set; }

        /// <inheritdoc/>
        [GraphQLIgnore]
        public virtual IMapper? Mapper { get; set; }

        /// <inheritdoc/>
        [GraphQLIgnore]
        public virtual IPublishedContent? Content { get; set; }

        /// <inheritdoc/>
        [GraphQLIgnore]
        public virtual string? Culture { get; set; }

        /// <inheritdoc/>
        [GraphQLIgnore]
        public virtual IElementGraphTypeBase<TPropertyGraphType>? SetInitalValues(IElementGraphTypeBase<TPropertyGraphType>? element, IPropertyFactory<TPropertyGraphType>? propertyFactory, string? culture, IMapper? mapper)
        {
            if (element == null)
            {
                return null;
            }
            element.PropertyFactory = propertyFactory;
            element.Culture = culture ?? "";
            element.Mapper = mapper;
            return element;
        }
    }
}
