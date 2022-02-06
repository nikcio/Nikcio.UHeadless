using HotChocolate;
using Umbraco.Cms.Core.Models;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.MultiUrlPicker.Models
{
    [GraphQLDescription("Represents a link item.")]
    public class LinkGraphType
    {
        [GraphQLDescription("Gets the name of the link.")]
        public string Name { get; set; }

        [GraphQLDescription("Gets the target of the link.")]
        public string Target { get; set; }

        [GraphQLDescription("Gets the type of the link.")]
        public LinkType Type { get; set; }

        [GraphQLDescription("Gets the url of a link.")]
        public string Url { get; set; }

        public LinkGraphType(Link umbracoLink)
        {
            Name = umbracoLink.Name;
            Target = umbracoLink.Target;
            Type = umbracoLink.Type;
            Url = umbracoLink.Url;
        }
    }
}