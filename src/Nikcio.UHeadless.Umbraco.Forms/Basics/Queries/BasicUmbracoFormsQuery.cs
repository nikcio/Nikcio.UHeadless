using HotChocolate.Types;
using Nikcio.UHeadless.Core.GraphQL.Queries;
using Nikcio.UHeadless.Umbraco.Forms.Queries;
using Umbraco.Cms.Core.Services;
using Umbraco.Forms.Core.Services;

namespace Nikcio.UHeadless.Umbraco.Forms.Basics.Queries;

/// <summary>
/// Basic implementation of <see cref="UmbracoFormsQuery"/>
/// </summary>
[ExtendObjectType(typeof(Query))]
public class BasicUmbracoFormsQuery : UmbracoFormsQuery
{
}
