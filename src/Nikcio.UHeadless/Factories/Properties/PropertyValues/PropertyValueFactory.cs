using Nikcio.UHeadless.Commands.Properties;
using Nikcio.UHeadless.Mappers.Properties;
using Nikcio.UHeadless.Models.Dtos.Propreties.PropertyValues;
using Nikcio.UHeadless.Models.Properties.BlockList;
using Nikcio.UHeadless.Models.Properties.NestedContent;
using System;
using System.Linq;
using Umbraco.Cms.Core;

namespace Nikcio.UHeadless.Factories.Properties.PropertyValues
{
    public class PropertyValueFactory : IPropertyValueFactory
    {
        private readonly IPropertyMap propertyMap;
        private readonly IServiceProvider serviceProvider;

        public PropertyValueFactory(IPropertyMap propertyMapper, IServiceProvider serviceProvider)
        {
            propertyMap = propertyMapper;
            AddPropertyMapDefaults();
            this.serviceProvider = serviceProvider;
        }
        private void AddPropertyMapDefaults()
        {
            if (!propertyMap.ContainsEditor(UHeadlessConstants.Constants.PropertyConstants.DefaultKey))
            {
                propertyMap.AddEditorMapping<PropertyValueBasicGraphType>(UHeadlessConstants.Constants.PropertyConstants.DefaultKey);
            }
            if (!propertyMap.ContainsEditor(Constants.PropertyEditors.Aliases.BlockList))
            {
                propertyMap.AddEditorMapping<BlockListModelGraphType>(Constants.PropertyEditors.Aliases.BlockList);
            }
            if (!propertyMap.ContainsEditor(Constants.PropertyEditors.Aliases.NestedContent))
            {
                propertyMap.AddEditorMapping<NestedContentGraphType>(Constants.PropertyEditors.Aliases.NestedContent);
            }
        }

        public PropertyValueBaseGraphType GetPropertyValue(CreatePropertyValue createPropertyValue)
        {
            string propertyTypeAssemblyQualifiedName;
            if (propertyMap.ContainsAlias(createPropertyValue.Property.PropertyType.ContentType.Alias, createPropertyValue.Property.PropertyType.Alias))
            {
                propertyTypeAssemblyQualifiedName = propertyMap.GetAliasValue(createPropertyValue.Property.PropertyType.ContentType.Alias, createPropertyValue.Property.PropertyType.Alias);

            }
            else if (propertyMap.ContainsEditor(createPropertyValue.Property.PropertyType.EditorAlias))
            {
                propertyTypeAssemblyQualifiedName = propertyMap.GetEditorValue(createPropertyValue.Property.PropertyType.EditorAlias);
            }
            else
            {
                propertyTypeAssemblyQualifiedName = propertyMap.GetEditorValue(UHeadlessConstants.Constants.PropertyConstants.DefaultKey);
            }
            var type = Type.GetType(propertyTypeAssemblyQualifiedName);
            var constructors = type.GetConstructors();
            var parameters = constructors.FirstOrDefault(constructor => constructor.GetParameters().FirstOrDefault().ParameterType == typeof(CreatePropertyValue)).GetParameters();
            var injectedParamerters = new object[] { createPropertyValue }.Concat(parameters.Skip(1).Select(parameter => serviceProvider.GetService(parameter.ParameterType))).ToArray();
            return (PropertyValueBaseGraphType)Activator.CreateInstance(Type.GetType(propertyTypeAssemblyQualifiedName), injectedParamerters);
        }
    }
}
