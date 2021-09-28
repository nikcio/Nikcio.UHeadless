using Nikcio.Umbraco.Headless.Core.Commands.Sites;
using Nikcio.Umbraco.Headless.Core.Commands.Sites.Pages;
using Nikcio.Umbraco.Headless.Core.Commands.Sites.Pages.PageData;
using Nikcio.Umbraco.Headless.Core.Mappers.Sites.Pages.PageData;
using Nikcio.Umbraco.Headless.Core.Models.SiteModels;
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
            CreatePropertyCommandBase = createPropertyCommandBase;
            this.propertyMapper = propertyMapper;
            AddPropertyMapDefaults();
        }

        private void AddPropertyMapDefaults()
        {
            if (!propertyMapper.ContainsEditor(Constants.Constants.Factories.DefaultKey))
            {
                propertyMapper.AddEditorMapping<PropertyModel>(Constants.Constants.Factories.DefaultKey);
            }
            if (!propertyMapper.ContainsEditor(UmbracoConstants.PropertyEditors.Aliases.BlockList))
            {
                propertyMapper.AddEditorMapping<BlockPropertyModel>(UmbracoConstants.PropertyEditors.Aliases.BlockList);
            }
        }

        public void SetCreatePropertyCommandBase(ICreatePageCommandBase createPageCommandBase)
        {
            CreatePropertyCommandBase.SetCreatePropertyCommandBase(createPageCommandBase);
        }

        public IPropertyModelBase GetPropertyData()
        {
            string propertyTypeAssemblyQualifiedName;
            if (propertyMapper.ContainsAlias(CreatePropertyCommandBase.Property.PropertyType.ContentType.Alias, CreatePropertyCommandBase.Property.PropertyType.Alias))
            {
                propertyTypeAssemblyQualifiedName = propertyMapper.GetAliasValue(CreatePropertyCommandBase.Property.PropertyType.ContentType.Alias, CreatePropertyCommandBase.Property.PropertyType.Alias);
                
            }
            else if (propertyMapper.ContainsEditor(CreatePropertyCommandBase.Property.PropertyType.EditorAlias))
            {
                propertyTypeAssemblyQualifiedName = propertyMapper.GetEditorValue(CreatePropertyCommandBase.Property.PropertyType.EditorAlias);
            }
            else
            {
                propertyTypeAssemblyQualifiedName = propertyMapper.GetEditorValue(Constants.Constants.Factories.DefaultKey);
            }
            return (IPropertyModelBase)Activator.CreateInstance(Type.GetType(propertyTypeAssemblyQualifiedName), new object[] { CreatePropertyCommandBase });
        }

        public IPropertyModelBase GetPropertyData(ICreatePageCommandBase createPageCommandBase)
        {
            SetCreatePropertyCommandBase(createPageCommandBase);
            return GetPropertyData();
        }
    }
}
