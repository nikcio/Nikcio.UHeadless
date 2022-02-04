using Nikcio.UHeadless.Commands.Properties;
using Nikcio.UHeadless.Models.Dtos.Content;
using Nikcio.UHeadless.Models.Dtos.Propreties.PropertyValues;
using Nikcio.UHeadless.Queries;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Models.Properties.Content
{
    public class ContentPickerGraphType : PropertyValueBaseGraphType
    {
        public List<IPublishedContentGraphType> ContentList { get; set; } = new();

        public ContentPickerGraphType(CreatePropertyValue createPropertyValue, ContentRepository contentRepository) : base(createPropertyValue)
        {
            var objectValue = createPropertyValue.Property.GetValue(createPropertyValue.Culture);
            if (objectValue is IPublishedContent)
            {
                ContentList.Add(contentRepository.GetConvertedContent((IPublishedContent)objectValue, createPropertyValue.Culture));
            }
            else if (objectValue != null)
            {
                var contentList = (IEnumerable<IPublishedContent>)objectValue;
                if (contentList != null)
                {
                    foreach (var content in contentList)
                    {
                        ContentList.Add(contentRepository.GetConvertedContent(content, createPropertyValue.Culture));
                    }
                }
            }
        }
    }
}
