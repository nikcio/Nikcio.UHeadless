using HotChocolate.Data;
using HotChocolate;
using System;
using System.Collections.Generic;
using HotChocolate.Types;
using Nikcio.UHeadless.Queries;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.Repositories;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class PropertyQuery
    {
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<IPublishedPropertyGraphType> GetPropertiesById([Service] IPropertyRespository propertyRespository, int id, string culture = null, bool preview = false)
        {
            return propertyRespository.GetProperties(x => x.GetById(preview, id), culture);
        }

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<IPublishedPropertyGraphType> GetPropertiesByGuid([Service] IPropertyRespository propertyRespository, Guid id, string culture = null, bool preview = false)
        {
            return propertyRespository.GetProperties(x => x.GetById(preview, id), culture);
        }

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<IPublishedPropertyGraphType> GetPropertiesByRoute([Service] IPropertyRespository propertyRespository, string route, string culture = null, bool preview = false)
        {
            return propertyRespository.GetProperties(x => x.GetByRoute(preview, route, culture: culture), culture);
        }
    }
}
