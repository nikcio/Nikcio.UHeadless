using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Models;
using HotChocolate;

namespace Nikcio.UHeadless.UmbracoContent.ContentType.Models
{
    [GraphQLDescription("Represents a content type.")]
    public class ContentTypeGraphType
    {
        [GraphQLDescription("Gets the unique key for the content type.")]
        public virtual Guid Key { get; set; }

        [GraphQLDescription("Gets the content type identifier.")]
        public virtual int Id { get; set; }

        [GraphQLDescription("Gets the content type alias.")]
        public virtual string Alias { get; set; }

        [GraphQLDescription(" Gets the content item type.")]
        public virtual PublishedItemType ItemType { get; set; }

        [GraphQLDescription("Gets the aliases of the content types participating in the composition.")]
        public virtual HashSet<string> CompositionAliases { get; set; }

        [GraphQLDescription("Gets the content variations of the content type.")]
        public virtual ContentVariation Variations { get; set; }

        [GraphQLDescription("Gets a value indicating whether this content type is for an element.")]
        public virtual bool IsElement { get; set; }
    }
}
