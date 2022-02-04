using AutoMapper;
using HotChocolate;
using Nikcio.UHeadless.Factories.Properties;
using Nikcio.UHeadless.Models.Dtos.ContentTypes;
using Nikcio.UHeadless.Models.Dtos.Propreties;
using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Models.Dtos.Elements
{
    public interface IPublishedElementGraphType
    {
        PublishedContentTypeGraphType ContentType { get; }

        Guid Key { get; }

        public List<PublishedPropertyGraphType> Properties { get; }

        [GraphQLIgnore]
        public IPropertyFactory propertyFactory { get; set; }

        [GraphQLIgnore]
        IPublishedContent Content { get; set; }

        [GraphQLIgnore]
        string Culture { get; set; }

        [GraphQLIgnore]
        public IMapper Mapper { get; set; }

        [GraphQLIgnore]
        IPublishedElementGraphType SetInitalValues(IPublishedElementGraphType element, IPropertyFactory propertyFactory, string culture, IMapper mapper);
    }

}
