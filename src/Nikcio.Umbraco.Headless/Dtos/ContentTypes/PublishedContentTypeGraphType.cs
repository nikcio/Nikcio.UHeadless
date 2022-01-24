using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Models;

namespace Nikcio.Umbraco.Headless.Dtos.ContentTypes
{
    public class PublishedContentTypeGraphType
    {
        /// <summary>
        /// Gets the unique key for the content type.
        /// </summary>
        public Guid Key { get; set; }

        /// <summary>
        /// Gets the content type identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets the content type alias.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Gets the content item type.
        /// </summary>
        public PublishedItemType ItemType { get; set; }

        /// <summary>
        /// Gets the aliases of the content types participating in the composition.
        /// </summary>
        public HashSet<string> CompositionAliases { get; set; }

        /// <summary>
        /// Gets the content variations of the content type.
        /// </summary>
        public ContentVariation Variations { get; set; }

        /// <summary>
        /// Gets a value indicating whether this content type is for an element.
        /// </summary>
        public bool IsElement { get; set; }
    }
}
