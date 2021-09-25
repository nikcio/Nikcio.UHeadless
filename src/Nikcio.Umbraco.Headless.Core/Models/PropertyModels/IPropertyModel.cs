using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.Umbraco.Headless.Core.Models.SiteData.Elements
{
    public interface IPropertyModel
    {
        string Alias { get; set; }
        object Value { get; set; }
    }
}