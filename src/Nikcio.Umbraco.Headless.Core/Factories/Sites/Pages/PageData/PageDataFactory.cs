using Nikcio.Umbraco.Headless.Core.Commands.Sites.Pages;
using Nikcio.Umbraco.Headless.Core.Commands.Sites.Pages.PageData;
using Nikcio.Umbraco.Headless.Core.Mappers.Sites.Pages.PageData;
using Nikcio.Umbraco.Headless.Core.Models.SiteModels.PageModels.PropertyModels;
using UmbracoConstants = Umbraco.Cms.Core.Constants;

namespace Nikcio.Umbraco.Headless.Core.Factories.Sites.Pages.PageData
{
    public class PageDataFactory : IPageDataFactory
    {
        public ICreatePropertyCommandBase CreatePropertyCommandBase { get; protected set; }

        public PageDataFactory(ICreatePropertyCommandBase createPropertyCommandBase)
        {
            AddPropertyMapDefaults();
            CreatePropertyCommandBase = createPropertyCommandBase;
        }

        private static void AddPropertyMapDefaults()
        {
            if (!PropertyMapper.ContainsEditor(Constants.Constants.Factories.DefaultKey))
            {
                PropertyMapper.AddEditorMapping(Constants.Constants.Factories.DefaultKey, (x) => new PropertyModel(x));
            }
            if (!PropertyMapper.ContainsEditor(UmbracoConstants.PropertyEditors.Aliases.BlockList))
            {
                PropertyMapper.AddEditorMapping(UmbracoConstants.PropertyEditors.Aliases.BlockList, (x) => new BlockPropertyModel(x));
            }
        }

        public void SetCreatePropertyCommandBase(ICreatePageCommandBase createPageCommandBase)
        {
            CreatePropertyCommandBase.SetCreatePropertyCommandBase(createPageCommandBase);
        }

        public IPropertyModelBase GetPropertyData()
        {
            return PropertyMapper.ContainsAlias(CreatePropertyCommandBase.Property.PropertyType.ContentType.Alias, CreatePropertyCommandBase.Property.PropertyType.Alias)
                ? PropertyMapper.GetAliasValue(CreatePropertyCommandBase.Property.PropertyType.ContentType.Alias, CreatePropertyCommandBase.Property.PropertyType.Alias).Invoke(CreatePropertyCommandBase)
                : PropertyMapper.ContainsEditor(CreatePropertyCommandBase.Property.PropertyType.EditorAlias) 
                    ? PropertyMapper.GetEditorValue(CreatePropertyCommandBase.Property.PropertyType.EditorAlias).Invoke(CreatePropertyCommandBase)
                    : PropertyMapper.GetEditorValue(Constants.Constants.Factories.DefaultKey).Invoke(CreatePropertyCommandBase);
        }

        public IPropertyModelBase GetPropertyData(ICreatePageCommandBase createPageCommandBase)
        {
            SetCreatePropertyCommandBase(createPageCommandBase);
            return GetPropertyData();
        }
    }
}
