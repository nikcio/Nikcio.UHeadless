using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Commands.BlockLists
{
    public class CreateBlockListItem
    {
        public CreateBlockListItem(IPublishedContent content, BlockListItem blockListItem, string culture)
        {
            Content = content;
            BlockListItem = blockListItem;
            Culture = culture;
        }

        public IPublishedContent Content { get; set; }
        public BlockListItem BlockListItem { get; set; }
        public string Culture { get; set; }
    }
}
