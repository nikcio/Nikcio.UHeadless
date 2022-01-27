using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Commands.BlockLists
{
    public class CreateElement
    {
        public CreateElement(IPublishedContent content, IPublishedElement element, string culture)
        {
            Content = content;
            Element = element;
            Culture = culture;
        }

        public IPublishedContent Content { get; set; }
        public IPublishedElement Element { get; set; }
        public string Culture { get; set; }
    }
}
