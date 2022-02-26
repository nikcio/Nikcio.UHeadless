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
        public string UrlSegment => Content.UrlSegment;

        [GraphQLDescription("Gets the url of a content item.")]
        public string Url => Content.Url();

        [GraphQLDescription("Gets the abosulte url of a content item.")]
        public string AbosulteUrl => Content.Url(mode: UrlMode.Absolute);

        [GraphQLDescription("Gets the name of a content item.")]
        public string Name => Content.Name;

        [GraphQLDescription("Gets the id of a content item.")]
        public int Id => Content.Id;

        [GraphQLDescription("Gets the key of a content item.")]
        public Guid Key => Content.Key;

        [GraphQLIgnore]
        public IPublishedContent Content { get; set; }

        public ContentPickerItemGraphType(IPublishedContent content)
        {
            Content = content;
        }
    }
}
