using AutoMapper;
using Newtonsoft.Json;
using Nikcio.UHeadless.Dtos.Propreties;
using Nikcio.UHeadless.Dtos.Propreties.PropertyValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Automapper.Profiles.Properties
{
    public class PropertyProfile : Profile
    {
        public PropertyProfile()
        {
            //CreateMap<IPublishedProperty, PublishedPropertyComplexGraphType>();
            CreateMap<BlockListItem, PropertyValueBlocklistItemGraphType>()
                .ForMember(dest => dest.ContentUdi, opt => opt.MapFrom(src => src.ContentUdi));
                //.ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content));
        }
    }
}
