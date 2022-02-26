using AutoMapper;
using HotChocolate;
using Nikcio.UHeadless.UmbracoContent.Properties.Factories;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Elements.Models
{
    public interface IElementGraphTypeBase<TPropertyGraphType>
        where TPropertyGraphType : IPropertyGraphTypeBase
    {
        [GraphQLIgnore]
        IPropertyFactory<TPropertyGraphType> PropertyFactory { get; set; }

        [GraphQLIgnore]
        IPublishedContent Content { get; set; }

        [GraphQLIgnore]
        string Culture { get; set; }

        [GraphQLIgnore]
        IMapper Mapper { get; set; }

        [GraphQLIgnore]
        public IElementGraphTypeBase<TPropertyGraphType> SetInitalValues(IElementGraphTypeBase<TPropertyGraphType> element, IPropertyFactory<TPropertyGraphType> propertyFactory, string culture, IMapper mapper);
    }
}
