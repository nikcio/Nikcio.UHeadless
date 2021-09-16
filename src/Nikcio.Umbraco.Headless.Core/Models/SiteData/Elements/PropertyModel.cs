using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.Umbraco.Headless.Core.Models.SiteData.Elements
{
    public class PropertyModel : IPropertyModel
    {
        public string Alias { get; set; }
        public object Value { get; set; }

        public PropertyModel(IPublishedProperty property)
        {
            Alias = property.Alias;
            Value = property.GetValue();
        }

        public static IPropertyModel Create(IPublishedProperty property)
        {
            return new PropertyModel(property);
        }
    }
}
