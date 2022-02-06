using Umbraco.Cms.Core.Models;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.MultiUrlPicker.Models
{
    public class LinkGraphType
    {
        public string Name { get; set; }
        public string Target { get; set; }
        public LinkType Type { get; set; }
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