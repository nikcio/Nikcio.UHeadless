using HotChocolate;
using System;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;

namespace Nikcio.UHeadless.UmbracoContent.PropertyTypes.Models
{
    /// <summary>
    /// Represents a property type
    /// </summary>
    [GraphQLDescription("Represents a property type.")]
    public interface IPropertyType
    {
        /// <summary>
        /// Gets the published content type containing the property typ
        /// </summary>
        [GraphQLDescription("Gets the published content type containing the property type.")]
        ContentTypes.Models.BasicContentType ContentType { get; }

        /// <summary>
        /// Gets the data type
        /// </summary>
        [GraphQLDescription("Gets the data type.")]
        PublishedDataType DataType { get; }

        /// <summary>
        /// Gets property type alias
        /// </summary>
        [GraphQLDescription("Gets property type alias.")]
        string Alias { get; }

        /// <summary>
        /// Gets the property editor alias
        /// </summary>
        [GraphQLDescription("Gets the property editor alias.")]
        string EditorAlias { get; }

        /// <summary>
        /// Gets a value indicating whether the property is a user content property
        /// </summary>
        [GraphQLDescription("Gets a value indicating whether the property is a user content property.")]
        bool IsUserProperty { get; }

        /// <summary>
        /// Gets the content variations of the property type
        /// </summary>
        [GraphQLDescription("Gets the content variations of the property type.")]
        ContentVariation Variations { get; }

        /// <summary>
        /// Gets the property cache level
        /// </summary>
        [GraphQLDescription("Gets the property cache level.")]
        PropertyCacheLevel CacheLevel { get; }

        /// <summary>
        /// Gets the property model CLR type
        /// </summary>
        [GraphQLDescription("Gets the property model CLR type.")]
        Type ModelClrType { get; }

        /// <summary>
        /// Gets the property CLR type
        /// </summary>
        [GraphQLDescription("Gets the property CLR type.")]
        Type ClrType { get; }
    }

}
