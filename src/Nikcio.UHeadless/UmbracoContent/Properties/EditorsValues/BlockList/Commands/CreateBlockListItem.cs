using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.BlockList.Commands
{
    public class CreateBlockListItem
    {
        public CreateBlockListItem(IPublishedContent content, BlockListItem blockListItem, string culture)
        {
            Content = content;
            BlockListItem = blockListItem;
            Culture = culture;
        }

        public virtual IPublishedContent Content { get; set; }
        public virtual BlockListItem BlockListItem { get; set; }
        public virtual string Culture { get; set; }
    }
}
