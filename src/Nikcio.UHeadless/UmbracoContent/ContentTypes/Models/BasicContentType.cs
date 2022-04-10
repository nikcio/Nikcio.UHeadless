using HotChocolate;
using Nikcio.UHeadless.UmbracoContent.ContentTypes.Commands;
using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.ContentTypes.Models
{
    /// <summary>
    /// Represents a content type
    /// </summary>
    [GraphQLDescription("Represents a content type.")]
    public class BasicContentType : ContentType
    {
        public BasicContentType(CreateContentType createContentType) : base(createContentType)
        {
        }

        /// <summary>
        /// Gets the unique key for the content type
        /// </summary>
        [GraphQLDescription("Gets the unique key for the content type.")]
        public virtual Guid Key => PublishedContentType.Key;

        /// <summary>
        /// Gets the content type identifier
        /// </summary>
        [GraphQLDescription("Gets the content type identifier.")]
        public virtual int Id => PublishedContentType.Id;

        /// <summary>
        /// Gets the content type alias
        /// </summary>
        [GraphQLDescription("Gets the content type alias.")]
        public virtual string? Alias => PublishedContentType.Alias;

        /// <summary>
        /// Gets the content item type
        /// </summary>
        [GraphQLDescription("Gets the content item type.")]
        public virtual PublishedItemType ItemType => PublishedContentType.ItemType;

        /// <summary>
        /// Gets the aliases of the content types participating in the composition
        /// </summary>
        [GraphQLDescription("Gets the aliases of the content types participating in the composition.")]
        public virtual HashSet<string>? CompositionAliases => PublishedContentType.CompositionAliases;

        /// <summary>
        /// Gets the content variations of the content type
        /// </summary>
        [GraphQLDescription("Gets the content variations of the content type.")]
        public virtual ContentVariation Variations => PublishedContentType.Variations;

        /// <summary>
        /// Gets a value indicating whether this content type is for an element
        /// </summary>
        [GraphQLDescription("Gets a value indicating whether this content type is for an element.")]
        public virtual bool IsElement => PublishedContentType.IsElement;
    }
}
