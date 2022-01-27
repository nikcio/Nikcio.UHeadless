﻿using AutoMapper;
using Nikcio.UHeadless.Commands.Properties;
using Nikcio.UHeadless.Factories.Properties;
using Nikcio.UHeadless.Factories.Reflection;
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

        public BlockListModelGraphType(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue)
        {
            var value = (BlockListModel)createPropertyValue.Property.GetValue();
            Blocks = value.ToList()
                ?.Select(blockListItem =>
                {
                    var propertyTypeAssemblyQualifiedName = blockListItem.GetType().AssemblyQualifiedName;
                    var type = Type.GetType(propertyTypeAssemblyQualifiedName);
                    return dependencyReflectorFactory.GetReflectedType<T>(type, new object[1] { createPropertyValue });
                }).ToList();
        }
    }
}
