using HotChocolate;
using Nikcio.UHeadless.UmbracoElements.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.Fallback.Commands;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.ContentPicker
{
    /// <summary>
    /// Represents a content picker value
    /// </summary>
    [GraphQLDescription("Represents a content picker value.")]
    public class BasicContentPicker : PropertyValue
    {
        /// <summary>
        /// Gets the list of content
        /// </summary>
        [GraphQLDescription("Gets the list of content.")]
        public virtual List<BasicContentPickerItem> ContentList { get; set; } = new();

        /// <inheritdoc/>
        public BasicContentPicker(CreatePropertyValue createPropertyValue) : base(createPropertyValue)
        {
            var objectValue = createPropertyValue.Property.GetValue(createPropertyValue.Culture);
            if (objectValue is IPublishedContent content)
            {
                ContentList.Add(new BasicContentPickerItem(content));
            }
            else if (objectValue != null)
            {
                var contentList = (IEnumerable<IPublishedContent>)objectValue;
                if (contentList != null)
                {
                    foreach (var contentItem in contentList)
                    {
                        ContentList.Add(new BasicContentPickerItem(contentItem));
                    }
                }
            }
        }
    }
}
