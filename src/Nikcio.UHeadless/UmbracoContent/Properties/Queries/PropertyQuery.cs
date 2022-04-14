using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.Repositories;
using System;
using System.Collections.Generic;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Queries
{
    /// <summary>
    /// A base for all property queries
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    public class PropertyQuery<TProperty>
        where TProperty : IProperty
    {
        /// <summary>
        /// Get properties by content guid
        /// </summary>
        /// <param name="propertyRespository"></param>
        /// <param name="id"></param>
        /// <param name="culture"></param>
        /// <param name="preview"></param>
        /// <returns></returns>
        [GraphQLDescription("Get properties by content guid.")]
        [UsePaging]
        [UseFiltering]
        public virtual IEnumerable<TProperty>? GetPropertiesByGuid([Service] IPropertyRespository<TProperty> propertyRespository,
                                                                   [GraphQLDescription("The guid of the content item.")] Guid id,
                                                                   [GraphQLDescription("The culture of the content item.")] string? culture = null,
                                                                   [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
        {
            return propertyRespository.GetProperties(x => x?.GetById(preview, id), culture);
        }

        /// <summary>
        /// Get properties based by content id
        /// </summary>
        /// <param name="propertyRespository"></param>
        /// <param name="id"></param>
        /// <param name="culture"></param>
        /// <param name="preview"></param>
        /// <returns></returns>
        [GraphQLDescription("Get properties based by content id.")]
        [UsePaging]
        [UseFiltering]
        public virtual IEnumerable<TProperty>? GetPropertiesById([Service] IPropertyRespository<TProperty> propertyRespository,
                                                                 [GraphQLDescription("The id of the content item.")] int id,
                                                                 [GraphQLDescription("The culture of the content item.")] string? culture = null,
                                                                 [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
        {
            return propertyRespository.GetProperties(x => x?.GetById(preview, id), culture);
        }

        /// <summary>
        /// Get properties by content route
        /// </summary>
        /// <param name="propertyRespository"></param>
        /// <param name="route"></param>
        /// <param name="culture"></param>
        /// <param name="preview"></param>
        /// <returns></returns>
        [GraphQLDescription("Get properties by content route.")]
        [UsePaging]
        [UseFiltering]
        public virtual IEnumerable<TProperty>? GetPropertiesByRoute([Service] IPropertyRespository<TProperty> propertyRespository,
                                                                    [GraphQLDescription("The route of the content item.")] string route,
                                                                    [GraphQLDescription("The culture of the content item.")] string? culture = null,
                                                                    [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
        {
            return propertyRespository.GetProperties(x => x?.GetByRoute(preview, route, culture: culture), culture);
        }
    }
}