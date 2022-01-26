using AutoMapper;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Commands.Properties
{
    public class CreatePropertyValue
    {
        public CreatePropertyValue(IPublishedContent content, IPublishedProperty property, string culture)
        {
            Content = content;
            Property = property;
            Culture = culture;
        }

        public IPublishedContent Content { get; set; }
        public IPublishedProperty Property { get; set; }
        public string Culture { get; set; }
    }
}
