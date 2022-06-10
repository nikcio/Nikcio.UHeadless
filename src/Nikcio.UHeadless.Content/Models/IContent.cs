using HotChocolate;
using Nikcio.UHeadless.Elements.Models;
using Nikcio.UHeadless.Properties.Models;

namespace Nikcio.UHeadless.Content.Models {
    /// <summary>
    /// Represents a content item
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    [GraphQLDescription("Represents a content item.")]
    public interface IContent<TProperty> : IElement<TProperty>
        where TProperty : IProperty {

        /// <summary>
        /// Redirect information for a content node
        /// </summary>
        [GraphQLDescription("Redirect information for a content node")]
        public object? Redirect { get; set; }
    }
}