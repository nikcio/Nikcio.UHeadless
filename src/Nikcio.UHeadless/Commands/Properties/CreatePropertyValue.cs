using AutoMapper;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Commands.Properties
{
    public class CreatePropertyValue
    {
        public IPublishedContent Content { get; set; }
        public IPublishedProperty Property { get; set; }
        public string Culture { get; set; }
        public IMapper Mapper { get; set; }
    }
}
