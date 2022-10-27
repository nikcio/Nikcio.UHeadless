using HotChocolate.Types;
using Nikcio.UHeadless.Core.GraphQL.Mutations;
using Nikcio.UHeadless.Umbraco.Forms.Mutations;

namespace Nikcio.UHeadless.Umbraco.Forms.Basics.Mutations;

/// <summary>
/// Basic implementation of <see cref="UmbracoFormsMutation"/>
/// </summary>
[ExtendObjectType(typeof(Mutation))]
public class BasicUmbracoFormsMutation : UmbracoFormsMutation
{
}
