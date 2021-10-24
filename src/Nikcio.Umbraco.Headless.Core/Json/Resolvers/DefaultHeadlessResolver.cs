using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Nikcio.Umbraco.Headless.Core.Attributes;
using Nikcio.Umbraco.Headless.Core.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Nikcio.Umbraco.Headless.Core.Json.Resolvers
{
    public class DefaultHeadlessResolver : DefaultContractResolver
    {
        protected virtual bool ShouldSerialize(MemberInfo member, JsonProperty property)
        {
            if (IsInPublishedContentNamespace(member) && (IsIgnored(member) || HasIgnoreAttribute(member)))
            {
                return false;
            }

            return true;

            static bool IsIgnored(MemberInfo member)
            {
                return Constants.Constants.Json.DefaultJsonIgnore.Any(ignoredValue => ignoredValue == member.Name);
            }

            static bool HasIgnoreAttribute(MemberInfo member)
            {
                return ((IEnumerable<JsonIgnoreProperty>)member.DeclaringType?.GetCustomAttributes(typeof(JsonIgnoreProperty))).Any(p => p.PropertyName == member.Name);
            }

            static bool IsInPublishedContentNamespace(MemberInfo member)
            {
                return member.DeclaringType?.Namespace == Constants.Constants.Json.PublishedContentNamespace;
            }
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            property.ShouldSerialize = instance => ShouldSerialize(member, property);
            property.PropertyName = property.PropertyName.ToCamleCase();
            SetPropertyOrder(member, property);

            return property;

            static void SetPropertyOrder(MemberInfo member, JsonProperty property)
            {
                switch (member.Name)
                {
                    case "Id":
                        property.Order = -99;
                        break;

                    case "Key":
                        property.Order = -98;
                        break;

                    case "Name":
                        property.Order = -97;
                        break;

                    case "Level":
                        property.Order = -96;
                        break;

                    case "Url":
                        property.Order = -95;
                        break;

                    default:
                        break;
                }
            }
        }

        protected override JsonContract CreateContract(Type objectType)
        {
            JsonContract contract = base.CreateContract(objectType);

            return contract;

        }
    }
}
