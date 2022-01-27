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

        public PublishedContentTypeGraphType ContentType { get; set; }

        public Guid Key { get; set; }

        public List<PublishedPropertyGraphType> Properties => Content.Properties.Select(IPublishedProperty => propertyFactory.GetPropertyGraphType(IPublishedProperty, Content, Culture)).ToList();

        [GraphQLIgnore]
        public IPublishedElementGraphType SetInitalValues(IPublishedElementGraphType element, IPropertyFactory propertyFactory, string culture, IMapper mapper)
        {
            element.propertyFactory = propertyFactory;
            element.Culture = culture;
            element.Mapper = mapper;
            return element;
        }
    }
}
