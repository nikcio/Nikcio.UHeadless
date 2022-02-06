using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;
using System.Linq;
using HotChocolate;
using AutoMapper;
using Nikcio.UHeadless.UmbracoContent.ContentType.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.Factories;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;

namespace Nikcio.UHeadless.UmbracoContent.Elements.Models
{
    [GraphQLDescription("Represents a element item.")]
    public class ElementGraphType : IElementGraphType
    {
        [GraphQLDescription("Gets the content type.")]
        public ContentTypeGraphType ContentType => Mapper.Map<ContentTypeGraphType>(Content.ContentType);

        [GraphQLDescription("Gets the unique key of the element.")]
        public Guid Key => Content.Key;

        [GraphQLDescription("Gets the properties of the element.")]
        public IEnumerable<PropertyGraphType> Properties => Content.Properties.Select(IPublishedProperty => propertyFactory.GetPropertyGraphType(IPublishedProperty, Content, Culture));

        [GraphQLIgnore]
        public IPropertyFactory propertyFactory { get; set; }

        [GraphQLIgnore]
        public IMapper Mapper { get; set; }

        [GraphQLIgnore]
        public IPublishedContent Content { get; set; }

        [GraphQLIgnore]
        public string Culture { get; set; }

        [GraphQLIgnore]
        public IElementGraphType SetInitalValues(IElementGraphType element, IPropertyFactory propertyFactory, string culture, IMapper mapper)
        {
            if (element == null)
            {
                return null;
            }
            element.propertyFactory = propertyFactory;
            element.Culture = culture;
            element.Mapper = mapper;
            return element;
        }
    }
}
