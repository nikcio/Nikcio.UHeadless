using Nikcio.Umbraco.Headless.Core.Commands.Sites.Pages;
using Nikcio.Umbraco.Headless.Core.Commands.Sites.Pages.PageData;
using Nikcio.Umbraco.Headless.Core.Mappers.Sites.Pages.PageData;
using Nikcio.Umbraco.Headless.Core.Models.SiteModels.PageModels.PropertyModels;
using System;
using UmbracoConstants = Umbraco.Cms.Core.Constants;

namespace Nikcio.Umbraco.Headless.Core.Factories.Sites.Pages.PageData
{
    public class PageDataFactory : IPageDataFactory
    {
        private readonly IPropertyMapper propertyMapper;

        public ICreatePropertyCommandBase CreatePropertyCommandBase { get; protected set; }

        public PageDataFactory(ICreatePropertyCommandBase createPropertyCommandBase, IPropertyMapper propertyMapper)
        {
            AddPropertyMapDefaults();
            CreatePropertyCommandBase = createPropertyCommandBase;
            this.propertyMapper = propertyMapper;
        }

        private void AddPropertyMapDefaults()
        {
            if (!propertyMapper.ContainsEditor(Constants.Constants.Factories.DefaultKey))
            {
                propertyMapper.AddEditorMapping(Constants.Constants.Factories.DefaultKey, typeof(PropertyModel));
            }
            if (!propertyMapper.ContainsEditor(UmbracoConstants.PropertyEditors.Aliases.BlockList))
            {
                propertyMapper.AddEditorMapping(UmbracoConstants.PropertyEditors.Aliases.BlockList, typeof(BlockPropertyModel));
            }
        }

        public void SetCreatePropertyCommandBase(ICreatePageCommandBase createPageCommandBase)
        {
            CreatePropertyCommandBase.SetCreatePropertyCommandBase(createPageCommandBase);
        }

        public IPropertyModelBase GetPropertyData()
        {
            return (IPropertyModelBase)(propertyMapper.ContainsAlias(CreatePropertyCommandBase.Property.PropertyType.ContentType.Alias, CreatePropertyCommandBase.Property.PropertyType.Alias)
                ? Activator.CreateInstance(propertyMapper.GetAliasValue(CreatePropertyCommandBase.Property.PropertyType.ContentType.Alias, CreatePropertyCommandBase.Property.PropertyType.Alias), new object[] { CreatePropertyCommandBase })
                : propertyMapper.ContainsEditor(CreatePropertyCommandBase.Property.PropertyType.EditorAlias)
                    ? Activator.CreateInstance(propertyMapper.GetEditorValue(CreatePropertyCommandBase.Property.PropertyType.EditorAlias), new object[] { CreatePropertyCommandBase })
                    : Activator.CreateInstance(propertyMapper.GetEditorValue(Constants.Constants.Factories.DefaultKey), new object[] { CreatePropertyCommandBase }));
        }

        public IPropertyModelBase GetPropertyData(ICreatePageCommandBase createPageCommandBase)
        {
            SetCreatePropertyCommandBase(createPageCommandBase);
            return GetPropertyData();
        }
    }
}
