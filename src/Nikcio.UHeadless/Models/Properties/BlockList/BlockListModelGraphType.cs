using AutoMapper;
using Nikcio.UHeadless.Commands.Properties;
using Nikcio.UHeadless.Factories.Properties;
using Nikcio.UHeadless.Models.Properties;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.Blocks;

namespace Nikcio.UHeadless.Models.Dtos.Propreties.PropertyValues
{
    public class BlockListModelGraphType : PropertyValueBaseGraphType
    {
        public List<BlockListItemGraphType> Blocks { get; set; }

        public BlockListModelGraphType(CreatePropertyValue createPropertyValue, IMapper mapper, IPropertyFactory propertyFactory)
        {
            var value = (BlockListModel)createPropertyValue.Property.GetValue();
            Blocks = value.ToList()
                ?.Select(blockListItem => new BlockListItemGraphType(blockListItem, mapper, propertyFactory)).ToList();
        }
    }
}
