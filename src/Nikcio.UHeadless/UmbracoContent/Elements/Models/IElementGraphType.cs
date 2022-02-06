using AutoMapper;
using HotChocolate;
using Nikcio.UHeadless.UmbracoContent.ContentType.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.Factories;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Elements.Models
{
    [GraphQLDescription("Represents a element item.")]
    public interface IElementGraphType
    {
        [GraphQLDescription("Gets the content type.")]
        ContentTypeGraphType ContentType { get; }

        [GraphQLDescription("Gets the unique key of the element.")]
        Guid Key { get; }

        [GraphQLDescription("Gets the properties of the element.")]
        IEnumerable<PropertyGraphType> Properties { get; }

        [GraphQLIgnore]
        IPropertyFactory propertyFactory { get; set; }

        [GraphQLIgnore]
        IPublishedContent Content { get; set; }

        [GraphQLIgnore]
        string Culture { get; set; }

        [GraphQLIgnore]
        IMapper Mapper { get; set; }

        [GraphQLIgnore]
        IElementGraphType SetInitalValues(IElementGraphType element, IPropertyFactory propertyFactory, string culture, IMapper mapper);
    }

}
