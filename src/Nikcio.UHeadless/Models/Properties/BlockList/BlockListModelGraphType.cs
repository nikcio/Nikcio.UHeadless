using AutoMapper;
using Nikcio.UHeadless.Commands.BlockLists;
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
    public class BlockListModelGraphType<T> : PropertyValueBaseGraphType
        where T : BlockListItemBaseGraphType
    {
        public List<T> Blocks { get; set; }

        public BlockListModelGraphType(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue)
        {
            var value = (BlockListModel)createPropertyValue.Property.GetValue();
            Blocks = value.ToList()
                ?.Select(blockListItem =>
                {
                    var propertyTypeAssemblyQualifiedName = typeof(T).AssemblyQualifiedName;
                    var type = Type.GetType(propertyTypeAssemblyQualifiedName);
                    return dependencyReflectorFactory.GetReflectedType<T>(type, new object[1] { new CreateBlockListItem(createPropertyValue.Content, blockListItem, createPropertyValue.Culture) });
                }).ToList();
        }
    }
}
