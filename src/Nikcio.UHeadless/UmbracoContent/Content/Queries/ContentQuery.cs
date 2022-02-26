﻿using HotChocolate.Types;
using Nikcio.UHeadless.Queries;
using Nikcio.UHeadless.UmbracoContent.Content.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;

namespace Nikcio.UHeadless.UmbracoContent.Content.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class ContentQuery : ContentQueryBase<ContentGraphType<PropertyGraphType>, PropertyGraphType>
    {
    }
}
