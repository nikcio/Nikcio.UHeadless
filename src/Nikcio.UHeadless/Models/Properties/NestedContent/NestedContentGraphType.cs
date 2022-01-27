using AutoMapper;
using Nikcio.UHeadless.Commands.BlockLists;
using Nikcio.UHeadless.Commands.Properties;
using Nikcio.UHeadless.Factories.Properties;
using Nikcio.UHeadless.Factories.Reflection;
using Nikcio.UHeadless.Models.Dtos.Elements;
using Nikcio.UHeadless.Models.Dtos.Propreties.PropertyValues;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Models.Properties.NestedContent
{
    public class NestedContentGraphType<T> : PropertyValueBaseGraphType
        where T : ElementBaseGraphType
    {
        public List<T> Elements { get; set; }

        public NestedContentGraphType(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue)
        {
            var elements = (createPropertyValue.Property.GetValue() as IEnumerable<IPublishedElement>).ToList();
            Elements = elements.ToList()
                ?.Select(element =>
                {
                    var propertyTypeAssemblyQualifiedName = typeof(T).AssemblyQualifiedName;
                    var type = Type.GetType(propertyTypeAssemblyQualifiedName);
                    return dependencyReflectorFactory.GetReflectedType<T>(type, new object[1] { new CreateElement(createPropertyValue.Content, element, createPropertyValue.Culture) });
                }).ToList();
        }
    }
}
