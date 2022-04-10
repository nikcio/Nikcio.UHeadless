using Nikcio.UHeadless.UmbracoContent.Content.Commands;
using Nikcio.UHeadless.UmbracoContent.Elements.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.Factories;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;

namespace Nikcio.UHeadless.UmbracoContent.Content.Models
{
    public abstract class Content<TProperty> : Element<TProperty>
        where TProperty : IProperty
    {
        protected Content(CreateContent createContent, IPropertyFactory<TProperty> propertyFactory) : base(createContent.CreateElement, propertyFactory)
        {
        }
    }
}
