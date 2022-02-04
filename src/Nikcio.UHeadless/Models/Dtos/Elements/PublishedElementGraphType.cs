using System;
using System.Collections.Generic;
using Nikcio.UHeadless.Models.Dtos.Propreties;
using Nikcio.UHeadless.Models.Dtos.ContentTypes;
using Umbraco.Cms.Core.Models.PublishedContent;
using System.Linq;
using Nikcio.UHeadless.Factories.Properties;
using HotChocolate;
using AutoMapper;

namespace Nikcio.UHeadless.Models.Dtos.Elements
{
    public class PublishedElementGraphType : IPublishedElementGraphType
    {
        [GraphQLIgnore]
        public IPropertyFactory propertyFactory { get; set; }

        [GraphQLIgnore]
        public IMapper Mapper { get; set; }

        [GraphQLIgnore]
        public IPublishedContent Content { get; set; }

        [GraphQLIgnore]
        public string Culture { get; set; }

        public PublishedContentTypeGraphType ContentType => Mapper.Map<PublishedContentTypeGraphType>(Content.ContentType);

        public Guid Key => Content.Key;

        public List<PublishedPropertyGraphType> Properties => Content.Properties.Select(IPublishedProperty => propertyFactory.GetPropertyGraphType(IPublishedProperty, Content, Culture)).ToList();

        [GraphQLIgnore]
        public IPublishedElementGraphType SetInitalValues(IPublishedElementGraphType element, IPropertyFactory propertyFactory, string culture, IMapper mapper)
        {
            if(element == null)
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
