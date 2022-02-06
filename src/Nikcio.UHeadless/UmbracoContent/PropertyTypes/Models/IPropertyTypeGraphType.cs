using HotChocolate;
using Nikcio.UHeadless.UmbracoContent.ContentType.Models;
using System;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;

namespace Nikcio.UHeadless.UmbracoContent.PropertyTypes.Models
{
    [GraphQLDescription("Represents a property type.")]
    public interface IPropertyTypeGraphType
    {
        [GraphQLDescription("Gets the published content type containing the property type.")]
        ContentTypeGraphType ContentType { get; }

        [GraphQLDescription("Gets the data type.")]
        PublishedDataType DataType { get; }

        [GraphQLDescription("Gets property type alias.")]
        string Alias { get; }

        [GraphQLDescription("Gets the property editor alias.")]
        string EditorAlias { get; }

        [GraphQLDescription("Gets a value indicating whether the property is a user content property.")]
        bool IsUserProperty { get; }

        [GraphQLDescription("Gets the content variations of the property type.")]
        ContentVariation Variations { get; }

        [GraphQLDescription("Gets the property cache level.")]
        PropertyCacheLevel CacheLevel { get; }

        [GraphQLDescription("Gets the property model CLR type.")]
        Type ModelClrType { get; }

        [GraphQLDescription("Gets the property CLR type.")]
        Type ClrType { get; }
    }

}
