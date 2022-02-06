using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Models;
using HotChocolate;

namespace Nikcio.UHeadless.UmbracoContent.ContentType.Models
{
    public class ContentTypeGraphType
    {
        [GraphQLDescription("Gets the unique key for the content type.")]
        public Guid Key { get; set; }

        [GraphQLDescription("Gets the content type identifier.")]
        public int Id { get; set; }

        [GraphQLDescription("Gets the content type alias.")]
        public string Alias { get; set; }

        [GraphQLDescription(" Gets the content item type.")]
        public PublishedItemType ItemType { get; set; }

        [GraphQLDescription("Gets the aliases of the content types participating in the composition.")]
        public HashSet<string> CompositionAliases { get; set; }

        [GraphQLDescription("Gets the content variations of the content type.")]
        public ContentVariation Variations { get; set; }

        [GraphQLDescription("Gets a value indicating whether this content type is for an element.")]
        public bool IsElement { get; set; }
    }
}
