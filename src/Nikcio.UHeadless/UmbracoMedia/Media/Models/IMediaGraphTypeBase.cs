using HotChocolate;
using Nikcio.UHeadless.UmbracoContent.Elements.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;

namespace Nikcio.UHeadless.UmbracoMedia.Media.Models
{
    /// <summary>
    /// Represents a Media item
    /// </summary>
    /// <typeparam name="TPropertyGraphType"></typeparam>
    [GraphQLDescription("Represents a Media item.")]
    public interface IMediaGraphTypeBase<TPropertyGraphType> : IElementGraphTypeBase<TPropertyGraphType>
        where TPropertyGraphType : IPropertyGraphTypeBase
    {
    }
}