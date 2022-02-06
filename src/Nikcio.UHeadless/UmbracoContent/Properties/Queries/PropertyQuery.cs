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
        [GraphQLDescription("Get properties based by content id.")]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<IPropertyGraphType> GetPropertiesById([Service] IPropertyRespository propertyRespository,
                                                                 [GraphQLDescription("The id of the content item.")] int id,
                                                                 [GraphQLDescription("The culture of the content item.")] string culture = null,
                                                                 [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
        {
            return propertyRespository.GetProperties(x => x.GetById(preview, id), culture);
        }

        [GraphQLDescription("Get properties by content guid.")]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<IPropertyGraphType> GetPropertiesByGuid([Service] IPropertyRespository propertyRespository,
                                                                   [GraphQLDescription("The guid of the content item.")] Guid id,
                                                                   [GraphQLDescription("The culture of the content item.")] string culture = null,
                                                                   [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
        {
            return propertyRespository.GetProperties(x => x.GetById(preview, id), culture);
        }

        [GraphQLDescription("Get properties by content route.")]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<IPropertyGraphType> GetPropertiesByRoute([Service] IPropertyRespository propertyRespository,
                                                                    [GraphQLDescription("The route of the content item.")] string route,
                                                                    [GraphQLDescription("The culture of the content item.")] string culture = null,
                                                                    [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
        {
            return propertyRespository.GetProperties(x => x.GetByRoute(preview, route, culture: culture), culture);
        }
    }
}
