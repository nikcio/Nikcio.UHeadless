using HotChocolate.Data;
using HotChocolate;
using Nikcio.UHeadless.Models.Dtos.Content;
using Nikcio.UHeadless.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotChocolate.Types;
using Nikcio.UHeadless.Models.Dtos.Propreties;

namespace Nikcio.UHeadless.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class PropertyQuery
    {
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<IPublishedPropertyGraphType> GetPropertiesById([Service] PropertyRespository propertyRespository, int id, string culture = null, bool preview = false)
        {
            return propertyRespository.GetProperties(x => x.GetById(preview, id), culture);
        }

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<IPublishedPropertyGraphType> GetPropertiesByGuid([Service] PropertyRespository propertyRespository, Guid id, string culture = null, bool preview = false)
        {
            return propertyRespository.GetProperties(x => x.GetById(preview, id), culture);
        }

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<IPublishedPropertyGraphType> GetPropertiesByRoute([Service] PropertyRespository propertyRespository, string route, string culture = null, bool preview = false)
        {
            return propertyRespository.GetProperties(x => x.GetByRoute(preview, route, culture: culture), culture);
        }
    }
}
