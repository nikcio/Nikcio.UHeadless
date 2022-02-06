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
    public class PublishedElementGraphType : IElementGraphType
    {
        [GraphQLIgnore]
        public IPropertyFactory propertyFactory { get; set; }

        [GraphQLIgnore]
        public IMapper Mapper { get; set; }

        [GraphQLIgnore]
        public IPublishedContent Content { get; set; }

        [GraphQLIgnore]
        public string Culture { get; set; }

        public ContentTypeGraphType ContentType => Mapper.Map<ContentTypeGraphType>(Content.ContentType);

        public Guid Key => Content.Key;

        public IEnumerable<PropertyGraphType> Properties => Content.Properties.Select(IPublishedProperty => propertyFactory.GetPropertyGraphType(IPublishedProperty, Content, Culture));

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
