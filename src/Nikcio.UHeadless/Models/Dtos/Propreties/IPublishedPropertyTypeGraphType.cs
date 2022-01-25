using Nikcio.UHeadless.Dtos.ContentTypes;
using System;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;

namespace Nikcio.UHeadless.Dtos.Propreties
{
    public interface IPublishedPropertyTypeGraphType
    {
        /// <summary>
        /// Gets the published content type containing the property type.
        /// </summary>
        PublishedContentTypeGraphType ContentType { get; }

        /// <summary>
        /// Gets the data type.
        /// </summary>
        PublishedDataType DataType { get; }

        /// <summary>
        /// Gets property type alias.
        /// </summary>
        string Alias { get; }

        /// <summary>
        /// Gets the property editor alias.
        /// </summary>
        string EditorAlias { get; }

        /// <summary>
        /// Gets a value indicating whether the property is a user content property.
        /// </summary>
        /// <remarks>A non-user content property is a property that has been added to a
        /// published content type by Umbraco but does not corresponds to a user-defined
        /// published property.</remarks>
        bool IsUserProperty { get; }

        /// <summary>
        /// Gets the content variations of the property type.
        /// </summary>
        ContentVariation Variations { get; }

        /// <summary>
        /// Gets the property cache level.
        /// </summary>
        PropertyCacheLevel CacheLevel { get; }

        /// <summary>
        /// Gets the property model CLR type.
        /// </summary>
        /// <remarks>
        /// <para>The model CLR type may be a <see cref="ModelType"/> type, or may contain <see cref="ModelType"/> types.</para>
        /// <para>For the actual CLR type, see <see cref="ClrType"/>.</para>
        /// </remarks>
        Type ModelClrType { get; }

        /// <summary>
        /// Gets the property CLR type.
        /// </summary>
        /// <remarks>
        /// <para>Returns the actual CLR type which does not contain <see cref="ModelType"/> types.</para>
        /// <para>Mapping from <see cref="ModelClrType"/> may throw if some <see cref="ModelType"/> instances
        /// could not be mapped to actual CLR types.</para>
        /// </remarks>
        Type ClrType { get; }
    }

}
