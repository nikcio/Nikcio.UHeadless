using AutoMapper;
using Nikcio.UHeadless.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Dtos.Propreties.PropertyValues
{
    public class PropertyValueBlocklistModelGraphType : PropertyValueBaseGraphType
    {
        public List<PropertyValueBlocklistItemGraphType> Blocks { get; set; }

        public PropertyValueBlocklistModelGraphType(IPublishedProperty property, IMapper mapper)
        {
            var value = (BlockListModel)property.GetValue();
            Blocks = value.ToList()
                ?.Select(blockListItem => new PropertyValueBlocklistItemGraphType(blockListItem, mapper)).ToList();
        }
    }
}
