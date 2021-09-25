namespace Nikcio.Umbraco.Headless.Core.Models.SiteModels.PageModels.PropertyModels
{
    public interface IPropertyModel
    {
        string Alias { get; set; }
        object Value { get; set; }
    }
}