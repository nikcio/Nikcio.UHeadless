using HotChocolate;
using Nikcio.UHeadless.UmbracoContent.Elements.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;

namespace Nikcio.UHeadless.UmbracoContent.Content.Models
{
    /// <summary>
    /// Represents a content item
    /// </summary>
    /// <typeparam name="TPropertyGraphType"></typeparam>
    [GraphQLDescription("Represents a content item.")]
    public interface IContentGraphTypeBase<TPropertyGraphType> : IElementGraphTypeBase<TPropertyGraphType>
        where TPropertyGraphType : IPropertyGraphTypeBase
    {
    }
}