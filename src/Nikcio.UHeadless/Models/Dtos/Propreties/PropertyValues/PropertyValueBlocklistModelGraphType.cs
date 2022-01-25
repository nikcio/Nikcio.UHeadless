using AutoMapper;
using Nikcio.UHeadless.Commands.Properties;
using Nikcio.UHeadless.Models.Properties;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.Blocks;

namespace Nikcio.UHeadless.Models.Dtos.Propreties.PropertyValues
{
    public class PropertyValueBlocklistModelGraphType : PropertyValueBaseGraphType
    {
        public List<BlocklistItemGraphType> Blocks { get; set; }

        public PropertyValueBlocklistModelGraphType(CreatePropertyValue createPropertyValue, IMapper mapper)
        {
            var value = (BlockListModel)createPropertyValue.Property.GetValue();
            Blocks = value.ToList()
                ?.Select(blockListItem => new BlocklistItemGraphType(blockListItem, mapper)).ToList();
        }
    }
}
