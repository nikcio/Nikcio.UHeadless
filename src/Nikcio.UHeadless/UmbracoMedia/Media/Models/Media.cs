using Nikcio.UHeadless.UmbracoElements.Elements.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.Factories;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;
using Nikcio.UHeadless.UmbracoMedia.Media.Commands;

namespace Nikcio.UHeadless.UmbracoMedia.Media.Models
{
    /// <summary>
    /// A base for media
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    public abstract class Media<TProperty> : Element<TProperty>, IMedia<TProperty>
        where TProperty : IProperty
    {
        /// <inheritdoc/>
        protected Media(CreateMedia createMedia, IPropertyFactory<TProperty> propertyFactory) : base(createMedia.CreateElement, propertyFactory)
        {
        }
    }
}
