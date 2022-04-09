using HotChocolate;
using System;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.ContentPicker
{
    /// <summary>
    /// Represents a content picker item
    /// </summary>
    [GraphQLDescription("Represents a content picker item.")]
    public class BasicContentPickerItem
    {
        /// <summary>
        /// Gets the url segment of the content item
        /// </summary>
        [GraphQLDescription("Gets the url segment of the content item.")]
        public virtual string UrlSegment => Content.UrlSegment;

        /// <summary>
        /// Gets the url of a content item
        /// </summary>
        [GraphQLDescription("Gets the url of a content item.")]
        public virtual string Url => Content.Url();

        /// <summary>
        /// Gets the absolute url of a content item
        /// </summary>
        [GraphQLDescription("Gets the absolute url of a content item.")]
        public virtual string AbsoluteUrl => Content.Url(mode: UrlMode.Absolute);

        /// <summary>
        /// Gets the name of a content item
        /// </summary>
        [GraphQLDescription("Gets the name of a content item.")]
        public virtual string Name => Content.Name;

        /// <summary>
        /// Gets the id of a content item
        /// </summary>
        [GraphQLDescription("Gets the id of a content item.")]
        public virtual int Id => Content.Id;

        /// <summary>
        /// Gets the key of a content item
        /// </summary>
        [GraphQLDescription("Gets the key of a content item.")]
        public virtual Guid Key => Content.Key;

        /// <summary>
        /// The <see cref="IPublishedContent"/>
        /// </summary>
        [GraphQLIgnore]
        public virtual IPublishedContent Content { get; set; }

        /// <inheritdoc/>
        public BasicContentPickerItem(IPublishedContent content)
        {
            Content = content;
        }
    }
}
