using System;
using System.Collections.Generic;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using Nikcio.UHeadless.Queries;
using Nikcio.UHeadless.UmbracoContent.Content.Models;
using Nikcio.UHeadless.UmbracoContent.Content.Queries;
using Nikcio.UHeadless.UmbracoContent.Content.Repositories;
using Nikcio.UHeadless.UmbracoElements.ContentTypes.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;

namespace TestProject {
    [ExtendObjectType(typeof(Query))]
    public class CustomContentQuery : ContentQuery<BasicContent<BasicProperty, BasicContentType>, BasicProperty> {
        [Authorize]
        public override IEnumerable<BasicContent<BasicProperty, BasicContentType>> GetContentAtRoot([Service(ServiceKind.Default)] IContentRepository<BasicContent<BasicProperty, BasicContentType>, BasicProperty> contentRepository, [GraphQLDescription("The culture.")] string culture = null, [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false) {
            return base.GetContentAtRoot(contentRepository, culture, preview);
        }

        [Authorize]
        public override BasicContent<BasicProperty, BasicContentType> GetContentByGuid([Service(ServiceKind.Default)] IContentRepository<BasicContent<BasicProperty, BasicContentType>, BasicProperty> contentRepository, [GraphQLDescription("The id to fetch.")] Guid id, [GraphQLDescription("The culture to fetch.")] string culture = null, [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false) {
            return base.GetContentByGuid(contentRepository, id, culture, preview);
        }

        [Authorize]
        public override BasicContent<BasicProperty, BasicContentType> GetContentById([Service(ServiceKind.Default)] IContentRepository<BasicContent<BasicProperty, BasicContentType>, BasicProperty> contentRepository, [GraphQLDescription("The id to fetch.")] int id, [GraphQLDescription("The culture to fetch.")] string culture = null, [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false) {
            return base.GetContentById(contentRepository, id, culture, preview);
        }

        [Authorize]
        public override BasicContent<BasicProperty, BasicContentType> GetContentByRoute([Service(ServiceKind.Default)] IContentRepository<BasicContent<BasicProperty, BasicContentType>, BasicProperty> contentRepository, [GraphQLDescription("The route to fetch.")] string route, [GraphQLDescription("The culture.")] string culture = null, [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false) {
            return base.GetContentByRoute(contentRepository, route, culture, preview);
        }
    }
}
