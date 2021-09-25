using Nikcio.Umbraco.Headless.Core.Commands.Sites.Pages.PageData;

namespace Nikcio.Umbraco.Headless.Core.Models.SiteModels.PageModels.PropertyModels
{
    public class PropertyModel : PropertyModelBase, IPropertyModel
    {
        public virtual string Alias { get; set; }
        public virtual string DataType { get; set; }
        public virtual object Value { get; set; }

        public PropertyModel(ICreatePropertyCommandBase createPropertyCommandBase)
        {
            Alias = createPropertyCommandBase.Property.Alias;
            DataType = createPropertyCommandBase.Property.PropertyType.DataType.EditorAlias;
            Value = createPropertyCommandBase.Property.GetValue();
        }
    }
}
