using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Commands.Properties;
using Nikcio.UHeadless.Factories.Properties;
using Nikcio.UHeadless.Models.Dtos.Propreties.PropertyValues;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.Blocks;

namespace Nikcio.UHeadless.Models.Properties.BlockList
{
    public class BlockListModelGraphType : PropertyValueBaseGraphType
    {
        public List<BlockListItemGraphType> Blocks { get; set; }

        public BlockListModelGraphType(CreatePropertyValue createPropertyValue, IMapper mapper, IPropertyFactory propertyFactory) : base(createPropertyValue)
        {
            var value = (BlockListModel)createPropertyValue.Property.GetValue();
            Blocks = value.ToList()
                ?.Select(blockListItem => new BlockListItemGraphType(blockListItem, mapper, propertyFactory, createPropertyValue.Content, createPropertyValue.Culture)).ToList();
        }
    }

    public class BlockListModelGraphType<T> : PropertyValueBaseGraphType
        where T : PropertyValueBaseGraphType
    {
        public List<T> Blocks { get; set; }

        public BlockListModelGraphType(CreatePropertyValue createPropertyValue, IServiceProvider serviceProvider) : base(createPropertyValue)
        {
            var value = (BlockListModel)createPropertyValue.Property.GetValue();
            Blocks = value.ToList()
                ?.Select(blockListItem => {
                    var propertyTypeAssemblyQualifiedName = blockListItem.GetType().AssemblyQualifiedName;
                    var type = Type.GetType(propertyTypeAssemblyQualifiedName);
                    var constructors = type.GetConstructors();
                    var parameters = constructors.FirstOrDefault(constructor => constructor.GetParameters().FirstOrDefault().ParameterType == typeof(CreatePropertyValue)).GetParameters();
                    var injectedParamerters = new object[] { createPropertyValue }.Concat(parameters.Skip(1).Select(parameter => serviceProvider.GetService(parameter.ParameterType))).ToArray();
                    return (T)Activator.CreateInstance(Type.GetType(propertyTypeAssemblyQualifiedName), injectedParamerters);
                }).ToList();
        }
    }
}
