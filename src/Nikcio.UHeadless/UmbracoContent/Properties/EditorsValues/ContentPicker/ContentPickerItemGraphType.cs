using HotChocolate;
using System;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.ContentPicker
{
    [GraphQLDescription("Represents a content picker item.")]
    public class ContentPickerItemGraphType
    {
        [GraphQLDescription("Gets the url segment of the content item.")]
        public virtual string UrlSegment => Content.UrlSegment;

        [GraphQLDescription("Gets the url of a content item.")]
        public virtual string Url => Content.Url();

        [GraphQLDescription("Gets the absolute url of a content item.")]
        public virtual string AbsoluteUrl => Content.Url(mode: UrlMode.Absolute);

        [GraphQLDescription("Gets the name of a content item.")]
        public virtual string Name => Content.Name;

        [GraphQLDescription("Gets the id of a content item.")]
        public virtual int Id => Content.Id;

        [GraphQLDescription("Gets the key of a content item.")]
        public virtual Guid Key => Content.Key;

        [GraphQLIgnore]
        public virtual IPublishedContent Content { get; set; }

        public ContentPickerItemGraphType(IPublishedContent content)
        {
            Content = content;
        }
    }
}
